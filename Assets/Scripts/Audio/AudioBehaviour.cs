using System.Collections;
using UnityEngine;

public class AudioBehaviour : MonoBehaviour
{
    [SerializeField] AudioSource thunder;

    private void Start()
    {
        StartCoroutine(PlayThunder());
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
