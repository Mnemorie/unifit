using UnityEngine;
using System.Collections;

public class GetsReplacedWithCore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ReplacedWithCore ();
	}

	void ReplacedWithCore(){
		GameObject thing = GameObject.Instantiate (Resources.Load ("TheThing"), this.transform.position, Quaternion.identity) as GameObject;
		Camera.main.GetComponent<FollowsObject> ().followThis = thing;
		Destroy (this.gameObject);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
