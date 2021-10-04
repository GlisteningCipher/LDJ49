using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Game Manager", menuName = "Managers/Game Manager", order = 1)]
public class GameManagerSO : ScriptableObject
{
    public int difficulty = 0;

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayEasy()
    {
        difficulty = 0;
        SceneManager.LoadScene(1);
    }

    public void PlayMedium()
    {
        difficulty = 1;
        SceneManager.LoadScene(1);
    }

    public void PlayHard()
    {
        difficulty = 2;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
