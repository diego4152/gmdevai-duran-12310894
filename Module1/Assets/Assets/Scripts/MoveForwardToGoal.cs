using UnityEngine;

public class MoveForwardToGoal : MonoBehaviour
{
    public Transform goal;

    public float moveSpeed = 5;
    public float rotationSpeed = 4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x,
                                        this.transform.position.y,
                                        goal.position.z);

        Vector3 direction = lookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                   Quaternion.LookRotation(direction),
                                                   rotationSpeed * Time.deltaTime);

        if (Vector3.Distance(lookAtGoal, this.transform.position) > 1)
        {
            transform.Translate(0, 0, moveSpeed * Time.deltaTime, Space.World);
        }
    }
}