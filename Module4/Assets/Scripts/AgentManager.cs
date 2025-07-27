using UnityEngine;

public class AgentManager : MonoBehaviour
{
    private GameObject player;
    private GameObject[] agents;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("AI");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        foreach (GameObject ai in agents)
        {
            ai.GetComponent<AIControl>().agent.SetDestination(player.transform.position);
        }
    }
}