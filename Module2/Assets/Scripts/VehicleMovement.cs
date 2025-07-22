using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public Transform goal;

    public float speed = 20;
    public float rotationSpeed = 15;

    public float acceleration = 5;
    public float deceleration = 5;

    public float minSpeed = 0;
    public float maxSpeed = 20;

    public float brakeAngle = 20;

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

        Vector3 direction = lookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                   Quaternion.LookRotation(direction),
                                                   rotationSpeed * Time.deltaTime);

        //speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);

        if (Vector3.Angle(goal.forward, this.transform.forward) > brakeAngle && speed > 50)
        {
            speed = Mathf.Clamp(speed - (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        else
        {
            speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}