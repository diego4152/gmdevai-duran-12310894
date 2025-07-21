using UnityEngine;

public class MoveToWASD : MonoBehaviour
{
    public float moveSpeed = 5;
    public float rotationSpeed = 4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        float horizontal = rotationSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, horizontal, 0);

        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }
}