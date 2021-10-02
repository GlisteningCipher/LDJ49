using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] string volumeName;

    void Start()
    {
        Slider slider = GetComponent<Slider>();
        slider.minValue = -80;
        slider.maxValue = 0;
        slider.value = GetVolume();
        slider.onValueChanged.AddListener(SetVolume);
    }

    float GetVolume()
    {
        mixer.GetFloat(volumeName, out float volume);
        return volume;
    }

    void SetVolume(float volume)
    {
        mixer.SetFloat(volumeName, volume);
    }

}
