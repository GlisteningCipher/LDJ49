using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Have object rotate between angles.
/// </summary>
public class SimpleRotate : MonoBehaviour
{
    public Vector3 EndAngle;
    public float Period;

    // Start is called before the first frame update
    void Start()
    {
        Tween tween = transform.DORotate(EndAngle, Period);
        tween.SetEase(Ease.InOutSine);
        tween.SetLoops(-1, LoopType.Yoyo);
    }
}
