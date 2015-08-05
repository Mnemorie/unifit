using System;
using UnityEngine;
using System.Collections.Generic;
using GamepadInput;
using UnityEngine.UI;

public class InputConfigurator : MonoBehaviour
{
    public int PlayersToConfigure = 4;

    public Text PlayerLabel;
    public Image KeyImage;
    public Text KeyLabel;

    public int CurrentKeyImageIndex;
    public Sprite[] KeyImages;

    public Text HintLabel;
    public Text LocationLabel;

    public PlayerConfigurator[] PlayerConfigurators;

    enum ConfigurationPhase 
    {
        WaitingToReadInput,
        
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

    public Animator Animator;

    private SoundBoard SoundBoard;

    public AudioClip InputClip;
    public AudioClip CancelClip;

	void Start() 
    {
        CurrentPlayer = 1;
        CurrentPhase = ConfigurationPhase.SlideUp;

	    SoundBoard = FindObjectOfType<SoundBoard>();

        Cursor.visible = false;
    }

    void PlaySound(AudioClip clip, Transform location = null)
    {
        if (SoundBoard)
        {
            SoundBoard.Play(clip, location);
        }
    }

    void SaveAndQuit()
    {
        foreach (var player in RawMappings)
        {
            foreach (var setting in player.Value)
            {
                PlayerPrefs.SetString("p"+player.Key+setting.Key, setting.Value);
            }
        }

        PlayerPrefs.Save();

        // Animator will load next level in Outro state (HURRAH FOR OBFUSCATION THROUGH "DATA")
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

    public Transform[] Players;
    
    void Update () 
    {
        AnimatorStateInfo state = Animator.GetCurrentAnimatorStateInfo(0);

        if (!state.IsName("P1Config") &&
            !state.IsName("P2Config") &&
            !state.IsName("P3Config") &&
            !state.IsName("P4Config"))
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.F12) && Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("flusing save data");
            PlayerPrefs.DeleteAll();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CurrentPhase == ConfigurationPhase.SlideUp)
            {
                if (CurrentPlayer == 1)
                {
                    QuitWithoutSaving();
                }
                else
                {
                    CurrentPlayer--;
                    PlayerConfigurators[CurrentPlayer - 1].Unready();
                    GetComponent<GameJoinControl>().PlayersReady[CurrentPlayer - 1] = false;
                }
            }
            else
            {
                CurrentPhase = ConfigurationPhase.SlideUp;
            }

            PlaySound(CancelClip, Players[CurrentPlayer-1]);

            return;
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
        else if (CurrentPhase == ConfigurationPhase.SlideUp)
        {
            if (PressedKeyOrButton() != KeyCode.None)
            {
                CurrentControllerType = ControllerType.Keyboard;
                FetchAxisMapping(ref KeyboardSlideUp, ref GamePadVerticalAxis, ref GamePadVerticalAxisDirection);
            }
            else
            {
                GamePad.Index index = AnyPad();
                if (index != GamePad.Index.Any)
                {
                    CurrentControllerType = ControllerType.Gamepad;
                    GamePadIndex = index;
                    FetchAxisMapping(ref KeyboardSlideUp, ref GamePadVerticalAxis, ref GamePadVerticalAxisDirection);
                }
            }
        }
        else if (CurrentPhase == ConfigurationPhase.SlideDown)
        {
            FetchAxisMapping(ref KeyboardSlideDown, ref GamePadHorizontalAxis, ref GamePadHorizontalAxisDirection, true);
        }
        else if (CurrentPhase == ConfigurationPhase.SlideLeft)
        {
            FetchAxisMapping(ref KeyboardSlideLeft, ref GamePadHorizontalAxis, ref GamePadHorizontalAxisDirection);
        }
        else if (CurrentPhase == ConfigurationPhase.SlideRight)
        {
            FetchAxisMapping(ref KeyboardSlideRight, ref GamePadHorizontalAxis, ref GamePadHorizontalAxisDirection, true);
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
            PlayerConfigurators[CurrentPlayer - 1].Ready();
            GetComponent<GameJoinControl>().PlayersReady[CurrentPlayer - 1] = true;

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

        UpdateGUI();
	}

    private bool WaitingForAxisReset;

    void FetchAxisMapping(ref KeyCode fetchedKey, ref GamePad.Axis fetchedAxis, ref AxisDirection fetchedDirection, bool ignored = false)
    {
        if (CurrentControllerType == ControllerType.Keyboard)
        {
            KeyCode key = PressedKeyOrButton();
            if (key != KeyCode.None)
            {
                fetchedKey = key;
                CurrentPhase++;
                PlaySound(InputClip, Players[CurrentPlayer - 1]);
            }
        }
        else
        {
            if (GamePad.GetAxis(GamePad.Axis.Dpad, GamePadIndex).magnitude > 0.3f)
            {
                if (!ignored)
                {
                    fetchedAxis = GamePad.Axis.Dpad;
                    fetchedDirection = ToDirection(GamePad.GetAxis(GamePad.Axis.Dpad, GamePadIndex));
                }
                CurrentPhase++;
                WaitingForAxisReset = true;
                PlaySound(InputClip, Players[CurrentPlayer - 1]);
            }
            else if (GamePad.GetAxis(GamePad.Axis.LeftStick, GamePadIndex).magnitude > 0.3f)
            {
                if (!ignored)
                {
                    fetchedAxis = GamePad.Axis.LeftStick;
                    fetchedDirection = ToDirection(GamePad.GetAxis(GamePad.Axis.LeftStick, GamePadIndex));
                }
                CurrentPhase++;
                WaitingForAxisReset = true;
                PlaySound(InputClip, Players[CurrentPlayer - 1]);
            }
            else if (GamePad.GetAxis(GamePad.Axis.RightStick, GamePadIndex).magnitude > 0.3f)
            {
                if (!ignored)
                {
                    fetchedAxis = GamePad.Axis.RightStick;
                    fetchedDirection = ToDirection(GamePad.GetAxis(GamePad.Axis.RightStick, GamePadIndex));
                }
                CurrentPhase++;
                WaitingForAxisReset = true;
                PlaySound(InputClip, Players[CurrentPlayer - 1]);
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

                PlaySound(InputClip, Players[CurrentPlayer - 1]);
            }
        }
        else
        {
            if (GamePad.GetButtonDown(GamePad.Button.A, GamePadIndex))
            {
                fetchedButton = GamePad.Button.A;
                CurrentPhase++;

                PlaySound(InputClip, Players[CurrentPlayer - 1]);
            }
            else if (GamePad.GetButtonDown(GamePad.Button.B, GamePadIndex))
            {
                fetchedButton = GamePad.Button.B;
                CurrentPhase++;

                PlaySound(InputClip, Players[CurrentPlayer - 1]);
            }
            else if (GamePad.GetButtonDown(GamePad.Button.X, GamePadIndex))
            {
                fetchedButton = GamePad.Button.X;
                CurrentPhase++;

                PlaySound(InputClip, Players[CurrentPlayer - 1]);
            }
            else if (GamePad.GetButtonDown(GamePad.Button.Y, GamePadIndex))
            {
                fetchedButton = GamePad.Button.Y;
                CurrentPhase++;

                PlaySound(InputClip, Players[CurrentPlayer - 1]);
            }
            if (GamePad.GetButtonDown(GamePad.Button.Back, GamePadIndex))
            {
                fetchedButton = GamePad.Button.Back;
                CurrentPhase++;

                PlaySound(InputClip, Players[CurrentPlayer - 1]);
            }
            else if (GamePad.GetButtonDown(GamePad.Button.Start, GamePadIndex))
            {
                fetchedButton = GamePad.Button.Start;
                CurrentPhase++;

                PlaySound(InputClip, Players[CurrentPlayer - 1]);
            }
        }
    }

    AxisDirection ToDirection(Vector2 axis)
    {
        if (axis.x > 0.1f)
        {
            return AxisDirection.X_Negative;
        }
        else if (axis.x < -0.1f)
        {
            return AxisDirection.X;
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

    private void UpdateGUI()
    {
        LocationLabel.text = "P" + CurrentPlayer + " controls";

        if (CurrentPhase == ConfigurationPhase.SlideUp)
        {
            PlayerConfigurators[CurrentPlayer - 1].ShowSlideUp();
            PlayerConfigurators[CurrentPlayer - 1].Label.text = "Move Up";
            
        }
        else if (CurrentPhase == ConfigurationPhase.SlideDown)
        {
            PlayerConfigurators[CurrentPlayer - 1].ShowSlideDown();
            PlayerConfigurators[CurrentPlayer - 1].Label.text = "Move Down";
        }
        else if (CurrentPhase == ConfigurationPhase.SlideLeft)
        {
            PlayerConfigurators[CurrentPlayer - 1].ShowSlideLeft();
            PlayerConfigurators[CurrentPlayer - 1].Label.text = "Move Left";
        }
        else if (CurrentPhase == ConfigurationPhase.SlideRight)
        {
            PlayerConfigurators[CurrentPlayer - 1].ShowSlideRight();
            PlayerConfigurators[CurrentPlayer - 1].Label.text = "Move Right";
        }
        else if (CurrentPhase == ConfigurationPhase.RocketUp)
        {
            PlayerConfigurators[CurrentPlayer - 1].ShowRocketUp();
            PlayerConfigurators[CurrentPlayer - 1].Label.text = "Action Up";
        }
        else if (CurrentPhase == ConfigurationPhase.RocketDown)
        {
            PlayerConfigurators[CurrentPlayer - 1].ShowRocketDown();
            PlayerConfigurators[CurrentPlayer - 1].Label.text = "Action Down";
        }
        else if (CurrentPhase == ConfigurationPhase.RocketLeft)
        {
            PlayerConfigurators[CurrentPlayer - 1].ShowRocketLeft();
            PlayerConfigurators[CurrentPlayer - 1].Label.text = "Action Left";
        }
        else if (CurrentPhase == ConfigurationPhase.RocketRight)
        {
            PlayerConfigurators[CurrentPlayer - 1].ShowRocketRight();
            PlayerConfigurators[CurrentPlayer - 1].Label.text = "Action Right";
        }

        if (CurrentPlayer == 1 && CurrentPhase == ConfigurationPhase.SlideUp)
        {
            HintLabel.text = "Configure your controllers";
        }
        else if (CurrentPhase != ConfigurationPhase.SlideUp)
        {
            HintLabel.text = "Press ESC to start over";
        }
        else
        {
            HintLabel.text = "Press ESC to configure player " + (CurrentPlayer-1) + " again";
        }
    }
}
