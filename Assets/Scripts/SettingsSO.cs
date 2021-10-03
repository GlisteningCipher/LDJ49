using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Settings Manager", menuName = "Managers/Settings Manager", order = 2)]
public class SettingsSO : ScriptableObject
{
    [HideInInspector] public List<Resolution> resolutions;
    [HideInInspector] public List<string> resolutionStrings;

    void OnEnable()
    {
        resolutions = new List<Resolution>();
        resolutionStrings = new List<string>();
        GetResolutions();
    }

    void GetResolutions()
    {
        foreach (Resolution res in Screen.resolutions)
        {
            string key = res.width + "x" + res.height;
            if (!resolutionStrings.Contains(key))
            {
                resolutions.Add(res);
                resolutionStrings.Add(key);
            }
        }
    }

    public void SetResolution(int index)
    {
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreenMode);
    }

    public void SetFullScreen(int mode)
    {
        Screen.SetResolution(Screen.width, Screen.height, (FullScreenMode)mode);
    }
}
