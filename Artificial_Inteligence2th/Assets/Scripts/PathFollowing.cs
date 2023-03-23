using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFollowing : Steering
{
    public List<Vector3> nodes;
    public float pathRadius = 2f;
    public bool looping = true;
    private int _currentNode = 0;
    private int _pathDirection = 1;


    public override Vector3 GetForce()
    {
        float dist = Vector3.Distance(Position, nodes[_currentNode]);
        Debug.Log(nodes[_currentNode]);
        if (dist <= pathRadius)
        {
            _currentNode++;
        }
        if (_currentNode == nodes.Count && looping)
        {
            _currentNode = 0;
        }
        return Seek();
    }
    private Vector3 Seek()
    {
        Target = nodes[_currentNode];
        DesiredVelocity = (Target - Position).normalized * speed;
        return DesiredVelocity - Velocity;
    }
}
