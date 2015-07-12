using UnityEngine;
using System.Collections;

public class BecomesInvisibleOnPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<MeshRenderer> ().enabled = false;


	}
	

}
