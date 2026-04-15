using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float normalSpeed = 3.5f;
    public float fastSpeed = 6f;
    public int activationCollectibles = 1;
    public int fastModeCollectibles = 3;
    public AudioSource tensionAudio;

    private NavMeshAgent agent;
    private Esfera player;
    private Renderer[] renderers;
    private Collider[] colliders;
    private bool isActive = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindAnyObjectByType<Esfera>();
        renderers = GetComponentsInChildren<Renderer>();
        colliders = GetComponentsInChildren<Collider>();

        if (agent != null)
            agent.speed = normalSpeed;

        SetEnemyActive(false);

        if (tensionAudio != null)
        {
            tensionAudio.loop = true;
            tensionAudio.playOnAwake = false;
        }
    }

    void Update()
    {
        if (player == null || GameManager.Instance == null || agent == null) return;

        int collected = GameManager.Instance.CurrentCollectibles();

        if (!isActive && collected >= activationCollectibles)
        {
            SetEnemyActive(true);
        }

        if (!isActive) return;

        agent.destination = player.transform.position;

        if (collected >= fastModeCollectibles)
        {
            agent.speed = fastSpeed;

            if (tensionAudio != null && !tensionAudio.isPlaying)
            {
                tensionAudio.Play();
            }
        }
        else
        {
            agent.speed = normalSpeed;

            if (tensionAudio != null && tensionAudio.isPlaying)
            {
                tensionAudio.Stop();
            }
        }
    }

    private void SetEnemyActive(bool value)
    {
        isActive = value;

        if (agent != null)
            agent.enabled = value;

        foreach (Renderer r in renderers)
            r.enabled = value;

        foreach (Collider c in colliders)
            c.enabled = value;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (tensionAudio != null)
                tensionAudio.Stop();

            SceneManager.LoadScene("GameOver");
        }
    }
}