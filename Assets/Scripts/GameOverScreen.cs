using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene(GameSession.lastPlayedLevel);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}