using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text collectiblesText;
    public TMP_Text collectiblesTextTotal;
    public string nextSceneName;

    private int collectiblesNumberTotal;
    private int collectiblesNumber;

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GameSession.lastPlayedLevel = SceneManager.GetActiveScene().name;

        collectiblesNumberTotal = transform.childCount;
        collectiblesNumber = 0;

        if (collectiblesTextTotal != null)
            collectiblesTextTotal.text = collectiblesNumberTotal.ToString();

        if (collectiblesText != null)
            collectiblesText.text = collectiblesNumber.ToString();
    }

    void Update()
    {
        if (transform.childCount <= 0)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    public void AddCollectibles()
    {
        collectiblesNumber++;

        if (collectiblesText != null)
            collectiblesText.text = collectiblesNumber.ToString();
    }

    public int CurrentCollectibles()
    {
        return collectiblesNumber;
    }
}