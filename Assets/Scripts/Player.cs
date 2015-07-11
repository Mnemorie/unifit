using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public KeyCode ControlLeft;
    public KeyCode ControlRight;
    public KeyCode ControlUp;
    public KeyCode ControlDown;

    private Node Node;
    private Motor Motor;

	void Start () 
    {
        Node = GetComponent<Node>();
        Motor = GetComponent<Motor>();
	}

    void Update () 
    {
        if (Motor.IsAnybodyMoving)
        {
            return;
        }

	    if (Input.GetKeyDown(ControlLeft))
        {
            Move(Vector3.back);
        }

        if (Input.GetKeyDown(ControlRight))
        {
            Move(Vector3.forward);
        }

        if (Input.GetKeyDown(ControlUp))
        {
            Move(Vector3.up);
        }

        if (Input.GetKeyDown(ControlDown))
        {
            Move(Vector3.down);
        }
	}

    void Move(Vector3 motion)
    {
        if (Node.Pick(transform.position, motion) != null)
        {
            Debug.LogWarning("NOPE: there is someone there already");
            return;
        }

        foreach (Node n in Node.GetNeighbors())
        {
            if (n.HasForOnlyNeighbor(Node))
            {
                Debug.LogWarning("NOPE: this would orphan a node");
                return;
            }
        }

        if (Node.GetNeighborsAt(transform.position + motion).Count == 1)
        {
            Vector3 diagMotion = SolveDiagonal(motion);

            if (diagMotion == Vector3.zero)
            {
                Debug.LogWarning("NOPE: there is nobody to stay connected to");
                return;
            }

            motion += diagMotion;
        }

        Motor.Move(motion);
    }

    Vector3 SolveDiagonal(Vector3 motion)
    {
        if (Mathf.Abs(motion.z) > 0)
        {
            Node rotationRoot = Node.Pick(transform.position, -Vector3.up);
            if (rotationRoot != null && rotationRoot.GetNeighbors().Count > 1)
            {
                return -Vector3.up;
            }
            rotationRoot = Node.Pick(transform.position, Vector3.up);
            if (rotationRoot != null && rotationRoot.GetNeighbors().Count > 1)
            {
                return Vector3.up;
            }
        }
        else
        {
            Node rotationRoot = Node.Pick(transform.position, -Vector3.forward);
            if (rotationRoot != null && rotationRoot.GetNeighbors().Count > 1)
            {
                return -Vector3.forward;
            }
            rotationRoot = Node.Pick(transform.position, Vector3.forward);
            if (rotationRoot != null && rotationRoot.GetNeighbors().Count > 1)
            {
                return Vector3.forward;
            }  
        }

        //List<Node> neighbors = Node.GetNeighborsAt(transform.position + motion + diagonalAlteration);
        //if (neighbors.Count > 0 && neighbors)
        //{
        //    transform.Translate(motion + Vector3.forward, Space.World);
        //    return;
        //}
        //if (Node.GetNeighborsAt(transform.position + motion + Vector3.back).Count > 0)
        //{
        //    transform.Translate(motion + Vector3.back, Space.World);
        //    return;
        //}

        return Vector3.zero;
    }
}
