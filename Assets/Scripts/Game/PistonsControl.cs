using UnityEngine;
using System.Collections;

public class PistonsControl : MonoBehaviour {


	public GameObject UpPiston;
	public KeyCode up;
	
	public GameObject RightPiston;
	public KeyCode right;
	
	public GameObject DownPiston;
	public KeyCode down;

	public GameObject LeftPiston;
	public KeyCode left;


	//public float recoilFactor;

	// Use this for initialization
	void Start () {
	
	}
	
	/*private void RecoilAwayFrom(Vector3 ThisPosition){
		this.transform.parent.GetComponent<Rigidbody>().AddForce((this.transform.position - ThisPosition).normalized * recoilFactor);

	}*/


	// Update is called once per frame

	void Update () {

		if (Input.GetKeyDown(up))
		{
			UpPiston.GetComponent<PistonMotion>().SetPushing();
			//RecoilAwayFrom(Vector3.up);
		}
		
		if (Input.GetKeyDown(right))
		{
			RightPiston.GetComponent<PistonMotion>().SetPushing();
			//RecoilAwayFrom(Vector3.right);
		}

		if (Input.GetKeyDown(down))
		{
			DownPiston.GetComponent<PistonMotion>().SetPushing();
			//RecoilAwayFrom(Vector3.down);
		}

		if (Input.GetKeyDown(left))
		{	
			LeftPiston.GetComponent<PistonMotion>().SetPushing();
			//RecoilAwayFrom(Vector3.left);
		}
	}
}
