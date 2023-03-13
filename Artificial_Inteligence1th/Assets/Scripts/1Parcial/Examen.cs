using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examen : MonoBehaviour
{
    [Header("Wander")]
    [SerializeField] private float circleDistance = 3;
    [SerializeField] private float circleRadius = 2;
    [SerializeField] private float angleChange = 0;
    [SerializeField] private Vector3 targetChange;
    //[SerializeField] private GameObject targetObjectRandom;
    private Vector3 targetWander;
    private float angleWander;
    private bool coroutineRunning;
    private Queue<Vector3> targetQueue = new Queue<Vector3>();

    [Header("Seek")]
    [SerializeField] private float speed = 3;
    [SerializeField] private float maxSpeed = 10;
    //[SerializeField] private Transform target;
    public Vector3 seekTarget;

    [Header("Run Away")]
    [SerializeField] private float speedAway = 3;
    [SerializeField] private float maxSpeedAway = 10;

    private Vector3 steering;
    private Vector3 velocity;


    #region Action
    [SerializeField] private SteeringType _type;
    private Dictionary<string, Action> _actions = new Dictionary<string, Action>();
    private enum SteeringType
    {
        Seek, RunAway, Wander
    }
    #endregion

    private void Start()
    {
        targetWander = transform.position;
        targetChange = transform.position;
        _actions.Add("Seek", CalculateSeek);
        _actions.Add("RunAway", CalculateRunAway);
        _actions.Add("Wander", CalculateWander);
        StartCoroutine(ChangeTarget());
        StartCoroutine(ChangeAngle());
        FillQueue();

    }
    void Update()
    {
        if (_actions.TryGetValue(_type.ToString(), out Action action)) 
        {
            action(); 
        }
    }

    private void CalculateSeek()
    {
        Vector3 steering = Seek(seekTarget);
        Move(steering);
    }
    #region Seek
    Vector3 Seek (Vector3 target)
    {
        Vector3 desiredVelocity = ((seekTarget - transform.position).normalized * speed);
        return desiredVelocity - velocity;
    }
    private void Move(Vector3 steering)
    {
        velocity += steering;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed); 
        transform.position += velocity * Time.deltaTime;
    }
    #endregion 
    private void CalculateRunAway()
    {
        Vector3 steering = SeekRun(seekTarget);
        MoveRun(steering * -1);
    }

    #region Run
    Vector3 SeekRun(Vector3 target)
    {
        Vector3 desiredVelocity = ((seekTarget - transform.position).normalized * speedAway);
        return desiredVelocity - velocity;
    }
    private void MoveRun(Vector3 steering)
    {
        velocity += steering;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeedAway);
        transform.position += velocity * Time.deltaTime;
    }
    #endregion 

    private void CalculateWander()
    {
        //Vector3 newTarget = targetWander;
        seekTarget = targetChange;
        targetWander = targetChange;
        Vector3 steering = Seek(wonderForce() + Seek(seekTarget));
        Move(steering);
        Vector3 circleCenter = velocity.normalized * circleDistance;
        Vector3 circlePosition = transform.position + circleCenter;
        Debug.DrawLine(circlePosition, circlePosition + GetDisplacement(), Color.red); //Displacement
        Debug.DrawLine(transform.position, transform.position + wonderForce(), Color.blue); //WanderForce
    }
    #region WanderFunctions
    private Vector3 GetCircle()
    {
        Vector3 circleCenter = velocity.normalized * circleDistance;
        Debug.DrawLine(transform.position, transform.position + circleCenter, Color.green);
        return circleCenter;
    }
    private Vector3 GetDisplacement()
    {
        Vector3 displacement = Vector3.up * circleRadius;
        Quaternion rotate = Quaternion.AngleAxis(angleWander, Vector3.forward);
        displacement = rotate * displacement;
        return displacement;
        
    }
    private Vector3 wonderForce()
    {
        var wanderForce = GetCircle() + GetDisplacement();
        return wanderForce;
    }

    private IEnumerator ChangeAngle()
    {
        while (true)
        {
            angleWander = UnityEngine.Random.Range(-90, 90);
            yield return new WaitForSeconds(0.5f);
        }
    }
    #endregion

    #region RandomTarget
    private void FillQueue()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 randomTarget = new Vector3(UnityEngine.Random.Range(-8f, 8f), UnityEngine.Random.Range(-5f, 5f), 0);
            targetQueue.Enqueue(randomTarget);
        }
    }
    IEnumerator ChangeTarget()
    {
        while (true)
        {
            if (targetQueue.Count == 0) FillQueue();
            targetChange = targetQueue.Dequeue();
            //print(targetChange);
            //targetWander = targetQueue.Dequeue();
            //targetChange = targetWander;
            yield return new WaitForSeconds(5);
            //targetObjectRandom.transform.position = targetWander;
        }
    }
    #endregion
}
