using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour
{
    [SerializeField] private AudioSource m_sfxSource;

    [SerializeField] private AudioClip collected;

    [SerializeField] private GameObject player;

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;

    [SerializeField] private float rotSpeed = 4;

    private bool isFollowingPlayer = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player");

        agent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();

        animator.SetTrigger("isIdling");
    }

    private void LateUpdate()
    {
        DoBehavior();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null && !isFollowingPlayer)
        {
            SoundManager.Instance.PlaySound(m_sfxSource, collected);

            isFollowingPlayer = true;
            agent.SetDestination(player.transform.position);

            animator.SetTrigger("isWalking");

            GameManager.Instance.AdvanceStage();
        }
    }

    private void DoBehavior()
    {
        LookAtGoal();

        if (!isFollowingPlayer) return;

        Seek(player.transform.position);
    }

    private void LookAtGoal()
    {
        Vector3 lookAtGoal = new Vector3(player.transform.position.x,
                                         this.transform.position.y,
                                         player.transform.position.z);

        Vector3 rotationDirection = lookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                   Quaternion.LookRotation(rotationDirection),
                                                   rotSpeed * Time.deltaTime);
    }

    private void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }
}