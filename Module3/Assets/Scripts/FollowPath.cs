using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public Transform goal;

    public float speed = 5f;
    public float accuracy = 1f;

    public float rotationSpeed = 2f;

    public GameObject wpManager;

    private GameObject[] wps;
    private GameObject currentNode;
    private int currentWaypointIndex = 0;

    private Graph graph;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        graph = wpManager.GetComponent<WaypointManager>().graph;
        currentNode = wps[0];
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (graph.getPathLength() == 0 || currentWaypointIndex == graph.getPathLength())
        {
            return;
        }

        currentNode = graph.getPathPoint(currentWaypointIndex);

        if (Vector3.Distance(graph.getPathPoint(currentWaypointIndex).transform.position,
                             transform.position) < accuracy)
        {
            currentWaypointIndex++;
        }

        if (currentWaypointIndex < graph.getPathLength())
        {
            goal = graph.getPathPoint(currentWaypointIndex).transform;

            Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                       Quaternion.LookRotation(direction),
                                                       rotationSpeed * Time.deltaTime);

            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    public void GoToNode(int index)
    {
        graph.AStar(currentNode, wps[index]);
        currentWaypointIndex = 0;
    }
}