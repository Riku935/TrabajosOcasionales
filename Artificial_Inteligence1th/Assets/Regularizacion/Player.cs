using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string _name;
    public int _health;
    //Constructor
    //Su funcion es inicializar los fields al momento de la creacion de la clase
    public Player(string name, int health) 
    {
        _name = name;
        _health = health;
    }
}
