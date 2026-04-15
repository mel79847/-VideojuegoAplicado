using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Esfera player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindAnyObjectByType<Esfera>();

    }

    
    void Update()
    {
        agent.destination = player.transform.position;

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player killed by enemy...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
