using UnityEngine;
using System.Collections;

public class EndsLevel : MonoBehaviour 
{
	public GameController GameController;
	public float TimeRequiredToWin;

	public float TimeSpentInside;
    public float ProximityGoal = 1;

    public Renderer TimerDisplay;

    Core Core;

    bool Ended;

	void Start () 
    {
        GameController = FindObjectOfType<GameController>();
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
            if (TimeSpentInside <= 0)
            {
                Core.OnEnterZone();
            }

            TimeSpentInside += Time.fixedDeltaTime;
        }
        else
        {
            if (TimeSpentInside > 0)
            {
                Core.OnLeaveZone();
            }

            TimeSpentInside = 0;
        }

        if (TimeSpentInside > 0)
        {
            if (TimeSpentInside > TimeRequiredToWin)
            {
                Core.OnWin();
                GameController.WinLevel();
                Ended = true;
                TimerDisplay.enabled = false;
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
}
