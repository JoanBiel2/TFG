using System.Collections;
using UnityEngine;


public class PoliceLights : MonoBehaviour
{
    public Light bluelight;
    public Light redlight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(PoliceLightsRoutine());
    }
    
    private IEnumerator PoliceLightsRoutine()
    {
        while(true)
    {
            bluelight.enabled = true;
            redlight.enabled = false;
            yield return new WaitForSeconds(0.7f);

            bluelight.enabled = false;
            redlight.enabled = true;
            yield return new WaitForSeconds(0.7f);
        }
    }
}
