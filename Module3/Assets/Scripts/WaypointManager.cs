using UnityEngine;

[System.Serializable]
public struct Link
{
    public enum direction
    { UNI, BI };

    public GameObject node1;
    public GameObject node2;

    public direction dir;
}

public class WaypointManager : MonoBehaviour
{
    public GameObject[] waypoints;

    public Link[] links;

    public Graph graph = new Graph();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if (waypoints.Length > 0)
        {
            foreach (GameObject up in waypoints)
            {
                graph.AddNode(up);
            }

            foreach (Link l in links)
            {
                graph.AddEdge(l.node1, l.node2);
                if (l.dir == Link.direction.BI)
                {
                    graph.AddEdge(l.node2, l.node1);
                }
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        graph.debugDraw();
    }
}