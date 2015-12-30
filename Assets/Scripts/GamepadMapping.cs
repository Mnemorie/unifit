using System;
using GamepadInput;
using UnityEngine;

public class GamepadMapping : Mapping
{
    public GamePad.Index GamePadIndex;
    public GamePad.Axis GamePadHorizontalAxis;
    public InputConfigurator.AxisDirection GamePadHorizontalAxisDirection;
    public GamePad.Axis GamePadVerticalAxis;
    public InputConfigurator.AxisDirection GamePadVerticalAxisDirection;
    public GamePad.Button GamePadRocketUp;
    public GamePad.Button GamePadRocketDown;
    public GamePad.Button GamePadRocketLeft;
    public GamePad.Button GamePadRocketRight;

    [SerializeField]
    public float sensitivity = 0.1f;

    // i'm sure there's a 2x2 transform i can use here...

    public override bool SlideUp()
    {
        Vector2 axis = GamePad.GetAxis(GamePadVerticalAxis, GamePadIndex);

        switch (GamePadVerticalAxisDirection)
        {
            case InputConfigurator.AxisDirection.Y:
            {
                return axis.y > sensitivity;
            }

            case InputConfigurator.AxisDirection.Y_Negative:
            {
                return axis.y < -sensitivity;
            }

            case InputConfigurator.AxisDirection.X:
            {
                return axis.x > sensitivity;
            }
                
            case InputConfigurator.AxisDirection.X_Negative:
            {
                return axis.x < -sensitivity;
            }

        }

        return false;
    }

    public override bool SlideDown()
    {
        Vector2 axis = GamePad.GetAxis(GamePadVerticalAxis, GamePadIndex);

        switch (GamePadVerticalAxisDirection)
        {
            case InputConfigurator.AxisDirection.Y:
            {
                return axis.y < -sensitivity;
            }

            case InputConfigurator.AxisDirection.Y_Negative:
            {
                return axis.y > sensitivity;
            }

            case InputConfigurator.AxisDirection.X:
            {
                return axis.x < -sensitivity;
            }
                
            case InputConfigurator.AxisDirection.X_Negative:
            {
                return axis.x > sensitivity;
            }
        }

        return false;
    }

    public override bool SlideLeft()
    {
        Vector2 axis = GamePad.GetAxis(GamePadHorizontalAxis, GamePadIndex);

        switch (GamePadHorizontalAxisDirection)
        {
            case InputConfigurator.AxisDirection.X:
                {
                    return axis.x < -sensitivity;
                }

            case InputConfigurator.AxisDirection.X_Negative:
                {
                    return axis.x > sensitivity;
                }

            case InputConfigurator.AxisDirection.Y:
                {
                    return axis.y < -sensitivity;
                }

            case InputConfigurator.AxisDirection.Y_Negative:
                {
                    return axis.y > sensitivity;
                }
        }
        return false;
    }

    public override bool SlideRight()
    {
        Vector2 axis = GamePad.GetAxis(GamePadHorizontalAxis, GamePadIndex);

        switch (GamePadHorizontalAxisDirection)
        {
            case InputConfigurator.AxisDirection.X:
                {
                    return axis.x > sensitivity;
                }

            case InputConfigurator.AxisDirection.X_Negative:
                {
                    return axis.x < -sensitivity;
                }

            case InputConfigurator.AxisDirection.Y:
                {
                    return axis.y > sensitivity;
                }

            case InputConfigurator.AxisDirection.Y_Negative:
                {
                    return axis.y < -sensitivity;
                }
        }
        return false;
    }

    public override bool RocketUp()
    {
        return GamePad.GetButton(GamePadRocketUp, GamePadIndex);
    }

    public override bool RocketDown()
    {
        return GamePad.GetButton(GamePadRocketDown, GamePadIndex);
    }

    public override bool RocketLeft()
    {
        return GamePad.GetButton(GamePadRocketLeft, GamePadIndex);
    }

    public override bool RocketRight()
    {
        return GamePad.GetButton(GamePadRocketRight, GamePadIndex);
    }

    public GamepadMapping(int player)
    {
        GamePadIndex = (GamePad.Index)Enum.Parse(typeof(GamePad.Index), PlayerPrefs.GetString("p" + player + "GamePadIndex"));

        GamePadHorizontalAxis = (GamePad.Axis)Enum.Parse(typeof(GamePad.Axis), PlayerPrefs.GetString("p" + player + "GamePadHorizontalAxis"));
        GamePadHorizontalAxisDirection = (InputConfigurator.AxisDirection)Enum.Parse(typeof(InputConfigurator.AxisDirection), PlayerPrefs.GetString("p" + player + "GamePadHorizontalAxisDirection"));

        GamePadVerticalAxis = (GamePad.Axis)Enum.Parse(typeof(GamePad.Axis), PlayerPrefs.GetString("p" + player + "GamePadVerticalAxis"));
        GamePadVerticalAxisDirection = (InputConfigurator.AxisDirection)Enum.Parse(typeof(InputConfigurator.AxisDirection), PlayerPrefs.GetString("p" + player + "GamePadVerticalAxisDirection"));

        GamePadRocketUp = (GamePad.Button)Enum.Parse(typeof(GamePad.Button), PlayerPrefs.GetString("p" + player + "GamePadRocketUp"));
        GamePadRocketDown = (GamePad.Button)Enum.Parse(typeof(GamePad.Button), PlayerPrefs.GetString("p" + player + "GamePadRocketDown"));
        GamePadRocketLeft = (GamePad.Button)Enum.Parse(typeof(GamePad.Button), PlayerPrefs.GetString("p" + player + "GamePadRocketLeft"));
        GamePadRocketRight = (GamePad.Button)Enum.Parse(typeof(GamePad.Button), PlayerPrefs.GetString("p" + player + "GamePadRocketRight"));
    }
}