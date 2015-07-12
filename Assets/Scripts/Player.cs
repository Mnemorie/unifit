using System.Security;
using UnityEngine;
using System.Collections.Generic;

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

    GamepadInput Gamepad;

	void Start () 
    {
        Node = GetComponent<Node>();
        Motor = GetComponent<Motor>();
        Gamepad = GetComponent<GamepadInput>();
	}

    void Update () 
    {
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
            if (Gamepad.LeftPressed())
            {
                Move(TransformMotionVectorToLocal(Vector3.back));
            }

            if (Gamepad.RightPressed())
            {
                Move(TransformMotionVectorToLocal(Vector3.forward));
            }

            if (Gamepad.UpPressed())
            {
                Move(TransformMotionVectorToLocal(Vector3.up));
            }

            if (Gamepad.DownPressed())
            {
                Move(TransformMotionVectorToLocal(Vector3.down));
            }
        }
	}

    void FirePiston(Vector3 direction)
    {
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
            FirePiston(motion);
            return;
        }

        if (Node.PickNode(transform, Vector3.zero, motion) != null)
        {
            FirePiston(-motion);
            return;
        }

        foreach (Node n in Node.GetNeighbors())
        {
            if (n.HasForOnlyNeighbor(Node))
            {
                FirePiston(motion);
                return;
            }
        }

        List<Node> neighborsAtTargetPos = Node.GetNeighborsAt(transform, motion);

        if (neighborsAtTargetPos.Count == 1)
        {
            Vector3 diagMotion = SolveDiagonal(motion);

            if (diagMotion == Vector3.zero)
            {
                FirePiston(motion);
                return;
            }

            Motor.Move(motion, diagMotion);
        }
        else
        {
            Motor.Move(motion);
        }
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
