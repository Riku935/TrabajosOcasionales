using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : Steering
{
    public float runAwayCircle = 5f;
    public float safeRadius = 2f;  

    public override Vector3 GetForce()
    {
        DesiredVelocity = (Target - Position).normalized * speed;
        return (DesiredVelocity - Velocity) * -1;
    }

}
