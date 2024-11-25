using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento del Player")]
    public float moveSpeed = 5f; // Velocidad de movimiento
    public float jumpForce = 5f; // Fuerza de salto

    [Header("Disparo de flores")]
    public GameObject flowerPrefab; // Prefab de la flor
    public Transform flowerSpawnPoint; // Punto desde donde se dispara la flor
    public float shootForce = 10f; // Fuerza del disparo

    private Rigidbody rb; // Referencia al Rigidbody del Player

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        
        if (rb == null)
        {
           
        }

        if (flowerPrefab == null || flowerSpawnPoint == null)
        {
            
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    private void HandleMovement()
    {
        // Movimiento horizontal
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement, Space.World);

        // Salto 
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0)) // Botón izquierdo del ratón
        {
            ShootFlower();
        }
    }

    private void ShootFlower()
    {
        if (flowerPrefab != null && flowerSpawnPoint != null)
        {
            // Crear la flor
            GameObject flower = Instantiate(flowerPrefab, flowerSpawnPoint.position, flowerSpawnPoint.rotation);

            // Aplicar una fuerza al Rigidbody de la flor para dispararla
            Rigidbody flowerRb = flower.GetComponent<Rigidbody>();
            if (flowerRb != null)
            {
                // Dirección del disparo en un arco, añadiendo un pequeño impulso hacia arriba
                Vector3 shootDirection = flowerSpawnPoint.forward + Vector3.up * 0.5f; 
                flowerRb.AddForce(shootDirection * shootForce, ForceMode.Impulse);
            }
        }
        
    }
}


