using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetBlue()
    {
        PlayerSettings.selectedColor = Color.blue;
    }

    public void SetYellow()
    {
        PlayerSettings.selectedColor = Color.yellow;
    }
}