using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Follows a path back and forth
/// </summary>
public class SimplePath : MonoBehaviour
{
    public Vector3[] EndPoints;
    public float Period;

    // Start is called before the first frame update
    void Start()
    {
        Tween tween = transform.DOPath(EndPoints, Period, PathType.CatmullRom);
        tween.SetEase(Ease.InOutSine);
        tween.SetLoops(-1, LoopType.Yoyo);
    }
}
