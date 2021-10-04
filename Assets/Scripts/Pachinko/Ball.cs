using System.Collections;
using UnityEngine;

/// <summary>
/// Ball behavior and stats.
/// </summary>
public class Ball : MonoBehaviour
{
    public int BallScore = 1; // Base score value.

    IEnumerator Start()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}
