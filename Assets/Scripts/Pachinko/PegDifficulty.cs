using UnityEngine;

public class PegDifficulty : MonoBehaviour
{
    [SerializeField] GameManagerSO gameManager;
    [SerializeField] Transform easyLimit;
    [SerializeField] Transform mediumLimit;

    void Start()
    {
        if (gameManager.difficulty == 2) return;
        Transform limit = gameManager.difficulty == 0 ? easyLimit : mediumLimit;
        int siblingIndex = limit.GetSiblingIndex();
        for (int i = siblingIndex; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
