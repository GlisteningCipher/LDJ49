using UnityEngine;
using System.Collections;

public class BallItem : ShopItem
{
    [SerializeField] GameObject ballPrefab;

    protected override void ItemEffect()
    {
        var cannon = FindObjectOfType<Cannon>();
        cannon.SetBall(ballPrefab);
    }
}
