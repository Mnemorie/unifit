﻿using UnityEngine;
using System.Collections;

public class EndsLevel : MonoBehaviour 
{
	public GameController gameController;
	public float TimeRequiredToWin;

	public float TimeSpentInside;
    public float ProximityGoal = 1;

    Core Core;

	void Start () 
    {
        gameController = FindObjectOfType<GameController>();
        Core = FindObjectOfType<Core>();
	}

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, Core.transform.position) < ProximityGoal)
        {
            TimeSpentInside += Time.fixedDeltaTime;
        }
        else
        {
            TimeSpentInside = 0;
        }

        if (TimeSpentInside > TimeRequiredToWin)
        {
            gameController.EndLevel();
        }
    }

    public GUISkin Skin;
    public Color TimerColor;

    public int TimerVerticalOffset = 100;

    void OnGUI()
    {
        Vector2 screenPos = GUIUtility.ScreenToGUIPoint(Camera.main.WorldToScreenPoint(transform.position));
        Rect labelRect = new Rect(screenPos.x - 25, Screen.height - screenPos.y - TimerVerticalOffset, 50, 30);

        GUI.skin = Skin;

        string timer = Mathf.FloorToInt(Time.timeSinceLevelLoad).ToString();
        GUIHelper.DrawOutline(labelRect, timer, 2);
        GUI.color = TimerColor;
        GUI.Label(labelRect, timer);

        if (TimeSpentInside > 0)
        {
            labelRect = new Rect(screenPos.x - 25, Screen.height - screenPos.y - TimerVerticalOffset - 50, 50, 30);

            string winTime = Mathf.FloorToInt(TimeSpentInside * 100).ToString();
            GUIHelper.DrawOutline(labelRect, winTime, 2);
            GUI.color = TimerColor;
            GUI.Label(labelRect, winTime);
        }
    }
}
