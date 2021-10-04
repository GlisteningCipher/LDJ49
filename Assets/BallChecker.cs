using UnityEngine;

public class BallChecker : MonoBehaviour
{
    [SerializeField] ScoreKeeper scoreKeeper;

    void Update()
    {
        if (scoreKeeper.CurrScore <= 0) transform.localScale = Vector3.one;
        else transform.localScale = new Vector3(1, 0, 1);
    }


}
