using System;
using UnityEngine;

public abstract class Mapping 
{
    public abstract bool SlideUp();
    public abstract bool SlideDown();
    public abstract bool SlideLeft();
    public abstract bool SlideRight();
    public abstract bool RocketUp();
    public abstract bool RocketDown();
    public abstract bool RocketLeft();
    public abstract bool RocketRight();

    static public Mapping Load(int player) // 1-4
    {
        string controllerType = PlayerPrefs.GetString("p" + player + "ControllerType");

        if (controllerType == "keyboard")
        {
            return new KeyboardMapping(player);
        }
        else if (controllerType == "gamepad")
        {
            return new GamepadMapping(player);
        }

        throw new Exception("players not configured");
    }
}
