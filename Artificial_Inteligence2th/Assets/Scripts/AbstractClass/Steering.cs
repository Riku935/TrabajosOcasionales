using UnityEngine;

public abstract class Steering : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 DesiredVelocity;
    public Vector3 Velocity;
    public Vector3 Position;
    public Vector3 Target;

    public abstract Vector3 GetForce();

}
