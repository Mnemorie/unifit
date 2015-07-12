using UnityEngine;
using System.Collections;

public class EndsLevel : MonoBehaviour {
	public GameController gameController;
	public float TimeRequiredToWin;
	public float RotationSpeed ;

	private GameObject intruder;
	private float IntruderEnteredAtTime;

	public float TimeSpentInside;



	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController>();
	}

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.GetComponent<CanEndLevel>() != null) {
			this.intruder = collider.gameObject;
			IntruderEnteredAtTime =Time.time;
		}
	}

	void OnTriggerLeave(){
		this.intruder = null;
		this.TimeSpentInside = 0f;
		ResetDisplay ();
	}

	void OnTriggerExit(){
		this.intruder = null;
		this.TimeSpentInside = 0f;
		ResetDisplay ();
	}

	void OnTriggerStay(Collider collider){
		if (collider.gameObject != this.intruder) {
			return;
		}

		ChangeDisplayWhenInside ();

		this.TimeSpentInside = Time.time - IntruderEnteredAtTime;

		if (this.TimeSpentInside > TimeRequiredToWin)
			EndLevel ();
	}


	void ChangeDisplayWhenInside(){
		this.transform.RotateAround (this.transform.position, Vector3.left, RotationSpeed * Time.deltaTime);
	}
	void ResetDisplay(){
		this.transform.localRotation = Quaternion.identity;
	}


	void EndLevel(){
		Debug.Log ("Level Ended");
		gameController.EndLevel ();
	}
	// Update is called once per frame
	void Update () {


	}
}
