using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Peg that rotates entire stage when rotated.
/// </summary>
public class CaptainsWheel : MonoBehaviour
{
    public Rigidbody2D WheelRB; // Rigidbody of rotating wheel.
    public Transform StageTr; // Transform of entire pachinko stage.
    float currTilt => StageTr.rotation.z;
    float currAV => WheelRB.angularVelocity;

    float turnSpeed = 0f;
    const float turnForce = 0.001f;
    const float maxSpeed = 0.1f;
    const float maxTilt = 0.2f;
    const float smallTilt = 0.05f;

    private void FixedUpdate()
    {
        if (Mathf.Abs(currAV) < smallTilt) return;
        var dir = Mathf.Sign(currAV);
        turnSpeed += dir * turnForce;
        turnSpeed = Mathf.Clamp(turnSpeed, -1f * maxSpeed, maxSpeed);

        if (Mathf.Abs(currTilt + turnSpeed) < maxTilt)
        {
            StageTr.Rotate(new Vector3(0f, 0f, turnSpeed));
        }
    }
}
