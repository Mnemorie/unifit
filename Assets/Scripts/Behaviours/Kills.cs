using UnityEngine;
using System.Collections;

public class Kills : MonoBehaviour {
	GameController gameController;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController>();
	}


	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.GetComponent<CanDie> ()) {
			Kill(collider.gameObject);
		}
	}

	void Kill(GameObject victim){
		LoseGame ();
	}

	void LoseGame(){
		Debug.Log ("You Lost");
			gameController.Lose ();
	}


	// Update is called once per frame
	void Update () {
	
	}
}
