using UnityEngine;
using System.Collections;

public class SmoothSailingItem : ShopItem
{
    [SerializeField] float duration = 60f;
    [SerializeField] float slowFactor = 10f;

    /// <summary>
    /// Reduces wheel turn for a period of time
    /// </summary>
    protected override void ItemEffect()
    {
        StartCoroutine(ReduceSpinCR());
    }

    IEnumerator ReduceSpinCR()
    {
        CaptainsWheel wheel = FindObjectOfType<CaptainsWheel>();
        Debug.Log(wheel);
        wheel.turnForce /= slowFactor;
        yield return new WaitForSeconds(duration);
        wheel.turnForce *= slowFactor;
    }
}
