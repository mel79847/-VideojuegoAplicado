using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemigo : MonoBehaviour
{
    public float normalSpeed = 3.5f;
    public float fastSpeed = 6f;
    public int activationCollectibles = 1;
    public int fastModeCollectibles = 3;
    public float killDistance = 2.2f;
    public float tensionDistance = 6f;
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

        SetEnemyVisible(false);

        if (tensionAudio != null)
        {
            tensionAudio.loop = true;
            tensionAudio.playOnAwake = false;
            tensionAudio.Stop();
        }
    }

    void Update()
    {
        if (player == null || GameManager.Instance == null || agent == null) return;

        int collected = GameManager.Instance.CurrentCollectibles();

        if (!isActive && collected >= activationCollectibles)
        {
            isActive = true;
            SetEnemyVisible(true);
        }

        if (!isActive)
        {
            StopTensionAudio();
            return;
        }

        if (!agent.enabled)
            agent.enabled = true;

        agent.destination = player.transform.position;

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= killDistance)
        {
            KillPlayer();
            return;
        }

        if (collected >= fastModeCollectibles)
            agent.speed = fastSpeed;
        else
            agent.speed = normalSpeed;

        if (distanceToPlayer <= tensionDistance)
        {
            if (tensionAudio != null && !tensionAudio.isPlaying)
                tensionAudio.Play();
        }
        else
        {
            StopTensionAudio();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive) return;

        if (other.CompareTag("Player"))
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        StopTensionAudio();
        SceneManager.LoadScene("GameOver");
    }

    private void StopTensionAudio()
    {
        if (tensionAudio != null && tensionAudio.isPlaying)
            tensionAudio.Stop();
    }

    private void SetEnemyVisible(bool value)
    {
        foreach (Renderer r in renderers)
            r.enabled = value;

        foreach (Collider c in colliders)
            c.enabled = value;
    }
}