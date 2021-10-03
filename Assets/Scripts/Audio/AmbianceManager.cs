using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AmbianceManager : MonoBehaviour
{
    [SerializeField] AudioSource seagullsSFX;
    [SerializeField] AudioSource honkSFX;

    private void Start()
    {
        StartAmbiance();
    }

    public void StartAmbiance()
    {
        StartCoroutine(AmbianceLoop());
    }

    public void StopAmbiance()
    {
        StopAllCoroutines();
        StartCoroutine(AmbianceFadeOutAndStop());
    }

    IEnumerator AmbianceLoop()
    {
        seagullsSFX.volume = 0;
        seagullsSFX.Play();
        seagullsSFX.DOFade(1f, 10f).SetEase(Ease.InOutSine);

        yield return new WaitForSeconds(20f);

        honkSFX.Play();

        yield return new WaitForSeconds(18f);

        seagullsSFX.DOFade(0f, 1f).SetEase(Ease.InOutSine);

        yield return new WaitForSeconds(1f);

        seagullsSFX.Stop();

        seagullsSFX.volume = 0;

        while (true)
        {
            seagullsSFX.Play();
            seagullsSFX.DOFade(1f, 2f).SetEase(Ease.InOutSine);

            yield return new WaitForSeconds(15f);

            honkSFX.Play();

            yield return new WaitForSeconds(15f);

            seagullsSFX.DOFade(0f, 1f).SetEase(Ease.InOutSine);

            yield return new WaitForSeconds(1f);

            seagullsSFX.Stop();

            seagullsSFX.volume = 0;
        }
    }

    IEnumerator AmbianceFadeOutAndStop()
    {
        if(seagullsSFX.isPlaying)
        {
            seagullsSFX.DOFade(0f, 1f).SetEase(Ease.InOutSine);
            yield return new WaitForSeconds(1f);
            seagullsSFX.Stop();
        }
    }
}
