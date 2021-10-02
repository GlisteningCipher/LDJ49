using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactVFX : MonoBehaviour
{
    ParticleSystem ps;

    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void PlayImpactFX(Vector2 position, float rotation, float scale)
    {
        transform.position = position;
        transform.localEulerAngles = new Vector3(0, 0, rotation);
        transform.localScale = new Vector3(scale, scale, 1);
        StartCoroutine(PlayFX());
    }

    IEnumerator PlayFX()
    {
        ps.Play();
        yield return new WaitUntil(() => !ps.isPlaying);
        Destroy(gameObject);
    }
}
