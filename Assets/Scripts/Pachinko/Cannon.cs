using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Shoots balls.
/// </summary>
public class Cannon : MonoBehaviour
{
    public GameObject BallPrefab;
    public Transform ShootingDirection; // Object position to align shooting.
    public float ShootStrength = 800;
    public float RotateSpeed = 0.5f;

    /// <summary>
    /// Fire a ball.
    /// </summary>
    public void Fire()
    {
        // Check score
        if (ScoreKeeper.instance.CurrScore < 1)
        {
            Debug.LogWarning("Trying to shoot without balls!");
            return;
        }
        ScoreKeeper.instance.CurrScore--;
        var go = Instantiate(BallPrefab);
        go.transform.position = transform.position;
        var rb = go.GetComponent<Rigidbody2D>();
        Vector2 dir = Vector3.Normalize(ShootingDirection.position - transform.position);
        rb.AddForce(ShootStrength * dir);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Fire();
        }
        var axis = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0f, 0f, RotateSpeed * axis));

    }
}
