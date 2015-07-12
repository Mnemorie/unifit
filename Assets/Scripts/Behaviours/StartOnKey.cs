using UnityEngine;
using System.Collections;

public class StartOnKey : MonoBehaviour {
	public KeyCode startKey;
	public GameController gameController;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (startKey)) {
			StartGame ();
		}
	}

	void StartGame(){
		gameController.StartGame ();
	}
}
