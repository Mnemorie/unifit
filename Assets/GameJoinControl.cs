using UnityEngine;
using System.Collections;
using GamepadInput;
using UnityEngine.UI;

public class GameJoinControl : MonoBehaviour {

	public bool usingGamePad;

	public GamePad.Index player1;
	public GamePad.Button player1Button;
	public bool player1Ready;
	public Animator player1Animation;

	public GamePad.Index player2;
	public GamePad.Button player2Button;
	public bool player2Ready;
	public Animator player2Animation;

	public GamePad.Index player3;
	public GamePad.Button player3Button;
	public bool player3Ready;
	public Animator player3Animation;

	public GamePad.Index player4;
	public GamePad.Button player4Button;
	public bool player4Ready;
	public Animator player4Animation;

	public Text CountDownText;
	private int countDown = -1 ;
	private float startedCountDownAtTime;


	// Use this for initialization
	void Start () {
	
	}

	void CheckReady(){
		if (usingGamePad) {
			
			player1Ready = player1Ready || GamePad.GetButtonDown (player1Button, player1);
			player2Ready = player2Ready || GamePad.GetButtonDown (player2Button, player2);
			player3Ready = player3Ready || GamePad.GetButtonDown (player3Button, player3);
			player4Ready = player4Ready || GamePad.GetButtonDown (player4Button, player4);
			
		} else {
			player1Ready = player1Ready || Input.GetKeyDown(KeyCode.Q);
			player2Ready = player2Ready || Input.GetKeyDown(KeyCode.W);
			player3Ready = player3Ready || Input.GetKeyDown(KeyCode.E);
			player4Ready = player4Ready || Input.GetKeyDown(KeyCode.R);	
		}
		
		player1Animation.SetBool ("Selected", player1Ready);
		player2Animation.SetBool ("Selected", player2Ready);
		player3Animation.SetBool ("Selected", player3Ready);
		player4Animation.SetBool ("Selected", player4Ready);

	}

	bool AllPayersAreReady(){
		return player1Ready && player2Ready && player3Ready && player4Ready;

	}

	void StartGame(){
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	// Update is called once per frame
	void Update () {
		CheckReady ();

		if (!AllPayersAreReady ()) {
			return;
		}

		if (AllPayersAreReady() && countDown < 0) {
			countDown = 3;
			startedCountDownAtTime = Time.time;

		}

		if (countDown > 0 ) {
			countDown =  3-(int)(Time.time - startedCountDownAtTime);
		
			CountDownText.text = countDown.ToString();
		}

		if ( AllPayersAreReady() && countDown <= 0) {
			StartGame();
		}

	}
}
