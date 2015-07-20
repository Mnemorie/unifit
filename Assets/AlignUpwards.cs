using UnityEngine;

public class AlignUpwards : MonoBehaviour
{
    Vector3 axis;

	void Start () 
    {
        axis = Vector3.left;
	}

    public float DebugAngle;

	void Update () 
    {
        float parentAngleToWorldUp = Vector3.Angle(transform.parent.forward, Vector3.up);
        if (Vector3.Cross(transform.parent.forward, Vector3.up).x < 0)
        {
            parentAngleToWorldUp = -parentAngleToWorldUp;
        }
        transform.localRotation = Quaternion.AngleAxis(parentAngleToWorldUp, axis);
	}
}
