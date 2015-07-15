using UnityEngine;
using System.Collections;

public class FollowsObject : MonoBehaviour 
{
	public Vector3 offSet;
	public Vector2 responsiveness;

    Transform FollowThis;
    Transform EndGoal;

    public float BaseHeight = 3;

	// Use this for initialization
	void Start () 
    {
        FollowThis = FindObjectOfType<Core>().transform;
        EndGoal = FindObjectOfType<EndsLevel>().transform;
    }
	
	// Update is called once per frame
	void LateUpdate () 
    {
	    if (FollowThis == null)
	    {
            FollowThis = FindObjectOfType<Core>().transform;
            EndGoal = FindObjectOfType<EndsLevel>().transform;
            return;
	    }

        offSet.y = BaseHeight + ((EndGoal.position.y - FollowThis.transform.position.y) * 0.25f);
        offSet.z = (EndGoal.position.z - FollowThis.transform.position.z) * 0.25f;

		//this.transform.position = Vector3.Lerp(this.transform.position, followThis.transform.position + offSet, responsiveness );
		this.transform.position = new Vector3(
			transform.position.x,
            Mathf.Lerp(this.transform.position.y, FollowThis.transform.position.y + offSet.y, responsiveness.y),
            FollowThis.transform.position.z + offSet.z);
		//this.transform.position.y = Mathf.Lerp(this.transform.position.y, followThis.transform.position.y + offSet.y, responsiveness.y );
		//this.transform.position.z = followThis.transform.position + offSet.z;
		//this.transform.position = new Vector3(this.transform.position.x, offSet.y, this.transform.position.z ); 
	}
}
