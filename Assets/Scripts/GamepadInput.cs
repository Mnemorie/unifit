using UnityEngine;
using System.Collections.Generic;

public class GamepadInput : MonoBehaviour
{
    public string XAxis;
    public string YAxis;

    bool LeftDown;
    bool LeftDownPreviously;

    public bool LeftPressed()
    {
        return !LeftDownPreviously && LeftDown;
    }

    bool RightDown;
    bool RightDownPreviously;

    public bool RightPressed()
    {
        return !RightDownPreviously && RightDown;
    }

    bool UpDown;
    bool UpDownPreviously;

    public bool UpPressed()
    {
        return !UpDownPreviously && UpDown;
    }

    bool DownDown;
    bool DownDownPreviously;

    public bool DownPressed()
    {
        return !DownDownPreviously && DownDown;
    }

    void Update()
    {
        LeftDownPreviously = LeftDown;
        LeftDown = Input.GetAxis(XAxis) < 0;

        RightDownPreviously = RightDown;
        RightDown = Input.GetAxis(XAxis) > 0;

        UpDownPreviously = UpDown;
        UpDown = Input.GetAxis(YAxis) < 0;

        DownDownPreviously = DownDown;
        DownDown = Input.GetAxis(YAxis) > 0;
    }


}
