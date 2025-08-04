using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, DataPersistance
{
    private float walk = 5f;
    private float run = 15f;
    private Rigidbody rb;
    private PlayerInput pi;
    private Vector2 input;
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
    }
    private void FixedUpdate()
    {
        float speed = is_running ? run : walk;
        Vector3 move = new Vector3(input.x, 0f, input.y);
        Vector3 moveDir = move.normalized;

        rb.linearVelocity = moveDir * speed;

        if (moveDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
    }
    public void LoadData(GameData data)
    {
        rb.position = data.playerpos;
    }



    public void SaveData(ref GameData data)
    {
        Debug.Log("PlayerController: Guardando posición: " + transform.position);
        data.playerpos = transform.position;
    }


}

