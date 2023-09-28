using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSens; //La sensibilidad del mouse
    public GameObject player;
    private float xRotation; //Variable que guarda la rotacion en x
    private float yRotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        cameraMove();
    }

    void cameraMove()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Limita la rotacion de la camara en el eje y
       // yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); //Rota la camara
        player.transform.Rotate(Vector3.up * mouseX); //Esto hace que el playerBody rote al mismo tiempo que la camara pero le falta que este limitado
    }
}
