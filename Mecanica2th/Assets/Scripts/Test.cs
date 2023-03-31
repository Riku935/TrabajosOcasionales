using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform destination;
    private Vector3 startPosition;
    private bool isReturning = false;
    public float speed = 1f;
    public bool coroutineRunning = true;

    public bool leftArm;
    public bool rightArm;
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && leftArm)
        {
            StartCoroutine(coroutine());
        }
        if (Input.GetMouseButtonDown(1) && rightArm)
        {
            StartCoroutine(coroutine());
        }
    }
    private void Move()
    {
        
    }
    IEnumerator coroutine()
    {
        while (coroutineRunning)
        {
            if (!isReturning)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
                if (transform.position == destination.position)
                {
                    isReturning = true;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
                if (transform.position == startPosition)
                {
                    isReturning = false;
                    coroutineRunning = false;
                }
            }
            yield return null;
        }
        coroutineRunning = true;
   
    }

}
