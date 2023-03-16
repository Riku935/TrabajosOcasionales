using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : Steering
{
    public float runAwayCircle = 5f;
    public float safeRadius = 2f;  //SafeRadius es la distancia entre el player y el circulo

    private void Update()
    {
        
    }
    public override Vector3 GetForce()
    {
        Vector3 circleCenter = Velocity.normalized * runAwayCircle;
        Debug.DrawLine(Position, Position + circleCenter, Color.green);


        DesiredVelocity = (Target - Position).normalized * speed;
        return (DesiredVelocity - Velocity) * -1;
        
    }

}
