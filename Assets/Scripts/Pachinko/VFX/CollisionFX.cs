using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFX : MonoBehaviour
{
    public CollisionFXParent parent;

    [SerializeField] AudioSource ballSFX;
    [SerializeField] AudioSource pegSFX;
    [SerializeField] AudioSource bucketSFX;
    [SerializeField] AudioSource genericSFX;

    [SerializeField] GameObject impactVFX;
    [SerializeField] float maxMagnitude;

    public void CollidePeg(Collision2D collision)
    {
        pegSFX.pitch = Mathf.Lerp(2.5f, 3f, Random.value);
        pegSFX.Play();
        SpawnImpactVFX(collision, .5f);
    }

    public IEnumerator CollideBall(Collision2D collision)
    {
        ballSFX.Play();
        SpawnImpactVFX(collision, .75f);
        yield return new WaitForSeconds(0.01f);
        
    }

    public void CollideBucket(Collision2D collision)
    {
        bucketSFX.Play();
    }

    public void CollideGeneric(Collision2D collision)
    {
        genericSFX.pitch = Mathf.Lerp(2.5f, 3f, Random.value);
        genericSFX.Play();
        SpawnImpactVFX(collision, 1f);       
    }

    void SpawnImpactVFX(Collision2D collision, float objScale)
    {
        var vfx = Instantiate(impactVFX);
        Vector2 impactDir = new Vector2(collision.relativeVelocity.normalized.x, collision.relativeVelocity.normalized.y);
        float angle = Vector2.Angle(Vector2.right, impactDir);
        float scale = collision.relativeVelocity.magnitude;
        scale = scale > maxMagnitude ? 1 : scale / maxMagnitude;
        scale *= objScale;

        vfx.GetComponent<ImpactVFX>().PlayImpactFX(collision.contacts[0].point, angle, scale);
    }
}
