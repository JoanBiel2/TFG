using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsManager : MonoBehaviour
{
    public static OptionsManager instance;

    [SerializeField] private AudioMixer audiomix;
    [SerializeField] private TMPro.TMP_Dropdown resdropdown;
    private int currentresolutionindex = 0;
    public bool IsInitialized { get; private set; } = false;

    private Resolution[] resolutions;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);

            resolutions = Screen.resolutions;
            IsInitialized = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (resdropdown != null)
        {
            InitializeDropdown(resdropdown);
        }
    }

    private void InitializeDropdown(TMPro.TMP_Dropdown dropdown)
    {
        dropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentresolutionindex = i;
            }
        }

        dropdown.AddOptions(options);
        dropdown.value = currentresolutionindex;
        dropdown.RefreshShownValue();
        dropdown.onValueChanged.AddListener(SetResolution);

        // Guardamos para aplicar si lo necesitas más tarde
        resdropdown = dropdown;

        // Aplica la resolución actual
        SetResolution(currentresolutionindex);
    }

    public void RegisterDropdown(TMPro.TMP_Dropdown dropdown)
    {
        InitializeDropdown(dropdown);
    }

    public Resolution[] GetResolutions() => resolutions;

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

    public void SetResolution(int index)
    {
        if (resolutions == null || resolutions.Length == 0)
        {
            Debug.LogWarning("Resolutions not initialized.");
            return;
        }

        if (index < 0 || index >= resolutions.Length)
        {
            Debug.LogWarning("Invalid resolution index: " + index);
            return;
        }

        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
