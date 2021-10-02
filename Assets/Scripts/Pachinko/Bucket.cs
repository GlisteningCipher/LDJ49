using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Event for calculating score.
/// </summary>
public class ScoreEvent : UnityEvent<Bucket, Ball> { }

public class Bucket : MonoBehaviour
{
    public int BucketMultipler = 1; // Multiplies score.
    public TMPro.TextMeshPro MultiplierText;
    ScoreEvent scoreEvent;
    Collider2D col;

    void Awake()
    {
        scoreEvent = new ScoreEvent();
        col = GetComponent<Collider2D>();
        scoreEvent.AddListener(ScoreKeeper.instance.Score);
    }

    private void Update()
    {
        MultiplierText.text = BucketMultipler.ToString() + "x";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball") scoreEvent.Invoke(this, other.gameObject.GetComponent<Ball>());
    }
}
