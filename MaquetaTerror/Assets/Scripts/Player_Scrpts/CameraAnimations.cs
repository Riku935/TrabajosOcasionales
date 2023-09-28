using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimations : MonoBehaviour
{
    public Animator cameraAnimator;
    void Start()
    {
        cameraAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        CameraBobbing();
    }
    void CameraBobbing()
    {
        if (Input.GetKey(KeyCode.W))
        {
            StartBobbing();
        }

        if (Input.GetKey(KeyCode.S))
        {
            StartBobbing();
        }

        if (Input.GetKey(KeyCode.A))
        {
            StartBobbing();
        }

        if (Input.GetKey(KeyCode.D))
        {
            StartBobbing();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            StopBobbing();
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            StopBobbing();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            StopBobbing();
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            StopBobbing();
        }
    }

    void StartBobbing()
    {
        //meraAnimator.GetComponent<Animator>().Play("BobHead");
        cameraAnimator.Play("BobHead");
    }

    void StopBobbing()
    {
        //cameraAnimator.GetComponent<Animator>().Play("New State");
        cameraAnimator.Play("New State");
    }
}

