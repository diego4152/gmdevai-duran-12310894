using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Side side;

    public GameObject explosion;

    public bool isFiredByPlayer;

    private void OnCollisionEnter(Collision col)
    {
        GameObject e = Instantiate(explosion, this.transform.position, Quaternion.identity);
        Destroy(e, 1.5f);
        Destroy(this.gameObject);
    }

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
}