using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Game Manager", menuName = "Managers/Game Manager", order = 1)]
public class GameManagerSO : ScriptableObject
{
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Options()
    {
        Debug.Log("options");
    }

    public void Credits()
    {
        Debug.Log("credits");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
