using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Renderer previewRenderer;

    public Material blueMaterial;
    public Material yellowMaterial;
    public Material redMaterial;
    public Material pinkMaterial;

    private void Start()
    {
        if (previewRenderer != null && blueMaterial != null)
        {
            previewRenderer.material = blueMaterial;
        }
    }

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
        if (previewRenderer != null && blueMaterial != null)
        {
            previewRenderer.material = blueMaterial;
        }
    }

    public void SetYellow()
    {
        PlayerSettings.selectedColor = Color.yellow;
        if (previewRenderer != null && yellowMaterial != null)
        {
            previewRenderer.material = yellowMaterial;
        }
    }

    public void SetRed()
    {
        PlayerSettings.selectedColor = Color.red;
        if (previewRenderer != null && redMaterial != null)
        {
            previewRenderer.material = redMaterial;
        }
    }

    public void SetPink()
    {
        PlayerSettings.selectedColor = new Color(1f, 0.4f, 0.7f);
        if (previewRenderer != null && pinkMaterial != null)
        {
            previewRenderer.material = pinkMaterial;
        }
    }
}