using UnityEngine;
using System.Collections;
using GamepadInput;
using UnityEngine.UI;

public class GameJoinControl : MonoBehaviour 
{
	public bool player1Ready;
	public Animator player1Animation;

	public bool player2Ready;
	public Animator player2Animation;

	public bool player3Ready;
	public Animator player3Animation;

	public bool player4Ready;
	public Animator player4Animation;

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
        Player1Mapping = Mapping.Load(1);
        Player2Mapping = Mapping.Load(2);
        Player3Mapping = Mapping.Load(3);
        Player4Mapping = Mapping.Load(4);
	}

	void CheckReady()
    {
        player1Ready = player1Ready || Player1Mapping.Any();
        player2Ready = player2Ready || Player2Mapping.Any();
        player3Ready = player3Ready || Player3Mapping.Any();
        player4Ready = player4Ready || Player4Mapping.Any();
		
		player1Animation.SetBool ("Selected", player1Ready);
		player2Animation.SetBool ("Selected", player2Ready);
		player3Animation.SetBool ("Selected", player3Ready);
		player4Animation.SetBool ("Selected", player4Ready);

	}

	bool AllPayersAreReady()
    {
		return player1Ready && player2Ready && player3Ready && player4Ready;

	}

	void StartGame(){
		Application.LoadLevel (Application.loadedLevel + 1);
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
		
			CountDownText.text = countDown.ToString();
		}

		if ( AllPayersAreReady() && countDown <= 0) 
        {
			StartGame();
		}

	}
}
