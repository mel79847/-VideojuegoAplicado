using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;
    private Esfera player;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindAnyObjectByType<Esfera>();

    }

    
    void Update()
    {
        navMeshAgent.destination = player.transform.position;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.ResetGame();
        }
    }
}
