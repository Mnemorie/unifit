using UnityEngine;
using System.Collections;

public class GoalSeeker : MonoBehaviour 
{
    Transform EndGoal;

    public float DistanceFromCore = 5;

	// Use this for initialization
	void Start () 
    {
        EndsLevel ends = FindObjectOfType<EndsLevel>();
        if (ends)
        {
            EndGoal = ends.transform;
        }
        else
        {
            gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 toEndGoal = (EndGoal.position - transform.parent.position);
        if (toEndGoal.magnitude > DistanceFromCore)
        {
            transform.position = transform.parent.position + (toEndGoal.normalized * DistanceFromCore);
            transform.LookAt(EndGoal);
        }
        else
        {
            transform.position = EndGoal.position;
        }

	}
}
