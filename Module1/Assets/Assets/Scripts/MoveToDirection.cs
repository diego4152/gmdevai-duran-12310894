using UnityEngine;

public class MoveToDirection : MonoBehaviour
{
    public Vector3 direction = new Vector3(8, 0, 4);

    public float moveSpeed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
    }
}