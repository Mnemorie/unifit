using System;
using UnityEngine;

public class KeyboardMapping : Mapping
{
    public KeyCode SlideUpKey;
    public KeyCode SlideDownKey;
    public KeyCode SlideLeftKey;
    public KeyCode SlideRightKey;
    public KeyCode RocketUpKey;
    public KeyCode RocketDownKey;
    public KeyCode RocketLeftKey;
    public KeyCode RocketRightKey;

    public override bool SlideUp()
    {
        return Input.GetKey(SlideUpKey);
    }

    public override bool SlideDown()
    {
        return Input.GetKey(SlideDownKey);
    }

    public override bool SlideLeft()
    {
        return Input.GetKey(SlideLeftKey);
    }

    public override bool SlideRight()
    {
        return Input.GetKey(SlideRightKey);
    }

    public override bool RocketUp()
    {
        return Input.GetKey(RocketUpKey);
    }

    public override bool RocketDown()
    {
        return Input.GetKey(RocketDownKey);
    }

    public override bool RocketLeft()
    {
        return Input.GetKey(RocketLeftKey);
    }

    public override bool RocketRight()
    {
        return Input.GetKey(RocketRightKey);
    }

    public KeyboardMapping(int player)
    {
        SlideUpKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("p" + player + "SlideUpKey"));
        SlideDownKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("p" + player + "SlideDownKey"));
        SlideLeftKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("p" + player + "SlideLeftKey"));
        SlideRightKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("p" + player + "SlideRightKey"));

        RocketUpKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("p" + player + "RocketUpKey"));
        RocketDownKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("p" + player + "RocketDownKey"));
        RocketLeftKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("p" + player + "RocketLeftKey"));
        RocketRightKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("p" + player + "RocketRightKey"));
    }
}
