using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class Node : MonoBehaviour 
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public Dictionary<Direction, Node> Neighbors;

	void Start () 
    {
        RefreshNeighbors();
	}

    public void RefreshNeighbors()
    {
        Neighbors = Scan(transform, Vector3.zero);
    }

    public static Dictionary<Direction, Node> Scan(Transform trf, Vector3 offset)
    {
        Dictionary<Direction, Node> neighbors = new Dictionary<Direction, Node>();

        neighbors[Direction.Up] = PickNode(trf, offset, Vector3.up);
        neighbors[Direction.Down] = PickNode(trf, offset, -Vector3.up);
        neighbors[Direction.Left] = PickNode(trf, offset, -Vector3.forward);
        neighbors[Direction.Right] = PickNode(trf, offset, Vector3.forward);

        return neighbors;
    }

    public static Node PickNode(Transform trf, Vector3 offset, Vector3 dir)
    {
        Ray ray = new Ray(trf.position + offset, trf.TransformDirection(dir));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1, 1 << LayerMask.NameToLayer("players")))
        {
            return hit.collider.gameObject.GetComponent<Node>();
        }
        return null;
    }

    public static bool PickFloor(Transform trf, Vector3 offset, Vector3 dir)
    {
        Ray ray = new Ray(trf.position + offset, trf.TransformDirection(dir));
        RaycastHit hit;

        return Physics.Raycast(ray, out hit, 1.4f, 1 << LayerMask.NameToLayer("floor"));
    }

    public static bool PickFloorWithDistance(Transform trf, Vector3 offset, Vector3 dir, out float distance)
    {
        Ray ray = new Ray(trf.position + offset, trf.TransformDirection(dir));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1.4f, 1 << LayerMask.NameToLayer("floor")))
        {
            distance = hit.distance;
            return true;
        }

        distance = -1f;
        return false;
    }

    public bool IsConnectedToCoreBy(Node node)
    {
        List<Node> graph = new List<Node>();
        List<Node> traversed = new List<Node>();
        CollectConnectedNodes(this, traversed, graph, node);

        foreach (Node n in graph)
        {
            if (n.GetComponent<Core>())
            {
                return false;
            }
        }

        return true;
    }

    void CollectConnectedNodes(Node node, List<Node> traversed, List<Node> results, Node ignore)
    {
        if (node == ignore || traversed.Contains(node))
        {
            return;
        }

        results.Add(node);
        traversed.Add(node);

        List<Node> neighbors = node.GetNeighbors();
        foreach (Node neighbor in neighbors)
        {
            if (neighbor != ignore && !results.Contains(neighbor))
            {
                CollectConnectedNodes(neighbor, traversed, results, ignore);
            }
        }
    }

    public List<Node> GetNeighbors()
    {
        List<Node> neighbors = new List<Node>(Neighbors.Values);
        neighbors.RemoveAll(n => n == null);

        return neighbors;
    }

    public static List<Node> GetNeighborsAt(Transform trf, Vector3 offset)
    {
        Dictionary<Node.Direction, Node> neighborMap = Scan(trf, trf.TransformDirection(offset));
        List<Node> neighbors = new List<Node>(neighborMap.Values);
        neighbors.RemoveAll(n => n == null);
        return neighbors;
    }

    public int GetNeighborCount()
    {
        int neighborCount = 0;
        foreach (Node n in Neighbors.Values)
        {
            if (n != null)
            {
                neighborCount++;
            }
        }

        return neighborCount;
    }

    public static void RefreshAll()
    {
        foreach (Node n in FindObjectsOfType<Node>())
        {
            n.RefreshNeighbors();
        }
    }

    //void OnDrawGizmos()
    //{
    //    if (gameObject.name == "player1")
    //    {
    //        if (Neighbors != null)
    //        {
    //            foreach (Node n in GetNeighbors())
    //            {
    //                Gizmos.DrawLine(transform.position + Vector3.right, n.transform.position + Vector3.right);
    //                // Gizmos.DrawLine(transform.position + Vector3.right, n.storedOffset + Vector3.right);
    //            }
    //        }
            
    //    }
    //}
}
