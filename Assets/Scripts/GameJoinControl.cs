using System.Linq;
using UnityEngine;
using System.Collections;
using GamepadInput;
using UnityEngine.UI;

public class GameJoinControl : MonoBehaviour 
{
    public bool[] PlayersReady;
    public Animator[] PlayerAnimations;

	public Text CountDownText;
	private int countDown = -1 ;
	private float startedCountDownAtTime;

    Mapping Player1Mapping;
    Mapping Player2Mapping;
    Mapping Player3Mapping;
    Mapping Player4Mapping;

	// Use this for initialization
	void Start () 
    {
	}

	void CheckReady()
    {
        for (int i = 0; i < PlayersReady.Length; ++i)
        {
            PlayerAnimations[i].SetBool("Selected", PlayersReady[i]);
        }
	}

	bool AllPayersAreReady()
    {
        foreach (bool r in PlayersReady)
        {
            if (!r)
            {
                return false;
            }
        }
        return true;
	}

	void StartGame()
    {
		Application.LoadLevel (1);
	}

	// Update is called once per frame
	void Update () 
    {
		CheckReady ();

		if (!AllPayersAreReady ()) {
			return;
		}

		if (AllPayersAreReady() && countDown < 0) 
        {
			countDown = 3;
			startedCountDownAtTime = Time.time;

		}

		if (countDown > 0 ) 
        {
			countDown =  3-(int)(Time.time - startedCountDownAtTime);
		}

		if ( AllPayersAreReady() && countDown <= 0) 
        {
			StartGame();
		}

	}
}
