using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages score (i.e. number of balls) in pachinko game.
/// </summary>
public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper instance = null;
    public int StartScore = 10; // Number of balls player starts with.
    int currScore = 0; // Current score (i.e. # of balls)
    public int CurrScore
    {
        get => currScore;
        set
        {
            currScore = value;
        }
    }
    public TMPro.TextMeshProUGUI ScoreText;

    /// <summary>
    /// Calculate score when ball hits bucket, and destroys ball.
    /// UnityEvent callback.
    /// </summary>
    public void Score(Bucket bucket, Ball ball)
    {
        CurrScore += bucket.BucketMultipler * ball.BallScore;
        Destroy(ball.gameObject);
    }

    private void Awake()
    {
        instance = this;
        CurrScore = StartScore;
    }

    private void Update()
    {
        ScoreText.text = CurrScore.ToString();
    }
}
