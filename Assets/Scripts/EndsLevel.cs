using UnityEngine;
using System.Collections;

public class EndsLevel : MonoBehaviour 
{
	private GameController GameController;
	public float TimeRequiredToWin;

	protected float TimeSpentInside;
    public float ProximityGoal = 1;

    protected Core Core;

    bool Ended;

	protected virtual void Start () 
    {
        GameController = FindObjectOfType<GameController>();
        Core = FindObjectOfType<Core>();

        Ended = false;
	}

    public virtual bool IsValid()
    {
        return Vector3.Distance(transform.position, Core.transform.position) < ProximityGoal;
    }

    protected virtual void AnimateValid()
    {
    }

    void FixedUpdate()
    {
        if (Ended)
        {
            return;
        }

        if (IsValid())
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
            }
            else
            {
                AnimateValid();
            }
        }
    }
}
