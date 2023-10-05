using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notas : MonoBehaviour
{
    public GameObject nota;
    public GameObject texto;
    private void OnTriggerStay(Collider other)
    {
        texto.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            nota.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        texto.SetActive(false);
        nota.SetActive(false);
    }
}
