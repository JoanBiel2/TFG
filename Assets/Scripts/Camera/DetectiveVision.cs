using System.Collections;
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pi.actions["Vision"].WasPressedThisFrame())
        {
            visionActive = !visionActive;
            ChangeMaterials();
        }
        if (visionActive)
        {
            saturation = Mathf.Lerp(saturation, 0f, Time.deltaTime * 5);
        }
        else
        {
            saturation = Mathf.Lerp(saturation, 1f, Time.deltaTime * 5);
        }
        blackwhite.SetFloat("_Saturation", saturation);
    }
    public void ChangeVisionOn()
    {
        visionActive = true;
        ChangeMaterials();
    }
    public void ChangeVisionOff()
    {
        visionActive = false;
        ChangeMaterials();
    }
    public void ChangeMaterials()
    {
        if (renderers != null && renderers.Length > 0)
        {
            renderers = evidenceParent.GetComponentsInChildren<Renderer>();
            for (int i = 0; i < renderers.Length; i++)
            {
                if (renderers[i].gameObject.CompareTag("Image") || normalMaterial[i] == null)
                {
                    continue;
                }
                renderers[i].material = visionActive ? evidence : normalMaterial[i];
            }
        }
    }
}
