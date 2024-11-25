using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Destruir al enemigo al impactar
            Destroy(other.gameObject);

            // Destruir la flor tras el impacto
            Destroy(gameObject);
        }
        else
        {
            // Si no impacta con un enemigo, destruir la flor tras un retraso
            Destroy(gameObject, 2f);
        }
    }
}
