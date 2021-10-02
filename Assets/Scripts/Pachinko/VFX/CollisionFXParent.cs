using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFXParent : MonoBehaviour
{
    public CollisionFX fx;

    public bool isPlayingFX;

    void Start()
    {
        isPlayingFX = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        string type = collision.gameObject.tag;
        switch(type)
        {
            case "Ball":
                if(collision.gameObject.GetComponentInChildren<CollisionFXParent>().isPlayingFX)
                {
                    break;
                }
                StartCoroutine(BallCollision(collision));
                break;
            case "Bucket":
                fx.CollideBucket(collision);
                break;
            case "Peg":
                fx.CollidePeg(collision);
                break;
            default:
                fx.CollideGeneric(collision);
                break;
        }
    }

    IEnumerator BallCollision(Collision2D collision)
    {
        isPlayingFX = true;
        yield return StartCoroutine(fx.CollideBall(collision));
        isPlayingFX = false;
    }
}
