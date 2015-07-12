using UnityEngine;
using System.Collections;

public class RemovesBlocAndDisapears : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider collider){
		Debug.Log ("RRRrrr");
	}

	void OnTriggerStay(Collider collider){
		Debug.Log ("Destroying: " + collider);
		Destroy (collider.gameObject);
		Destroy (this.gameObject);	
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
