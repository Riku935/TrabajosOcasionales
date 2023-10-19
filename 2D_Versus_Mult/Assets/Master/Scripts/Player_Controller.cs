using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    public float velocidad = 5.0f;

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoX = movimientoHorizontal * velocidad * Time.deltaTime;
        transform.Translate(new Vector3(movimientoX, 0, 0));
    }
}
