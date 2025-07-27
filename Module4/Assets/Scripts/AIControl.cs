using Unity.VisualScripting;
using UnityEngine;

public class AIControl : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        this.agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
}