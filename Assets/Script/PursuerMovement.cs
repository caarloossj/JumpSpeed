using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuerMovement : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    private Rigidbody _rigidbody;
    private float rotatePosition;


    bool girado;

    enum StatesPursuer
    {
        Walking, 
        startRotating, 
    }

    StatesPursuer statesPursuer = StatesPursuer.Walking;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        girado = false;
    }

    void Update()
    {
        MoverAdelante();

        //Cuando detecte que el perseguidor cambia de estado llamará a la función de rotar

        if (statesPursuer == StatesPursuer.startRotating)
        {
            if (transform.position.z >= rotatePosition)
            {
                RotationPursuer();
                statesPursuer = StatesPursuer.Walking;
            }
        }
    }

    void MoverAdelante()
    {
        Vector3 newVelocity;

        newVelocity = transform.forward * speed;

        newVelocity.y = _rigidbody.velocity.y;

        _rigidbody.velocity = newVelocity;
    }

    //Aquí están las colisiones para que el perseguidor sepa cuando girar
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CanRotate"))
        {
            statesPursuer = StatesPursuer.startRotating;
            rotatePosition = other.transform.position.z;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }

    //Está es la función para la rotación del perseguidor.

    private void RotationPursuer()
    {
        if (!girado) 
        {
            transform.Rotate(Vector3.up, 90);

            girado = true;
        }
        else 
        { 
            transform.Rotate(Vector3.up, -90);
            girado = false;
        }
    }
}
