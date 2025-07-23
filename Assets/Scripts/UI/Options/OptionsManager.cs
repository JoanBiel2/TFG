using Ink.Parsed;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audiomix;
    [SerializeField] private TMPro.TMP_Dropdown resdropdown;

    private Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resdropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);        
        }

        resdropdown.AddOptions(options);

    }

    public void SetAudio(float volume)
    {
        audiomix.SetFloat("volume", volume);
    }

    public void SetFullScreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void SetQuality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }
}
