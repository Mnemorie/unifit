using UnityEngine;
using System.Collections.Generic;

public class Motor : MonoBehaviour 
{
    public static bool IsAnybodyMoving = false;
    public bool IsMoving = false;

    public float Speed = 10f;

    private Vector3 TargetPosition;
    private Vector3 IntermediatePosition;

    private float actualSpeed;

    void Start()
    {
        IsAnybodyMoving = false;
    }

    public void Move(Vector3 motion)
    {
        Move(motion, Vector3.zero);
    }

    public void Move(Vector3 motion1, Vector3 motion2)
    {
        if (IsMoving)
        {
            Debug.LogError("cannot move on moving motor");
            return;
        }

        IsMoving = true;
        IsAnybodyMoving = true;

        if (motion2 == Vector3.zero)
        {
            IntermediatePosition = Vector3.zero;
            TargetPosition = transform.localPosition + motion1;
        }
        else
        {
            IntermediatePosition = transform.localPosition + motion1;
            TargetPosition = IntermediatePosition + motion2;
        }

        actualSpeed = Speed * 2;
    }

    void FixedUpdate()
    {
        if (IsMoving)
        {
            Vector3 target = IntermediatePosition != Vector3.zero ? IntermediatePosition : TargetPosition;

            float delta = actualSpeed * Time.fixedDeltaTime;
            if (delta >= Vector3.Distance(transform.localPosition, target))
            {
                transform.localPosition = target;

                if (IntermediatePosition != Vector3.zero)
                {
                    IntermediatePosition = Vector3.zero;
                }
                else
                {
                    Node.RefreshAll();
                    IsMoving = false;
                    IsAnybodyMoving = false;
                }
            }
            else
            {
                transform.Translate((target - transform.localPosition).normalized * delta, Space.Self);
            }
        }
    }
}
