using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bucket : MonoBehaviour
{
    [SerializeField] UnityEvent scoreEvent = new UnityEvent();
    Collider2D col;

    void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball") scoreEvent.Invoke();
    }
}
