using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject target; // for death sequence
    public bool isDead = false;

    [SerializeField] private GameObject mainCam;

    [SerializeField] private float moveSpeed = 5;
    private float currentMoveSpeed;

    private float maxStamina = 5;
    [SerializeField] private float stamina = 5;
    [SerializeField] private float rotSpeed = 2;

    private float deathTimer = 2;

    public float CurrentSpeed
    { get { return currentMoveSpeed; } }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

        currentMoveSpeed = moveSpeed;
        stamina = maxStamina;
    }

    // Update is called once per frame
    private void Update()
    {
        DoGetMeOuttaHere();
        DoDeathSequence();
    }

    private void LateUpdate()
    {
        if (isDead) return;

        DoRotation();
        DoMovement();
    }

    public void Die(GameObject setMeToTarget)
    {
        target = setMeToTarget;
        isDead = true;

        // This will make the player fall through the floor but that's actually intended.
        // It's funnier that way
        this.GetComponent<Collider>().enabled = false;
    }

    private void DoRotation()
    {
        // No vertical rotation because I am having a hard time programming it and honestly it makes me kinda motion sick
        float horizontal = rotSpeed * Input.GetAxis("Mouse X");

        transform.Rotate(0, horizontal, 0);
    }

    private void DoMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            this.stamina -= Time.deltaTime;
            this.currentMoveSpeed = moveSpeed * 2;

            UIManager.Instance.UpdateStaminaBar(stamina);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || stamina <= 0)
        {
            this.currentMoveSpeed = moveSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.Translate(Vector3.forward * currentMoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.Translate(Vector3.back * currentMoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Translate(Vector3.left * currentMoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Translate(Vector3.right * currentMoveSpeed * Time.deltaTime);
        }
    }

    private void DoGetMeOuttaHere()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            LevelManager.Instance.GoToLevel(0);
        }
    }

    private void DoDeathSequence()
    {
        if (!isDead) return;

        Vector3 lookAtGoal = new Vector3(target.transform.position.x,
                                         this.transform.position.y,
                                         target.transform.position.z);

        Vector3 rotationDirection = lookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                   Quaternion.LookRotation(rotationDirection),
                                                   rotSpeed * Time.deltaTime);

        deathTimer -= Time.deltaTime;

        if (deathTimer <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            LevelManager.Instance.GoToLevel(0);
        }
    }
}