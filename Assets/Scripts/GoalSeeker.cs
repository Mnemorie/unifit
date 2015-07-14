using JetBrains.Annotations;
using UnityEngine;
using System.Collections;

public class GoalSeeker : MonoBehaviour 
{
    Transform EndGoal;

    public float DistanceFromCore = 5;

    private Camera Camera;

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

        Camera = FindObjectOfType<FollowsObject>().GetComponent<Camera>();
	}

    public float ClosestDistance = 5;
    public float MaxDistance = 25;

    public float MinSize = 5;
    public float MaxSize = 10;

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

        float distance = toEndGoal.magnitude;
        float ratio = Mathf.InverseLerp(ClosestDistance, MaxDistance, distance);

        Camera.orthographicSize = Mathf.Lerp(MinSize, MaxSize, ratio);
	}
}
