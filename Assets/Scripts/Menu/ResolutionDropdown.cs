using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Dropdown))]
public class ResolutionDropdown : MonoBehaviour
{
    [SerializeField] SettingsSO settings;

    void Start()
    {
        TMP_Dropdown dropdown = GetComponent<TMP_Dropdown>();
        List<string> resolutionStrings = new List<string>();

        foreach (Resolution res in settings.resolutions)
            resolutionStrings.Add(res.width + "x" + res.height);
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutionStrings);
        dropdown.value = resolutionStrings.IndexOf(Screen.width + "x" + Screen.height);
        dropdown.onValueChanged.AddListener(settings.SetResolution);
    }
}
