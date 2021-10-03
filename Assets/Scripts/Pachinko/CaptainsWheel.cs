using UnityEngine;

/// <summary>
/// Peg that rotates entire stage when rotated.
/// </summary>
public class CaptainsWheel : MonoBehaviour
{
    public Rigidbody2D WheelRB; // Rigidbody of rotating wheel.
    public Transform StageTr; // Transform of entire pachinko stage.
    float currTilt // Current tilt (default 0, pos/neg)
    {
        get
        {
            var raw = StageTr.rotation.eulerAngles.z;
            return raw <= 180f ? raw : raw - 360f;
        }
    }
    float currAV => WheelRB.angularVelocity;

    public float turnForce = 0.00001f;

    float turnSpeed = 0f;
    const float maxSpeed = 0.5f;
    const float maxTilt = 20f;
    const float smallTilt = 0.5f;

    private void FixedUpdate()
    {
        if (Mathf.Abs(currAV) < smallTilt) return;
        turnSpeed += currAV * turnForce;
        turnSpeed = Mathf.Clamp(turnSpeed, -1f * maxSpeed, maxSpeed);

        StageTr.Rotate(new Vector3(0f, 0f, turnSpeed));
        if (Mathf.Abs(currTilt) > maxTilt)
        {
            Quaternion q = new Quaternion();
            q.eulerAngles = new Vector3(0f, 0f, maxTilt * Mathf.Sign(currTilt));
            StageTr.rotation = q;
            turnSpeed = 0f;
            if (Mathf.Sign(currAV) == Mathf.Sign(currTilt))
                WheelRB.angularVelocity = 0f;
        }
    }
}
