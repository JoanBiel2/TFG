using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, DataPersistance
{
    private float walk = 5f;
    private float run = 15f;
    private CharacterController cc;
    private PlayerInput pi;
    private Vector2 input;
    public Animator animator;
    bool is_running;

    private float yVelocity;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        pi = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        input = pi.actions["Move"].ReadValue<Vector2>();
        is_running = pi.actions["Sprint"].IsPressed();
        animator.SetBool("IsRunning", is_running);

        Move();
    }

    private void Move()
    {
        float speed = is_running ? run : walk;

        Vector3 move = new Vector3(input.x, 0f, input.y);
        Vector3 moveDir = move.normalized;
        if (moveDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
        if (cc.isGrounded && yVelocity < 0)
        {
            yVelocity = -2f;
        }
        else
        {
            yVelocity += Physics.gravity.y * Time.deltaTime;
        }
        Vector3 velocity = moveDir * speed;
        velocity.y = yVelocity;

        cc.Move(velocity * Time.deltaTime);

        float currentSpeed = new Vector3(cc.velocity.x, 0, cc.velocity.z).magnitude;
        animator.SetFloat("Speed", currentSpeed);
    }

    public void LoadData(GameData data)
    {
        cc.enabled = false;
        transform.position = data.playerpos;
        cc.enabled = true;
    }

    public void SaveData(ref GameData data)
    {
        data.playerpos = transform.position;
    }

    public bool isRunning()
    {
        return is_running;
    }
}
