using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Have object move back and forth in a line from starting position.
/// 
/// </summary>
public class SimplePace : MonoBehaviour
{
    public Vector3 EndPos;
    public float Period;

    // Start is called before the first frame update
    void Start()
    {
        Tween tween = transform.DOMove(EndPos, Period);
        tween.SetEase(Ease.InOutSine);
        tween.SetLoops(-1, LoopType.Yoyo);
    }
}
