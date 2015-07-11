using UnityEngine;
using System.Collections;

public class CameraMatch : MonoBehaviour {

	public GameObject followThis;
	public Vector3 offSet;
	public Vector2 responsiveness;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

		if (followThis == null)
			return;
		//this.transform.position = Vector3.Lerp(this.transform.position, followThis.transform.position + offSet, responsiveness );
		this.transform.position = new Vector3(
			Mathf.Lerp(this.transform.position.x, followThis.transform.position.x + offSet.x, responsiveness.x ),
			Mathf.Lerp(this.transform.position.y, followThis.transform.position.y + offSet.y, responsiveness.y ),
			followThis.transform.position.z + offSet.z);
		//this.transform.position.y = Mathf.Lerp(this.transform.position.y, followThis.transform.position.y + offSet.y, responsiveness.y );
		//this.transform.position.z = followThis.transform.position + offSet.z;
		//this.transform.position = new Vector3(this.transform.position.x, offSet.y, this.transform.position.z ); 
	}
}
