using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Splits ball into 3 on impact.
/// </summary>
[RequireComponent(typeof(Ball))]
public class Multiball : MonoBehaviour
{
    public bool Cloned = false; // Has this already made clones?

    const float cloneForce = 500f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!Cloned)
        {
            Cloned = true;
            var clones = new GameObject[2];
            // Make 2 clones
            for (int i = 0; i < 2; i++)
            {
                clones[i] = Instantiate(gameObject);
                clones[i].GetComponent<Multiball>().Cloned = true; // mark as clone
                clones[i].GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * cloneForce);
            }

        }
    }
}
