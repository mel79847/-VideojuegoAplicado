using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text collectiblesText;
    public TMP_Text collectiblesTextTotal;

    private int collectiblesNumberTotal;
    private int collectiblesNumber;

    public static GameManager Instance { get; set; }

    void Start()
    {
       Instance = this;
       collectiblesNumberTotal = transform.childCount;
       collectiblesTextTotal.text = collectiblesNumberTotal.ToString();
       //Debug.Log("Total collectibles: " + collectiblesNumberTotal);
    }


    void Update()
    {
        if (transform.childCount <= 0)
        {
            //Debug.Log("All collectibles collected, loading next level...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
    public void AddCollectibles()
    {
        collectiblesNumber++;
        collectiblesText.text = collectiblesNumber.ToString();
        
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
