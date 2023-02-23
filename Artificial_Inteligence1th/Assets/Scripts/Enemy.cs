using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;
    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    private enum SteeringType
    {
        Seek, RunAway, Arrival
    }
    [SerializeField] private SteeringType _type = SteeringType.RunAway; //SteeringType.RunAway esto lo que hace es poner RunAway como la opcion por defecto
    private Dictionary<string, Action> _actions = new Dictionary<string, Action>();  //Acciones son delegados que no toman ningun parametro y no regresan ningun valor

    private Vector3 steering;
    
    void Start()
    {
        _actions.Add("Seek", CalculateSeek); //Añades acciones al diccionario 
        _actions.Add("RunAway", CalculateRun);
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
        Vector3 desiredVelocity = ((target.position - transform.position).normalized * speed);
        steering = desiredVelocity - velocity;

        velocity += steering;
        transform.position += velocity * Time.deltaTime;
    }
    void CalculateRun()
    {
        Vector3 desiredVelocity = ((target.position - transform.position).normalized * speed);
        steering = desiredVelocity - velocity;

        velocity += steering;
        transform.position -= velocity * Time.deltaTime;
    }
}
