using UnityEngine;
using System.Collections;
using TMPro;

public class DropDownOptions : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    IEnumerator Start()
    {
        // Espera hasta que OptionsManager esté inicializado
        while (OptionsManager.instance == null || !OptionsManager.instance.IsInitialized)
        {
            yield return null;
        }

        OptionsManager.instance.RegisterDropdown(resolutionDropdown);
    }
}
