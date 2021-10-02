using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRotation : MonoBehaviour
{
    private void LateUpdate()
    {
        var q = new Quaternion();
        q.eulerAngles = Vector3.zero;
        transform.rotation = q;
    }
}
