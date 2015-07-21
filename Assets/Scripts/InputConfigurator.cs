using System;
using UnityEngine;
using System.Collections.Generic;
using GamepadInput;

public class InputConfigurator : MonoBehaviour
{
    public int PlayersToConfigure = 4;

    enum ConfigurationPhase 
    {
        WaitingToReadInput,
        Controller,
        
        SlideUp,
        SlideDown,
        SlideLeft,
        SlideRight,

        RocketUp,
        RocketDown,
        RocketLeft,
        RocketRight,

        Finished,
    }

    enum ControllerType
    {
        Keyboard,
        Gamepad
    }

    int CurrentPlayer;
    ConfigurationPhase CurrentPhase;

    private ControllerType CurrentControllerType;

    private KeyCode KeyboardSlideUp;
    private KeyCode KeyboardSlideDown;
    private KeyCode KeyboardSlideLeft;
    private KeyCode KeyboardSlideRight;
    private KeyCode KeyboardRocketUp;
    private KeyCode KeyboardRocketDown;
    private KeyCode KeyboardRocketLeft;
    private KeyCode KeyboardRocketRight;

    private GamePad.Index GamePadIndex;
    private GamePad.Axis GamePadHorizontalAxis;
    private AxisDirection GamePadHorizontalAxisDirection;
    private GamePad.Axis GamePadVerticalAxis;
    private AxisDirection GamePadVerticalAxisDirection;
    private GamePad.Button GamePadRocketUp;
    private GamePad.Button GamePadRocketDown;
    private GamePad.Button GamePadRocketLeft;
    private GamePad.Button GamePadRocketRight;

    public enum AxisDirection
    {
        X,
        X_Negative,
        Y,
        Y_Negative
    }

	void Start () 
    {
        CurrentPlayer = 1;
        CurrentPhase = ConfigurationPhase.Controller;
    }

    void SaveAndQuit()
    {
        foreach (var player in RawMappings)
        {
            foreach (var setting in player.Value)
            {
                PlayerPrefs.SetString("p"+player.Key+setting.Key, setting.Value);
                Debug.Log("saving p" + player.Key + setting.Key + " : " + setting.Value);
            }
        }

        Application.LoadLevel(1);
    }

    void QuitWithoutSaving()
    {

    }

    Dictionary<int, Dictionary<string, string>> RawMappings = new Dictionary<int, Dictionary<string, string>>();

    void StoreForSaving()
    {
        Dictionary<string, string> mapping = new Dictionary<string, string>();
        RawMappings[CurrentPlayer] = mapping;

        if (CurrentControllerType == ControllerType.Keyboard)
        {
            mapping.Add("ControllerType", "keyboard");

            mapping.Add("KeyboardSlideUp", KeyboardSlideUp.ToString());
            mapping.Add("KeyboardSlideDown", KeyboardSlideDown.ToString());
            mapping.Add("KeyboardSlideLeft", KeyboardSlideLeft.ToString());
            mapping.Add("KeyboardSlideRight", KeyboardSlideRight.ToString());

            mapping.Add("KeyboardRocketUp", KeyboardRocketUp.ToString());
            mapping.Add("KeyboardRocketDown", KeyboardRocketDown.ToString());
            mapping.Add("KeyboardRocketLeft", KeyboardRocketLeft.ToString());
            mapping.Add("KeyboardRocketRight", KeyboardRocketRight.ToString());
        }
        else
        {
            mapping.Add("ControllerType", "gamepad");

            mapping.Add("GamePadIndex", GamePadIndex.ToString());
            mapping.Add("GamePadHorizontalAxis", GamePadHorizontalAxis.ToString());
            mapping.Add("GamePadHorizontalAxisDirection", GamePadHorizontalAxisDirection.ToString());
            mapping.Add("GamePadVerticalAxis", GamePadVerticalAxis.ToString());
            mapping.Add("GamePadVerticalAxisDirection", GamePadVerticalAxisDirection.ToString());

            mapping.Add("GamePadRocketUp", GamePadRocketUp.ToString());
            mapping.Add("GamePadRocketDown", GamePadRocketDown.ToString());
            mapping.Add("GamePadRocketLeft", GamePadRocketLeft.ToString());
            mapping.Add("GamePadRocketRight", GamePadRocketRight.ToString());
        }
    }

	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CurrentPhase == ConfigurationPhase.Controller)
            {
                if (CurrentPlayer == 1)
                {
                    QuitWithoutSaving();
                }
                else
                {
                    CurrentPlayer--;
                }
            }
            else
            {
                CurrentPhase--;
            }            
        }

	    if (WaitingForAxisReset)
	    {
	        if (GamePad.GetAxis(GamePad.Axis.Dpad, GamePadIndex).magnitude > 0.1f ||
	            GamePad.GetAxis(GamePad.Axis.LeftStick, GamePadIndex).magnitude > 0.1f ||
	            GamePad.GetAxis(GamePad.Axis.RightStick, GamePadIndex).magnitude > 0.1f)
	        {
	            return;
	        }

	        WaitingForAxisReset = false;
	    }

	    if (CurrentPhase == ConfigurationPhase.WaitingToReadInput)
	    {
	        if (CurrentControllerType != ControllerType.Gamepad ||
                AnyPad() == GamePad.Index.Any)
	        {
	            CurrentPhase++;
	        }
	    }
        else if (CurrentPhase == ConfigurationPhase.Controller)
	    {
            if (PressedKeyOrButton() != KeyCode.None)
	        {
	            CurrentControllerType = ControllerType.Keyboard;
	            CurrentPhase++;
	        }
            else
	        {
	            GamePad.Index index = AnyPad();
	            if (index != GamePad.Index.Any)
	            {
	                CurrentControllerType = ControllerType.Gamepad;
	                GamePadIndex = index;
                    CurrentPhase++;
	            }
	        }
	    }
        else if (CurrentPhase == ConfigurationPhase.SlideUp)
        {
            FetchAxisMapping(ref KeyboardSlideUp, ref GamePadVerticalAxis, ref GamePadVerticalAxisDirection);
        }
        else if (CurrentPhase == ConfigurationPhase.SlideDown)
        {
            if (CurrentControllerType == ControllerType.Gamepad) // don't need both directions for dpad
            {
                CurrentPhase++;
            }
            else
            {
                FetchAxisMapping(ref KeyboardSlideDown, ref GamePadHorizontalAxis, ref GamePadHorizontalAxisDirection);
            }
        }
        else if (CurrentPhase == ConfigurationPhase.SlideLeft)
        {
            FetchAxisMapping(ref KeyboardSlideLeft, ref GamePadHorizontalAxis, ref GamePadHorizontalAxisDirection);
        }
        else if (CurrentPhase == ConfigurationPhase.SlideRight)
        {
            if (CurrentControllerType == ControllerType.Gamepad)
            {
                CurrentPhase++;
            }
            else
            {
                FetchAxisMapping(ref KeyboardSlideRight, ref GamePadHorizontalAxis, ref GamePadHorizontalAxisDirection);
            }
        }
        else if (CurrentPhase == ConfigurationPhase.RocketUp)
        {
            FetchButtonMapping(ref KeyboardRocketUp, ref GamePadRocketUp);
        }
        else if (CurrentPhase == ConfigurationPhase.RocketDown)
        {
            FetchButtonMapping(ref KeyboardRocketDown, ref GamePadRocketDown);
        }
        else if (CurrentPhase == ConfigurationPhase.RocketLeft)
        {
            FetchButtonMapping(ref KeyboardRocketLeft, ref GamePadRocketLeft);
        }
        else if (CurrentPhase == ConfigurationPhase.RocketRight)
        {
            FetchButtonMapping(ref KeyboardRocketRight, ref GamePadRocketRight);
        }
        else if (CurrentPhase == ConfigurationPhase.Finished)
        {
            StoreForSaving();
            if (CurrentPlayer < PlayersToConfigure)
            {
                CurrentPlayer++;
                CurrentPhase = ConfigurationPhase.WaitingToReadInput;
            }
            else
            {
                SaveAndQuit();
            }
        }
	}

    private bool WaitingForAxisReset;

    void FetchAxisMapping(ref KeyCode fetchedKey, ref GamePad.Axis fetchedAxis, ref AxisDirection fetchedDirection)
    {
        if (CurrentControllerType == ControllerType.Keyboard)
        {
            KeyCode key = PressedKeyOrButton();
            if (key != KeyCode.None)
            {
                fetchedKey = key;
                CurrentPhase++;
            }
        }
        else
        {
            if (GamePad.GetAxis(GamePad.Axis.Dpad, GamePadIndex).magnitude > 0.3f)
            {
                fetchedAxis = GamePad.Axis.Dpad;
                fetchedDirection = ToDirection(GamePad.GetAxis(GamePad.Axis.Dpad, GamePadIndex));
                CurrentPhase++;
                WaitingForAxisReset = true;
            }
            else if (GamePad.GetAxis(GamePad.Axis.LeftStick, GamePadIndex).magnitude > 0.1f)
            {
                fetchedAxis = GamePad.Axis.LeftStick;
                fetchedDirection = ToDirection(GamePad.GetAxis(GamePad.Axis.LeftStick, GamePadIndex));
                CurrentPhase++;
                WaitingForAxisReset = true;
            }
            else if (GamePad.GetAxis(GamePad.Axis.RightStick, GamePadIndex).magnitude > 0.1f)
            {
                fetchedAxis = GamePad.Axis.RightStick;
                fetchedDirection = ToDirection(GamePad.GetAxis(GamePad.Axis.RightStick, GamePadIndex));
                CurrentPhase++;
                WaitingForAxisReset = true;
            }
        }
    }

    private void FetchButtonMapping(ref KeyCode fetchedKey, ref GamePad.Button fetchedButton)
    {
        if (CurrentControllerType == ControllerType.Keyboard)
        {
            KeyCode key = PressedKeyOrButton();
            if (key != KeyCode.None)
            {
                fetchedKey = key;
                CurrentPhase++;
            }
        }
        else
        {
            if (GamePad.GetButtonDown(GamePad.Button.A, GamePadIndex))
            {
                fetchedButton = GamePad.Button.A;
                CurrentPhase++;
            }
            else if (GamePad.GetButtonDown(GamePad.Button.B, GamePadIndex))
            {
                fetchedButton = GamePad.Button.B;
                CurrentPhase++;
            }
            else if (GamePad.GetButtonDown(GamePad.Button.X, GamePadIndex))
            {
                fetchedButton = GamePad.Button.X;
                CurrentPhase++;
            }
            else if (GamePad.GetButtonDown(GamePad.Button.Y, GamePadIndex))
            {
                fetchedButton = GamePad.Button.Y;
                CurrentPhase++;
            }
            if (GamePad.GetButtonDown(GamePad.Button.Back, GamePadIndex))
            {
                fetchedButton = GamePad.Button.Back;
                CurrentPhase++;
            }
            else if (GamePad.GetButtonDown(GamePad.Button.Start, GamePadIndex))
            {
                fetchedButton = GamePad.Button.Start;
                CurrentPhase++;
            }
        }
    }

    AxisDirection ToDirection(Vector2 axis)
    {
        if (axis.x > 0.1f)
        {
            return AxisDirection.X;
        }
        else if (axis.x < -0.1f)
        {
            return AxisDirection.X_Negative;
        }
        else if (axis.y > 0.1f)
        {
            return AxisDirection.Y;
        }
        else if(axis.y < -0.1f)
        {
            return AxisDirection.Y_Negative;
        }
        throw new Exception();
    }

    GamePad.Index AnyPad()
    {
        if (GamePad.GetState(GamePad.Index.One).Any())
        {
            return GamePad.Index.One;
        }
        
        if (GamePad.GetState(GamePad.Index.Two).Any())
        {
            return GamePad.Index.Two;
        }

        if (GamePad.GetState(GamePad.Index.Three).Any())
        {
            return GamePad.Index.Three;
        }

        if (GamePad.GetState(GamePad.Index.Four).Any())
        {
            return GamePad.Index.Four;
        }

        return GamePad.Index.Any;
    }

    public KeyCode PressedKeyOrButton()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode) &&
                !(kcode.ToString().Contains("Joystick") || 
                  kcode.ToString().Contains("Mouse") || 
                  kcode == KeyCode.Escape))
            {
                return kcode;
            }
        }
        return KeyCode.None;
    }

    private void OnGUI()
    {
        GUILayout.Label("Player " + CurrentPlayer);

        if (CurrentPhase == ConfigurationPhase.Controller)
        {
            GUILayout.Label("Press a button on the gamepad or keyboard");
        }
        else if (CurrentPhase == ConfigurationPhase.SlideUp)
        {
            GUILayout.Label("Press for Slide Upwards (d-pad up)");
        }
        else if (CurrentPhase == ConfigurationPhase.SlideDown)
        {
            GUILayout.Label("Press for Slide Downwards (d-pad down)");
        }
        else if (CurrentPhase == ConfigurationPhase.SlideLeft)
        {
            GUILayout.Label("Press for Slide Left (d-pad left)");
        }
        else if (CurrentPhase == ConfigurationPhase.SlideRight)
        {
            GUILayout.Label("Press for Slide Right (d-pad right)");
        }
        else if (CurrentPhase == ConfigurationPhase.RocketUp)
        {
            GUILayout.Label("Press for Rocket Up (snes X)");
        }
        else if (CurrentPhase == ConfigurationPhase.RocketDown)
        {
            GUILayout.Label("Press for Rocket Down (snes B)");
        }
        else if (CurrentPhase == ConfigurationPhase.RocketLeft)
        {
            GUILayout.Label("Press for Rocket Left (snes Y)");
        }
        else if (CurrentPhase == ConfigurationPhase.RocketRight)
        {
            GUILayout.Label("Press for Rocket Right (snes A)");
        }
        else if (CurrentPhase == ConfigurationPhase.Finished)
        {
            GUILayout.Label("DONE");
        }
    }
}
