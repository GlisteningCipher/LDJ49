using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Balls destroy pegs on impact.
/// </summary>
public class GrenadeBall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Peg"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
