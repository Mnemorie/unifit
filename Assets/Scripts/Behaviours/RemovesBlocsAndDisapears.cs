using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RemovesBlocsAndDisapears : MonoBehaviour {

	public List<GameObject> ToDestroy;

	// Use this for initialization
	void Start () {
		if (ToDestroy == null)
			return; 	
		foreach (GameObject go in ToDestroy) {
			Destroy(go);
			Destroy(this.gameObject);
		}
			
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
