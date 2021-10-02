using UnityEngine;

[CreateAssetMenu(fileName = "Game Manager", menuName = "Managers/Game Manager", order = 1)]
public class GameManagerSO : ScriptableObject
{
    public void Play()
    {
        Debug.Log("play");
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
        Debug.Log("exit");
    }
}
