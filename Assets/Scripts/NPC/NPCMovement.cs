using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCMovement : MonoBehaviour
{
    public LayerMask groundLayer;
    NavMeshAgent agent;
    private Transform player;
    public Animator animator;
    private bool is_running;
    private Rigidbody rb;
    private float currentspeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindAnyObjectByType<PlayerController>().transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        agent.SetDestination(player.position);

        animator.SetBool("IsRunning", is_running);
        currentspeed = agent.velocity.magnitude;
        animator.SetFloat("Speed", currentspeed);
        Debug.Log("NPC Speed: " + currentspeed);

        if (player.GetComponent<PlayerController>().isRunning())
        {
            is_running = true;
        }
        else
        {
            is_running = false;
        }
    }
}
