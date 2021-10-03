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
        dropdown.ClearOptions();
        dropdown.AddOptions(settings.resolutionStrings);
        dropdown.value = settings.resolutionStrings.IndexOf(Screen.width + "x" + Screen.height);
        dropdown.onValueChanged.AddListener(settings.SetResolution);
    }
}
