using UnityEngine;

public class PetMoveToGoal : MonoBehaviour
{
    public Transform goal;

    public float moveSpeed = 5;
    public float rotationSpeed = 4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x,
                                        this.transform.position.y,
                                        goal.position.z);

        Vector3 rotationDirection = lookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                   Quaternion.LookRotation(rotationDirection),
                                                   rotationSpeed * Time.deltaTime);

        Vector3 direction = goal.position - this.transform.position;

        if (Vector3.Distance(lookAtGoal, this.transform.position) > 2)
        {
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}