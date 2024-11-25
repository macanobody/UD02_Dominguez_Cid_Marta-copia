using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Detectar si el objeto que colisiona es una flor
        if (other.CompareTag("Flower"))
        {
            Debug.Log("¡El enemigo ha sido impactado por una flor!");

            // Destruir el enemigo
            Destroy(gameObject);

            // Destruir la flor tras el impacto
            Destroy(other.gameObject);
        }
    }
}
