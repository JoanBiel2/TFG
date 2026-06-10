using System.Collections;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator animator;
    private CharacterController cc;
    private PlayerController playerController;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        playerController = GetComponent<PlayerController>();
    }

    public void SitDown()
    {
        animator.Play("SittingDown");
        playerController.enabled = false;
        transform.rotation = Quaternion.Euler(0, 180, 0);
        transform.position += new Vector3(0, 0, 1);
    }

    public void StandUp()
    {
        animator.Play("StandUp");
        playerController.enabled = true;
        transform.position += new Vector3(0, 0, -0.5f);
    }
}

