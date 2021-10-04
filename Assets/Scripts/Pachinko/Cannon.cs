using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Shoots balls.
/// </summary>
public class Cannon : MonoBehaviour
{
    public GameObject BallPrefab; // Current ball being used.
    public GameObject NormalBallPrefab; // Normal ball type for reference.
    public Transform ShootingDirection; // Object position to align shooting.
    public AudioSource shootSFX;
    public float ShootStrength = 800;
    public float RotateSpeed = 0.5f;

    bool specialBall = false;

    /// <summary>
    /// Fire a ball.
    /// </summary>
    public void Fire()
    {
        // Check score and deduct if available
        if (ScoreKeeper.instance.CurrScore < 1)
        {
            Debug.LogWarning("Trying to shoot without balls!");
            return;
        }
        ScoreKeeper.instance.CurrScore--;
        // Shoot ball
        var go = Instantiate(BallPrefab);
        go.transform.position = transform.position;
        var rb = go.GetComponent<Rigidbody2D>();
        Vector2 dir = Vector3.Normalize(ShootingDirection.position - transform.position);
        rb.AddForce(ShootStrength * dir);
        shootSFX.PlayOneShot(shootSFX.clip);
        // If it was a special ball, load normal balls
        if (specialBall)
        {
            specialBall = false;
            BallPrefab = NormalBallPrefab;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Fire();
        }
        var axis = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0f, 0f, RotateSpeed * axis * -1));
    }

    /// <summary>
    /// Set a new ball type.
    /// Only applies to next ball fired.
    /// </summary>
    public void SetBall(GameObject ballPrefab)
    {
        BallPrefab = ballPrefab;
        specialBall = true;
    }
}
