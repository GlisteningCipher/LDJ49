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
    ScoreEvent scoreEvent;
    Collider2D col;

    public DialogManager dm;

    void Awake()
    {
        scoreEvent = new ScoreEvent();
        col = GetComponent<Collider2D>();
        scoreEvent.AddListener(ScoreKeeper.instance.Score);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            scoreEvent.Invoke(this, other.gameObject.GetComponent<Ball>());
            if (BucketMultipler == 3) dm.ShowScoreBark();
        }
    }
}
