using UnityEngine;
using System.Collections;

public class FollowsObject : MonoBehaviour 
{
	public Vector3 offset;
	public Vector2 responsiveness;
    public float offsetRatio = 0.25f;

    Transform FollowThis;
    Transform EndGoal;

    public float BaseHeight = 3;

	// Use this for initialization
	void Start () 
    {
        Core c = FindObjectOfType<Core>();
        if (c)
        {
            FollowThis = c.transform;
        }

        EndsLevel e = FindObjectOfType<EndsLevel>();
        if (e)
        {
            EndGoal = e.transform;
        }
    }
	
	// Update is called once per frame
	void LateUpdate () 
    {
	    if (FollowThis == null)
	    {
            return;
	    }

        offset.y = BaseHeight + ((EndGoal.position.y - FollowThis.transform.position.y) * offsetRatio);
        offset.z = (EndGoal.position.z - FollowThis.transform.position.z) * offsetRatio;

		//this.transform.position = Vector3.Lerp(this.transform.position, followThis.transform.position + offset, responsiveness );
		this.transform.position = new Vector3(
			transform.position.x,
            Mathf.Lerp(this.transform.position.y, FollowThis.transform.position.y + offset.y, responsiveness.y),
            FollowThis.transform.position.z + offset.z);
		//this.transform.position.y = Mathf.Lerp(this.transform.position.y, followThis.transform.position.y + offset.y, responsiveness.y );
		//this.transform.position.z = followThis.transform.position + offset.z;
		//this.transform.position = new Vector3(this.transform.position.x, offset.y, this.transform.position.z ); 
	}
}
