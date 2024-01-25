using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] float ropeForce = 8f;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerRigidbody = player.GetComponent<Rigidbody>();
            if (playerRigidbody == null)
            {
                playerRigidbody = player.AddComponent<Rigidbody>();
            }
            playerRigidbody.useGravity = true;
        }
        else
        {
            Debug.LogError("No se encontr� un objeto con la etiqueta 'Player'");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aseg�rate de que Player.instance.speed es positivo
            float velocidadJugador = Mathf.Max(0f, Player.instance.speed);

            // Obt�n la direcci�n de la liana hacia adelante (puedes ajustar esto)
            Vector3 direccionFuerza = transform.forward;

            // Aplicar la fuerza al jugador en la direcci�n correcta
            playerRigidbody.AddForce(direccionFuerza * (ropeForce * velocidadJugador), ForceMode.Impulse);
        }
    }
}
