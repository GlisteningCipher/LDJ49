using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using DG.Tweening;


public class DayNightCycle : MonoBehaviour
{
    [SerializeField] LightColors dayLights;
    [SerializeField] LightColors nightLights;

    [SerializeField] Light2D ambient;
    [SerializeField] Light2D directional;

    [SerializeField] SpriteRenderer dayBG;

    [SerializeField] ParticleSystem rain;
    [SerializeField] float maxRain = 80;
    [SerializeField] AudioSource rainSFX;
    [SerializeField] float dayLength = 20f;

    public bool isDay;

    private void Start()
    {
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        while (true)
        {
            isDay = true;
            dayBG.color = Color.white;
            ambient.color = dayLights.ambient;
            directional.color = dayLights.directional;

            if (rain.isPlaying) rain.Stop();
            rainSFX.volume = 0;

            yield return new WaitForSeconds(dayLength/2);

            dayBG.DOFade(0, 5f);
            DOTween.To(() => ambient.color, x => ambient.color = x, nightLights.ambient, 5f).SetEase(Ease.InOutSine);
            DOTween.To(() => directional.color, x => directional.color = x, nightLights.directional, 5f).SetEase(Ease.InOutSine);

            rain.Play();

            rainSFX.DOFade(0.5f, 5f).SetEase(Ease.InOutSine);
            rainSFX.Play();

            isDay = false;

            yield return new WaitForSeconds(dayLength / 2);

            dayBG.DOFade(1, 5f);
            DOTween.To(() => ambient.color, x => ambient.color = x, dayLights.ambient, 5f).SetEase(Ease.InOutSine);
            DOTween.To(() => directional.color, x => directional.color = x, dayLights.directional, 5f).SetEase(Ease.InOutSine);

            rainSFX.DOFade(0, 2f).SetEase(Ease.InOutSine);

            yield return new WaitForSeconds(5f);

            rain.Stop();
            rainSFX.Stop();
        }
        
    }


    [System.Serializable]
    struct LightColors
    {
        public Color ambient;
        public Color directional;
    }
}
