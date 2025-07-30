using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    private Animator anim;

    private Health hp;

    public GameObject player;

    public GameObject bullet;
    public GameObject turret;

    public GameObject GetPlayer()
    {
        return player;
    }

    // Start is called before the first frame update
    private void Start()
    {
        anim = this.GetComponent<Animator>();
        hp = this.GetComponent<Health>();
    }

    // Update is called once per frame
    private void Update()
    {
        anim.SetFloat("distance", Vector3.Distance(this.transform.position, player.transform.position));
        anim.SetFloat("health", hp.health);
    }

    private void Fire()
    {
        Debug.Log("bshghsg");
        GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        b.GetComponent<Bullet>().side = Side.Enemy;
        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
    }

    public void StopFiring()
    {
        CancelInvoke("Fire");
    }

    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 0.5f);
    }
}