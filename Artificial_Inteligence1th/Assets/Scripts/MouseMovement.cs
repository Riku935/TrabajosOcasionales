using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public GameObject playerGameObject;

    
    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        playerGameObject.transform.Translate(h, v, 0);
    }
}
