using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AudioBehaviour : MonoBehaviour
{
    [SerializeField] AudioSource thunder;
    [SerializeField] AudioSource inside;
    [SerializeField] AudioSource outside;

    private void Start()
    {
        StartCoroutine(PlayThunder());
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Interior"))
        {
            inside.Play();
            outside.Stop();
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Exterior"))
        {
            inside.Stop();
            outside.Play();
        }
    }
    IEnumerator PlayThunder()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(30, 60));
            thunder.Play();
            Debug.Log("Trueno");
        }
    }
}
