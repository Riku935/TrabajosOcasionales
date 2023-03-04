using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    //Sintaxis
    private int _defense;
    private int _vida;
    private int _maxVelocity;
    private Rigidbody _rb;

    void CreatePlayer()
    {
        Player pedro = new Player("Pedro", 5); //Este metodo se usa cuando no depende de monobehaviour
        Player tobias = gameObject.AddComponent<Player>();  //Es lo mismo pero utilizando los metodos de unity
        
    }


    // private _minuscula = Fields(Variables privadas que solo se utilizan dentro de la misma clase)
    private int _vidas;

    // public minuscula = Instance (Variables normales)
    public int vida;

    // public mayuscula = Properties (Utiliza get y set)
    public int Vida { get; set;}
}
