using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, DataPersistance
{
    private float walk = 5f;
    private float run = 15f;
    private Rigidbody rb;
    private PlayerInput pi;
    private Vector2 input;
    public Animator animator;
    bool is_running;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pi = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    private void Update()
    {
        input = pi.actions["Move"].ReadValue<Vector2>();
        is_running = pi.actions["Sprint"].IsPressed();
        animator.SetBool("IsRunning", is_running);
    }
    private void FixedUpdate()
    {
        float speed = is_running ? run : walk;
        Vector3 move = new Vector3(input.x, 0f, input.y);
        Vector3 moveDir = move.normalized;

        Vector3 velocity = rb.linearVelocity;
        velocity.x = moveDir.x * speed;
        velocity.z = moveDir.z * speed;
        rb.linearVelocity = velocity;

        float currentspeed = rb.linearVelocity.magnitude;
        animator.SetFloat("Speed", currentspeed);

        if (moveDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
    }
    public void LoadData(GameData data)
    {
        rb.isKinematic = true; // Evita que la física lo empuje antes de tiempo
        rb.position = data.playerpos;
        rb.isKinematic = false;
    }

    public void SaveData(ref GameData data)
    {
        data.playerpos = transform.position;
    }



}

