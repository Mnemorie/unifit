using UnityEngine;
using System.Collections;

public class EndsLevel : MonoBehaviour 
{
	public GameController gameController;
	public float TimeRequiredToWin;

	public float TimeSpentInside;
    public float ProximityGoal = 1;

    public Renderer TimerDisplay;

    Core Core;

    bool Ended;

	void Start () 
    {
        gameController = FindObjectOfType<GameController>();
        Core = FindObjectOfType<Core>();

        Ended = false;
	}

    void FixedUpdate()
    {
        if (Ended)
        {
            return;
        }

        if (Vector3.Distance(transform.position, Core.transform.position) < ProximityGoal)
        {
            TimeSpentInside += Time.fixedDeltaTime;
        }
        else
        {
            TimeSpentInside = 0;
        }

        if (TimeSpentInside > 0)
        {
            if (TimeSpentInside > TimeRequiredToWin)
            {
                gameController.WinLevel();
                Ended = true;
            }
            else
            {
                TimerDisplay.enabled = true;
                float displayProgress = (1 - (TimeSpentInside / TimeRequiredToWin)) * 0.5f;
                TimerDisplay.material.SetTextureOffset("_MainTex", new Vector2(0, displayProgress));
            }
        }
        else
        {
            TimerDisplay.enabled = false;
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
        else
        {
            TimerDisplay.enabled = false;
        }
    }
}
