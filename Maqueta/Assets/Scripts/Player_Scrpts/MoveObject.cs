using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private GameObject objetoSostenido;
    private bool estaSosteniendo = false;
    private Vector3 offset;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!estaSosteniendo)
            {
                // Intenta recoger un objeto si no se está sosteniendo ninguno.
                TryPickUpObject();
            }
            else
            {
                // Suelta el objeto si ya se está sosteniendo.
                DropObject();
            }
        }

        if (estaSosteniendo && Input.GetKey(KeyCode.E))
        {
            // Mueve el objeto sostenido mientras se mantiene presionada la tecla E.
            MoveObjects();
        }
    }

    void TryPickUpObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f))
        {
            GameObject objetoHit = hit.collider.gameObject;
            if (objetoHit.CompareTag("Interactable"))
            {
                objetoSostenido = objetoHit;
                offset = hit.point - objetoSostenido.transform.position;
                estaSosteniendo = true;
                Debug.DrawRay(transform.position, transform.forward * 5f, Color.green);
                Debug.Log("Objeto recogido: " + objetoSostenido.name);
            }
            else
            {
                Debug.Log("Objeto no es interactuable.");
            }
        }
        else
        {
            Debug.Log("No se detectó ningún objeto.");
        }
    }

    void MoveObjects()
    {
        Vector3 newPosition = transform.position + transform.forward * 2f + offset;
        objetoSostenido.transform.position = newPosition;
    }

    void DropObject()
    {
        objetoSostenido = null;
        estaSosteniendo = false;
    }
}
