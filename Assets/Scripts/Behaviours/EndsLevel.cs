using UnityEngine;
using System.Collections;

public class EndsLevel : MonoBehaviour {
	public GameController gameController;
	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController>();
	}

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.GetComponent<CanEndLevel>() != null) {
			EndLevel();
		}
	}

	void EndLevel(){
		Debug.Log ("Level Ended");
		gameController.EndLevel ();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
