﻿using System;
using UnityEngine;
using System.Collections.Generic;
using GamepadInput;

public class Controller
{
    private Mapping Mapping;

    public Controller(int playerIndex)
    {
        Mapping = Mapping.Load(playerIndex);
    }

    public struct Input
    {
        public bool SlideUp;
        public bool SlideDown;
        public bool SlideLeft;
        public bool SlideRight;

        public bool RocketUp;
        public bool RocketDown;
        public bool RocketLeft;
        public bool RocketRight;
    }

    Input previousInput;
    Input currentInput;

    public void Update()
    {
        previousInput = currentInput;

        ReadInput(ref currentInput);
    }

    protected void ReadInput(ref Input input)
    {
        input.SlideUp = Mapping.SlideUp();
        input.SlideDown = Mapping.SlideDown();
        input.SlideLeft = Mapping.SlideLeft();
        input.SlideRight = Mapping.SlideRight();

        input.RocketUp = Mapping.RocketUp();
        input.RocketDown = Mapping.RocketDown();
        input.RocketLeft = Mapping.RocketLeft();
        input.RocketRight = Mapping.RocketRight();
    }

    // there's got to be a way to mash this better :S:S:S:S:SS:
    public bool SlideUpJustPressed()
    {
        return !previousInput.SlideUp && currentInput.SlideUp;
    }

    public bool SlideDownJustPressed()
    {
        return !previousInput.SlideDown && currentInput.SlideDown;
    }

    public bool SlideLeftJustPressed()
    {
        return !previousInput.SlideLeft && currentInput.SlideLeft;
    }

    public bool SlideRightJustPressed()
    {
        return !previousInput.SlideRight && currentInput.SlideRight;
    }
    
    public bool RocketUpJustPressed()
    {
        return !previousInput.RocketUp && currentInput.RocketUp;
    }

    public bool RocketDownJustPressed()
    {
        return !previousInput.RocketDown && currentInput.RocketDown;
    }

    public bool RocketLeftJustPressed()
    {
        return !previousInput.RocketLeft && currentInput.RocketLeft;
    }

    public bool RocketRightJustPressed()
    {
        return !previousInput.RocketRight && currentInput.RocketRight;
    }

    public bool RocketUpHeld()
    {
        return currentInput.RocketUp;
    }

    public bool RocketDownHeld()
    {
        return currentInput.RocketDown;
    }

    public bool RocketLeftHeld()
    {
        return currentInput.RocketLeft;
    }

    public bool RocketRightHeld()
    {
        return currentInput.RocketRight;
    }
}

[SelectionBase]
public class Player : MonoBehaviour
{
    public bool UseKeyboard = true;

    private Node Node;
    private Motor Motor;
    private Rigidbody Body;
    
    public Animator TopFlame;
    public Animator BottomFlame;
    public Animator LeftFlame;
    public Animator RightFlame;

    public Animator TopSpark;
    public Animator BottomSpark;
    public Animator LeftSpark;
    public Animator RightSpark;

    Controller controller;

    public int PlayerIndex;

    float TimeToPiston = 0;
    public float PistonCooldown = 1;

    public Color EyeColor;

    public float FuelLevel = 1;

    private Controller CreateController()
    {
        return new Controller(PlayerIndex);
    }

    void Start () 
    {
        Node = GetComponent<Node>();
        Motor = GetComponent<Motor>();

        controller = CreateController(); 

        Body = GetComponentInParent<Rigidbody>();

        //Flame = Instantiate(Flame, transform.position, transform.rotation) as GameObject;
        //Flame.transform.parent = transform;
        
        //Flame f = Flame.GetComponent<Flame>();
        //f.SetBigFlameColor(BigFlameColor);
        //f.SetSmallFlameColor(SmallFlameColor);

        GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", EyeColor);

        SetupAudio();
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
        LeftFlame.SetFloat("FlameSize", PistonAttenuation.Evaluate(TimeSinceLastPropulsion));

        TimeSinceLastPropulsion += Time.deltaTime;

        controller.Update();

        TimeToPiston -= Time.deltaTime;

        if (TimeToPiston < PistonCooldown / 2)
        {
            //Flame.GetComponentInChildren<Animator>().SetBool("Burning", false);
        }

        if (TimeToPiston <= 0)
        {
            if (controller.RocketUpJustPressed())
            {
                FirePiston(Vector3.up);
            }

            if (controller.RocketDownJustPressed())
            {
                FirePiston(Vector3.down);
            }

            if (controller.RocketLeftJustPressed())
            {
                FirePiston(Vector3.back);
            }

            if (controller.RocketRightJustPressed())
            {
                FirePiston(Vector3.forward);
            }
        }

        if (controller.RocketUpHeld())
        {
            HoldPiston(Vector3.up);
        }
        else if (controller.RocketDownHeld())
        {
            HoldPiston(Vector3.down);
        }
        else if (controller.RocketLeftHeld())
        {
            HoldPiston(Vector3.back);
        }
        else if (controller.RocketRightHeld())
        {
            HoldPiston(Vector3.forward);
        }
        else
        {
            FuelLevel = Mathf.Min(1, FuelLevel + (Time.deltaTime*0.66f));
        }

        if (controller.SlideLeftJustPressed() && !Motor.IsAnybodyMoving)
        {
            Move(TransformMotionVectorToLocal(Vector3.back));
        }

        if (controller.SlideRightJustPressed() && !Motor.IsAnybodyMoving)
        {
            Move(TransformMotionVectorToLocal(Vector3.forward));
        }

        if (controller.SlideUpJustPressed() && !Motor.IsAnybodyMoving)
        {
            Move(TransformMotionVectorToLocal(Vector3.up));
        }

        if (controller.SlideDownJustPressed() && !Motor.IsAnybodyMoving)
        {
            Move(TransformMotionVectorToLocal(Vector3.down));
        }

        //GetComponentInChildren<Renderer>().material.SetFloat("_RangeMin", 1 - (FuelLevel * 1));
	}

    public float Power = 10;
    public float FloorPushMultiplier = 5;

    private float FlameOffset = 0.5f;

    public AnimationCurve RocketFalloffCurve;

    private float TimeSinceLastPropulsion;

    void FirePiston(Vector3 direction)
    {
        LeftSpark.SetTrigger("Burst");

        Vector3 impulse = -direction * Power;

        float distance;
        if (Node.PickFloorWithDistance(transform, Vector3.zero, TransformMotionVectorToLocal(direction), out distance))
        {
            impulse *= Mathf.Lerp(1, FloorPushMultiplier, RocketFalloffCurve.Evaluate(distance - 0.5f));
        }

        Body.AddForceAtPosition(impulse, transform.position, ForceMode.Impulse);

        TimeToPiston = PistonCooldown;

        if (Node.PickNode(transform, Vector3.zero, TransformMotionVectorToLocal(direction)) == null)
        {
            //Flame.transform.localPosition = TransformMotionVectorToLocal(direction) * FlameOffset;
            //Flame.transform.LookAt(transform.position - transform.TransformDirection(TransformMotionVectorToLocal(direction)));

            //Flame.GetComponentInChildren<Animator>().SetBool("Burning", true);
        }

        TimeSinceLastPropulsion = 0;

        OnRocket();
    }

    public AnimationCurve PistonAttenuation;
    public float PistonHoldMultiplier = 2;

    void HoldPiston(Vector3 direction)
    {
        Body.AddForceAtPosition(-direction * PistonAttenuation.Evaluate(TimeSinceLastPropulsion) * PistonHoldMultiplier * FuelLevel, transform.position, ForceMode.Force);

        FuelLevel = Mathf.Max(0, FuelLevel - Time.deltaTime);
    }

    void Move(Vector3 motion)
    {
        if (Node.PickFloor(transform, Vector3.zero, motion))
        {
            FeedbackFail();
            return;
        }

        if (Node.PickNode(transform, Vector3.zero, motion) != null)
        {
            FeedbackFail();
            return;
        }

        foreach (Node n in Node.GetNeighbors())
        {
            if (n.IsConnectedToCoreBy(Node))
            {
                FeedbackFail();
                return;
            }
        }

        List<Node> neighborsAtTargetPos = Node.GetNeighborsAt(transform, motion);

        if (neighborsAtTargetPos.Count == 1)
        {
            Vector3 diagMotion = SolveDiagonal(motion);

            if (diagMotion == Vector3.zero)
            {
                FeedbackFail();
                return;
            }

            Motor.Move(motion, diagMotion);
        }
        else
        {
            Motor.Move(motion);
        }

        OnSlide();
    }

    void FeedbackFail()
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

    	    
    void PlaySound(AudioClip clip, Transform location = null)
    {
        if (SoundBoard)
        {
            SoundBoard.Play(clip, location);
        }
    }

    void PlaySound(AudioClip[] clips, Transform location = null)
    {
        if (SoundBoard)
        {
            SoundBoard.PlayAny(clips, location);
        }
    }

    public AudioClip[] SlideSound;
    public AudioClip[] RocketSound;

    public Action OnSlide = () => { };
    public Action OnRocket = () => { };

    private SoundBoard SoundBoard;

    void SetupAudio()
    {
        SoundBoard = FindObjectOfType<SoundBoard>();

        if (SoundBoard)
        {
            OnSlide += (() => PlaySound(SlideSound));
            OnRocket += (() => PlaySound(RocketSound));
        }
        
    }
}
