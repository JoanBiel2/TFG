using System.Collections;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    private Light lightSource;

    [Header("Intensity")]
    public float normalIntensity = 1f;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.5f;

    [Header("Timing")]
    public float stableTime = 2f;
    public float flickerDuration = 0.3f;
    public float flickerSpeed = 0.05f;

    public float minRandomWait = 1f;
    public float maxRandomWait = 5f;

    [Header("ParticleSystem")]
    public ParticleSystem flickerParticles;

    void Start()
    {
        lightSource = GetComponent<Light>();
        StartCoroutine(FlickerRoutine());
    }

    IEnumerator FlickerRoutine()
    {
        while (true)
        {
            lightSource.intensity = normalIntensity;
            yield return new WaitForSeconds(stableTime);

            float randomWait = Random.Range(minRandomWait, maxRandomWait);
            yield return new WaitForSeconds(randomWait);

            float timer = 0f;

            while (timer < flickerDuration)
            {
                lightSource.intensity = Random.Range(minIntensity, maxIntensity);
                if (flickerParticles != null)
                {
                    flickerParticles.Play();
                }   
                timer += flickerSpeed;
                yield return new WaitForSeconds(flickerSpeed);
            }
            if (flickerParticles != null)
            {
                flickerParticles.Stop();
            }
            lightSource.intensity = normalIntensity;
        }
    }
}