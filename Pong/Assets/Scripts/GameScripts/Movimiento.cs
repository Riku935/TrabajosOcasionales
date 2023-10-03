using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private float speed = 20f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxisRaw("Vertical2");
        transform.position += new Vector3(0, movement * speed * Time.deltaTime, 0);
    }
}
