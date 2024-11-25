using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{

    [Header("Movimiento de la gallina")]
    [SerializeField] private float moveSpeed = 5f; // Velocidad de movimiento

    [Header("Huevos")]
    [SerializeField] private GameObject eggPrefab; // Prefab del huevo
    [SerializeField] private Transform eggSpawnPoint; // Punto de generación del huevo
    [SerializeField] private float eggLifetime = 5f; // Tiempo antes de destruir el huevo

    private void Update()
    {
        HandleMovement();
        HandleEggSpawn();
    }

    private void HandleMovement()
    {
        // Obtener las teclas de movimiento (flechas o WASD)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Crear un vector de movimiento
        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;

        // Mover la gallina usando el transform
        transform.Translate(movement, Space.World);
    }

    private void HandleEggSpawn()
    {
        // Comprobar si se hace clic con el botón izquierdo del ratón
        if (Input.GetMouseButtonDown(0)) // Botón izquierdo
        {
            SpawnEgg();
        }
    }

    private void SpawnEgg()
    {
        
        if (eggPrefab != null && eggSpawnPoint != null)
        {
            // Instanciar el huevo en la posición de eggSpawnPoint
            GameObject egg = Instantiate(eggPrefab, eggSpawnPoint.position, eggSpawnPoint.rotation);
            Destroy(egg, eggLifetime); // Destruir el huevo después de un tiempo
        }
        else
        {
           
        }
    }
}
