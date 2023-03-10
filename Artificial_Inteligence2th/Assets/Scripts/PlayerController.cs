using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera camera;
    private Vector3 _target;
    public Seek seek;

    private void FixedUpdate()
    {
        Vector3 mouseTarget = camera.ScreenToWorldPoint(Input.mousePosition);
        _target = new Vector3(mouseTarget.x, mouseTarget.y, 0.0f);
        seek.Target = _target;
    }
}
