using UnityEngine;
using UnityEngine.SceneManagement;

public class Esfera : MonoBehaviour
{
    public Rigidbody rb;
    public float velocidad = 10f;
    public AudioSource sonidoCollectible;
    public AudioClip collectibleClip;
    public Renderer playerRenderer;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (playerRenderer != null)
        {
            playerRenderer.material.color = PlayerSettings.selectedColor;
        }
    }

    void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 direccion = new Vector3(movimientoHorizontal, 0f, movimientoVertical);

        if (direccion.magnitude > 1f)
        {
            direccion = direccion.normalized;
        }

        Vector3 nuevaVelocidad = new Vector3(
            direccion.x * velocidad,
            rb.linearVelocity.y,
            direccion.z * velocidad
        );

        // Evitar que salga disparada hacia arriba demasiado
        if (rb.linearVelocity.y > 5f)
        {
            nuevaVelocidad.y = 0f;
        }

        rb.linearVelocity = nuevaVelocidad;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            GameManager.Instance.AddCollectibles();

            if (sonidoCollectible != null && collectibleClip != null)
            {
                sonidoCollectible.PlayOneShot(collectibleClip);
            }

            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}