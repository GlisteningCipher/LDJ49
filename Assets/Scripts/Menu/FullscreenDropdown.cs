using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[RequireComponent(typeof(TMP_Dropdown))]
public class FullscreenDropdown : MonoBehaviour
{
    [SerializeField] SettingsSO settings;

    enum FullScreenLabel { FullScreen, Borderless, Maximized, Windowed } //rename FullScreenMode values

    void Start()
    {
        TMP_Dropdown dropdown = GetComponent<TMP_Dropdown>();

        dropdown.ClearOptions();
        dropdown.AddOptions(new List<string>(Enum.GetNames(typeof(FullScreenLabel))));
        dropdown.value = (int)Screen.fullScreenMode;
        dropdown.onValueChanged.AddListener(settings.SetFullScreen);
    }
}
