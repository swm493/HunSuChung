using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public void StartGame()
    {
        Debug.Log("Game Started!");
    }

    public void LoadGame()
    {
        Debug.Log("Game Loaded!");
    }

    public void EndGame()
    {
        Debug.Log("Game Ended!");
    }
    public void ExitGame()
    {
        Debug.Log("Game Exited!");
    }
}