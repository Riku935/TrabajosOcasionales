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
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(Position, runAwayCircle);
    }
    public override Vector3 GetForce()
    {
        Vector3 circleCenter = Velocity.normalized * -runAwayCircle;
        Vector3 circleEnd = Position + circleCenter;
        //float distanceCirclePlayer = Vector3.Distance(circleEnd, Target);
        //Debug.DrawLine(Position, Position + circleCenter, Color.green);
        //Debug.DrawLine(circleEnd, Target, Color.red);
        //Debug.Log(Target.magnitude);

        if(Target.magnitude < safeRadius)
        {
            DesiredVelocity = (Target - Position).normalized * speed;
            return (DesiredVelocity - Velocity) * -1;
        }
        if (Target.magnitude > safeRadius)
        {
            return Vector3.zero;
        }
        return Vector3.zero;
    }

}
