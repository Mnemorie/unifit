
using JetBrains.Annotations;
using UnityEngine;
using System.Collections.Generic;

using GamepadInput;

class DPad
{
    public GamePad.Index Index;
    public GamePad.Axis Axis;

    public DPad(GamePad.Index index, GamePad.Axis axis)
    {
        Index = index;
        Axis = axis;
    }

    Vector2 previousInput;
    Vector2 currentInput;

    public void Update()
    {
        previousInput = currentInput;
        currentInput = GamePad.GetAxis(Axis, Index);
    }

    public bool UpJustPressed()
    {
        return previousInput.y < 1 && currentInput.y > 0;
    }

    public bool DownJustPressed()
    {
        return previousInput.y > -1 && currentInput.y < 0;
    }

    public bool LeftJustPressed()
    {
        return previousInput.x > -1 && currentInput.x < 0;
    }

    public bool RightJustPressed()
    {
        return previousInput.x < 1 && currentInput.x > 0;
    }
}

public class Player : MonoBehaviour
{
    public bool UseKeyboard = true;

    public KeyCode ControlLeft;
    public KeyCode ControlRight;
    public KeyCode ControlUp;
    public KeyCode ControlDown;

    private Node Node;
    private Motor Motor;

    public PistonMotion LeftPiston;
    public PistonMotion RightPiston;
    public PistonMotion UpPiston;
    public PistonMotion DownPiston;

    public GamePad.Index Index;
    public GamePad.Axis Axis;

    DPad pad;

	void Start () 
    {
        Node = GetComponent<Node>();
        Motor = GetComponent<Motor>();

        pad = new DPad(Index, Axis);
	}

    public Vector2 DPadAxis;
    public Vector2 LeftAxis;
    public Vector2 RightAxis;

    public GamePad.Button PistonUp;
    public GamePad.Button PistonDown;
    public GamePad.Button PistonLeft;
    public GamePad.Button PistonRight;

    void Update () 
    {
        DPadAxis = GamePad.GetAxis(GamePad.Axis.Dpad, Index);
        LeftAxis = GamePad.GetAxis(GamePad.Axis.LeftStick, Index);
        RightAxis = GamePad.GetAxis(GamePad.Axis.RightStick, Index);

        pad.Axis = Axis;
        pad.Index = Index;
        pad.Update();

        if (Motor.IsAnybodyMoving)
        {
            return;
        }

        if (UseKeyboard)
        {
            if (Input.GetKeyDown(ControlLeft))
            {
                Move(TransformMotionVectorToLocal(Vector3.back));
            }

            if (Input.GetKeyDown(ControlRight))
            {
                Move(TransformMotionVectorToLocal(Vector3.forward));
            }

            if (Input.GetKeyDown(ControlUp))
            {
                Move(TransformMotionVectorToLocal(Vector3.up));
            }

            if (Input.GetKeyDown(ControlDown))
            {
                Move(TransformMotionVectorToLocal(Vector3.down));
            }
        }
        else
        {
            if (pad.LeftJustPressed())
            {
                Move(TransformMotionVectorToLocal(Vector3.back));
            }

            if (pad.RightJustPressed())
            {
                Move(TransformMotionVectorToLocal(Vector3.forward));
            }

            if (pad.UpJustPressed())
            {
                Move(TransformMotionVectorToLocal(Vector3.up));
            }

            if (pad.DownJustPressed())
            {
                Move(TransformMotionVectorToLocal(Vector3.down));
            }

            if (GamePad.GetButtonDown(PistonUp, Index))
            {
                FirePiston(TransformMotionVectorToLocal(Vector3.up));
            }

            if (GamePad.GetButtonDown(PistonDown, Index))
            {
                FirePiston(TransformMotionVectorToLocal(Vector3.down));
            }

            if (GamePad.GetButtonDown(PistonLeft, Index))
            {
                FirePiston(TransformMotionVectorToLocal(Vector3.back));
            }

            if (GamePad.GetButtonDown(PistonRight, Index))
            {
                FirePiston(TransformMotionVectorToLocal(Vector3.forward));
            }
        }
	}

    void FirePiston(Vector3 direction)
    {
        if (Node.PickNode(transform, Vector3.zero, direction) != null)
        {
            Fail();
            return;
        }

        if (direction.y > 0.5f)
        {
            UpPiston.SetPushing();
        }
        else if (direction.y < -0.5f)
        {
            DownPiston.SetPushing();
        }
        else if (direction.z < -0.5f)
        {
            LeftPiston.SetPushing();
        }
        else
        {
            RightPiston.SetPushing();
        }
    }

    void Move(Vector3 motion)
    {
        if (Node.PickFloor(transform, Vector3.zero, motion))
        {
            Fail();
            return;
        }

        if (Node.PickNode(transform, Vector3.zero, motion) != null)
        {
            Fail();
            return;
        }

        foreach (Node n in Node.GetNeighbors())
        {
            if (n.HasForOnlyNeighbor(Node))
            {
                Fail();
                return;
            }
        }

        List<Node> neighborsAtTargetPos = Node.GetNeighborsAt(transform, motion);

        if (neighborsAtTargetPos.Count == 1)
        {
            Vector3 diagMotion = SolveDiagonal(motion);

            if (diagMotion == Vector3.zero)
            {
                Fail();
                return;
            }

            Motor.Move(motion, diagMotion);
        }
        else
        {
            Motor.Move(motion);
        }
    }

    void Fail()
    {

    }

    Vector3 SolveDiagonal(Vector3 motion)
    {
        if (Mathf.Abs(motion.z) > 0.1f)
        {
            Node rotationRoot = Node.PickNode(transform, Vector3.zero, -Vector3.up);
            if (rotationRoot != null && rotationRoot.GetNeighbors().Count > 1 && 
                !Node.PickFloor(transform, transform.TransformDirection(motion), -Vector3.up))
            {
                return -Vector3.up;
            }
            rotationRoot = Node.PickNode(transform, Vector3.zero, Vector3.up);
            if (rotationRoot != null && rotationRoot.GetNeighbors().Count > 1 &&
                !Node.PickFloor(transform, transform.TransformDirection(motion), Vector3.up))
            {
                return Vector3.up;
            }
        }
        else
        {
            Node rotationRoot = Node.PickNode(transform, Vector3.zero, -Vector3.forward);
            if (rotationRoot != null && rotationRoot.GetNeighbors().Count > 1 &&
                !Node.PickFloor(transform, transform.TransformDirection(motion), -Vector3.forward))
            {
                return -Vector3.forward;
            }
            rotationRoot = Node.PickNode(transform, Vector3.zero, Vector3.forward);
            if (rotationRoot != null && rotationRoot.GetNeighbors().Count > 1 && 
                !Node.PickFloor(transform, transform.TransformDirection(motion), -Vector3.up))
            {
                return Vector3.forward;
            }  
        }

        return Vector3.zero;
    }

    Vector3 TransformMotionVectorToLocal(Vector3 v)
    {
        if (Vector3.Angle(Vector3.up, transform.up) < 45)
        {
            return v;
        }
        
        if (Vector3.Angle(Vector3.up, transform.up) > 135)
        {
            return -v;
        }

        Vector3 c = Vector3.Cross(Vector3.up, transform.up);
        if (c.x < 0)
        {
            return Quaternion.AngleAxis(90, Vector3.right) * v;
        }
        
        return Quaternion.AngleAxis(90, Vector3.left) * v;
    }
}
