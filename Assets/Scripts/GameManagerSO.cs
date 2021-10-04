using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Game Manager", menuName = "Managers/Game Manager", order = 1)]
public class GameManagerSO : ScriptableObject
{
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayEasy()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayMedium()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayHard()
    {
        SceneManager.LoadScene(3);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
