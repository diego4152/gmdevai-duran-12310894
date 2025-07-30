using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side
{
    Player,
    Enemy
}

public class Health : MonoBehaviour
{
    public Side side;
    public float health;

    private void OnCollisionEnter(Collision collision)
    {
        Bullet shell = collision.gameObject.GetComponent<Bullet>();

        if (shell != null && shell.side != this.side)
        {
            TakeDamage(10);
        }
    }

    private void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}