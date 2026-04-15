using UnityEngine;

public class Rotador : MonoBehaviour
{

    public float velocidadGiro = 90.0f;

    void Update()
    {
        transform.Rotate(Vector3.up, velocidadGiro * Time.deltaTime);
    }
}