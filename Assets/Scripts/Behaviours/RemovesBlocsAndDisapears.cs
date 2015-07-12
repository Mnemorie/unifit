using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RemovesBlocsAndDisapears : MonoBehaviour {

	public List<GameObject> ToDestroy;

	// Use this for initialization
	void Start () {

		RemoveBlockHere ();
		Destroy (this.gameObject);
	}

	void RemoveBlockHere(){
		this.transform.localScale = Vector3.one * 0.5f;

		var ray = new Ray (this.transform.position + Vector3.right *5f,  Vector3.left);
		RaycastHit hit;
		
		if (Physics.Raycast (ray, out hit, 10f, 1 << LayerMask.NameToLayer ("floor"))) {
			Debug.Log ("Hit : " + hit.collider.gameObject);
			Destroy(hit.collider.gameObject);
		}

	}

	// Update is called once per frame
	void Update () {
	}
}
