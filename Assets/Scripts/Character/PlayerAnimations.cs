using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator animator;

    public void SitDown()
    {
        animator.Play("SittingDown");
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        gameObject.transform.position = gameObject.transform.position + new Vector3(0, 0, 1);
    }
    public void StandUp()
    {
        animator.Play("StandUp");
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
