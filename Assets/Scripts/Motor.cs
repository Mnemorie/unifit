using UnityEngine;
using System.Collections.Generic;

public class Motor : MonoBehaviour 
{
    public static bool IsAnybodyMoving = false;
    public bool IsMoving = false;

    public float Speed = 10f;

    private Vector3 TargetPosition;

    public void Move(Vector3 motion)
    {
        if (IsMoving)
        {
            Debug.LogError("cannot move on moving motor");
        }

        IsMoving = true;
        IsAnybodyMoving = true;
        TargetPosition = transform.position + motion;
    }

    void FixedUpdate()
    {
        if (IsMoving)
        {
            float delta = Speed * Time.fixedDeltaTime;
            if (delta >= Vector3.Distance(transform.position, TargetPosition))
            {
                transform.position = TargetPosition;
                Node.RefreshAll();
                IsMoving = false;
                IsAnybodyMoving = false;
            }
            else
            {
                transform.Translate((TargetPosition - transform.position).normalized * delta, Space.World);
            }
        }
    }
}
