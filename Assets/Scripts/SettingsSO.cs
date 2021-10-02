using UnityEngine;

[CreateAssetMenu(fileName = "Settings Manager", menuName = "Managers/Settings Manager", order = 2)]
public class SettingsSO : ScriptableObject
{
    public Resolution[] resolutions;

    void OnEnable()
    {
        resolutions = Screen.resolutions;
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
