using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DetectiveVision : MonoBehaviour
{
    private PlayerInput pi;
    private float saturation = 1f;
    public Material blackwhite;
    public Material evidence;
    public GameObject evidenceParent;
    private Material[] normalMaterial;
    Renderer[] renderers;
    private bool visionActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pi = FindAnyObjectByType<PlayerInput>();
        blackwhite.SetFloat("_Saturation", saturation);
        renderers = evidenceParent.GetComponentsInChildren<Renderer>();
        normalMaterial = new Material[renderers.Length];
        for (int i = 0; i <  renderers.Length; i++)
        {
            if (!renderers[i].CompareTag("Image"))
                normalMaterial[i] = renderers[i].material;
            else
            {
                Debug.Log("Material " + i + " es una imagen, se ignora.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool pressed = pi.actions["Vision"].IsPressed();
        if (pressed)
        {
            saturation = Mathf.Lerp(saturation, 0f, Time.deltaTime * 5);
        }
        else
        {
            saturation = Mathf.Lerp(saturation, 1f, Time.deltaTime * 5);
        }
        blackwhite.SetFloat("_Saturation", saturation);

        if (pressed != visionActive)
        {
            visionActive = pressed;
            if (renderers != null || renderers.Length > 0)
            {
                for (int i = 0; i < renderers.Length; i++)
                {
                    if (renderers[i].gameObject.CompareTag("Image") || normalMaterial[i] == null)
                        continue;

                    renderers[i].material = visionActive ? evidence : normalMaterial[i];
                }
            }
        }
    }
}
