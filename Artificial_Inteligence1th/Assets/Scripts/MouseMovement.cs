using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public GameObject playerGameObject;
    public Vector3 m_prevPosition;
    public Vector3 actualVelocity;

    private void Start()
    {
        m_prevPosition = transform.position;
    }
    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        playerGameObject.transform.Translate(h, v, 0);


        var actualVelocity = Vector3.Distance(m_prevPosition, transform.position);
        actualVelocity /= Time.deltaTime;
        m_prevPosition = transform.position;
        
    }
}
