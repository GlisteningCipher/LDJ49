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
    [SerializeField] DialogManager dialog;

    /// <summary>
    /// Calculate score when ball hits bucket, and destroys ball.
    /// UnityEvent callback.
    /// </summary>
    public void Score(Bucket bucket, Ball ball)
    {
        CurrScore += bucket.BucketMultipler * ball.BallScore;
        Destroy(ball.gameObject);
        CancelInvoke();
        Invoke("NoScoreBarkEvent", 30f);
    }

    void NoScoreBarkEvent()
    {
        dialog.ShowFailureBark();
        Invoke("InactivityBarkEvent", 30f);
    }

    void InactivityBarkEvent()
    {
        dialog.ShowFailureBark();
        Invoke("NoScoreBarkEvent", 30f);
    }

    private void Awake()
    {
        instance = this;
        CurrScore = StartScore;
        if (dialog != null) Invoke("NoScoreBarkEvent", 30f);
    }

    private void Update()
    {
        ScoreText.text = CurrScore.ToString();
    }
}
