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
        Neighbors = Scan(transform.position);
    }

    public static Dictionary<Direction, Node> Scan(Vector3 position)
    {
        Dictionary<Direction, Node> neighbors = new Dictionary<Direction, Node>();

        neighbors[Direction.Up] = Pick(position, Vector3.up);
        neighbors[Direction.Down] = Pick(position, -Vector3.up);
        neighbors[Direction.Left] = Pick(position, -Vector3.forward);
        neighbors[Direction.Right] = Pick(position, Vector3.forward);

        return neighbors;
    }

    public static Node Pick(Vector3 pos, Vector3 dir)
    {
        Ray ray = new Ray(pos, dir);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1, 1 << LayerMask.NameToLayer("players")))
        {
            return hit.collider.gameObject.GetComponent<Node>();
        }
        return null;
    }

    public bool HasForOnlyNeighbor(Node node)
    {
        List<Node> neighbors = GetNeighbors();
        if (neighbors.Count == 1 && neighbors[0] == node)
        {
            return true;
        }
        return false;
    }

    public List<Node> GetNeighbors()
    {
        List<Node> neighbors = new List<Node>(Neighbors.Values);
        neighbors.RemoveAll(n => n == null);

        return neighbors;
    }

    public static List<Node> GetNeighborsAt(Vector3 pos)
    {
        Dictionary<Node.Direction, Node> neighborMap = Scan(pos);
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
}
