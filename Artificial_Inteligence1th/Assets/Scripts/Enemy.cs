using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float slowingRadius;

    public GameObject randomTransform; //Lo puse yo
    private bool crRunning; //Lo puse yo

    private Queue<Vector3> targetQueue = new Queue<Vector3>();

    private enum SteeringType
    {
        Seek, RunAway, Arrival, Wander
    }
    [SerializeField] private SteeringType _type = SteeringType.RunAway; //SteeringType.RunAway esto lo que hace es poner RunAway como la opcion por defecto
    private Dictionary<string, Action> _actions = new Dictionary<string, Action>();  //Acciones son delegados que no toman ningun parametro y no regresan ningun valor

    private Vector3 steering;
    private Vector3 targetWander;
    
    void Start()
    {
        targetWander = transform.position; //Inicializamos su posicion
        _actions.Add("Seek", CalculateSeek); //Añades acciones al diccionario 
        _actions.Add("RunAway", CalculateRun);
        _actions.Add("Arrival", CalculateArrival);
        _actions.Add("Wander", CalculateWander);
        FillQueue();
        StartCoroutine(ChangeTarget());
    }

    void Update()
    {
        if (_actions.TryGetValue(_type.ToString(), out Action action)) //Intenta buscar el nombre y si encuentra el nombre, ejecutas la accion
        {
            action(); //Ejecutas la accion
        }
    }
    private void CalculateSeek()
    {
        Vector3 steering = Seek(target.position);
        Move(steering);
    }
    Vector3 Seek(Vector3 target)
    {
        Vector3 desiredVelocity = ((target - transform.position).normalized * speed);
        return desiredVelocity - velocity;
    }
    void Move(Vector3 steering)
    {
        velocity += steering;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed); //Clamp especifico para limitar vectores
        
        transform.position += velocity * Time.deltaTime;
    }
    private void CalculateRun()
    {
        Vector3 steering = Seek(target.position);
        Move(steering * -1);
    }
    private void CalculateArrival()
    {
        Vector3 desiredVelocity = ((target.position - transform.position).normalized);
        float distance = desiredVelocity.magnitude;

        if (distance < slowingRadius) 
        { 
            steering = desiredVelocity - velocity * (distance/slowingRadius); 
        }
        else
        {
            steering = desiredVelocity - velocity;
        }
        Move(steering);
    }
    private void CalculateWander()
    {
        Vector3 newTarget = targetWander;
        Vector3 steering = Seek(newTarget);
        Move(steering);
        if (crRunning == false) 
        {
            StartCoroutine(ChangeTarget());
            crRunning = true;
        }
    }
    void prueba()
    {
        //float circleCenter = 2f;

        //Vector3 circleDist = velocity.normalized * circleCenter;
        float circledist = 2;
        Vector3 circleCenter;
        circleCenter = velocity.normalized * circledist;
    }
    private void FillQueue()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 randomTarget = new Vector3(UnityEngine.Random.Range(-8f,8f), UnityEngine.Random.Range(-5f,5f),0);
            targetQueue.Enqueue(randomTarget);
        }
    }

    IEnumerator ChangeTarget() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(5);
            if (targetQueue.Count == 0) FillQueue();
            targetWander = targetQueue.Dequeue();
            randomTransform.transform.position = targetWander; //Yo puse esto
        }
    }
}
