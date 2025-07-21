using UnityEngine;

public class MoveToGoal : MonoBehaviour
{
    public Transform goal;

    public float moveSpeed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 direction = goal.position - this.transform.position;

        transform.LookAt(goal);

        if (direction.magnitude > 1)
        {
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}