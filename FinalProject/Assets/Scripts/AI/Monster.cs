using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Monster : MonoBehaviour
{
    [SerializeField] private AudioSource m_sfxSource;

    [SerializeField] private AudioClip awake;
    [SerializeField] private AudioClip jumpscare;
    [SerializeField] private AudioClip warning;

    [SerializeField] private GameObject player;
    private GameObject target;

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;

    [SerializeField] private float moveSpeed = 3.5f;

    private bool hasSpottedPlayer = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player");

        agent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponentInChildren<Animator>();

        animator.SetTrigger("isWalking");
    }

    private void Start()
    {
        SoundManager.Instance.PlaySound(m_sfxSource, awake);

        target = player;
        agent.SetDestination(GameManager.Instance.waypoints[Random.Range(0, GameManager.Instance.waypoints.Count)].transform.position);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        DoBehavior();
    }

    private void OnTriggerEnter(Collider other)
    {
        Player playerScript = other.GetComponent<Player>();

        if (playerScript != null && !playerScript.isDead)
        {
            SoundManager.Instance.PlaySound(m_sfxSource, jumpscare);
            playerScript.Die(this.gameObject);
        }
    }

    public bool canSeeTarget()
    {
        RaycastHit raycastInfo;
        Vector3 rayToTarget = target.transform.position - this.transform.position;
        if (Physics.Raycast(this.transform.position, rayToTarget, out raycastInfo))
        {
            return raycastInfo.transform.gameObject.tag == "player";
        }

        return false;
    }

    public void Pursue()
    {
        if (!hasSpottedPlayer)
        {
            animator.SetTrigger("isRunning");
            SoundManager.Instance.PlaySound(m_sfxSource, warning);
            hasSpottedPlayer = true;
        }

        agent.speed = moveSpeed * 3f;

        Vector3 targetDirection = target.transform.position - this.transform.position;

        float lookAhead = targetDirection.magnitude / (agent.speed + player.GetComponent<Player>().CurrentSpeed);

        Seek(target.transform.position + target.transform.forward * lookAhead);
    }

    private void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }

    private void Wander()
    {
        if (agent.remainingDistance < 1)
        {
            ResetAgent();
            agent.SetDestination(GameManager.Instance.waypoints[Random.Range(0, GameManager.Instance.waypoints.Count)].transform.position);
        }
    }

    private void DoBehavior()
    {
        if (canSeeTarget())
        {
            Pursue();
        }
        else
        {
            Wander();
        }
    }

    private void ResetAgent()
    {
        hasSpottedPlayer = false;

        agent.speed = moveSpeed;

        animator.SetTrigger("isWalking");
        agent.ResetPath();
    }
}