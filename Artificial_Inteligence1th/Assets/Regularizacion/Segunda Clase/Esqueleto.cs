using UnityEngine;
public class Esqueleto : Enemigo, IInteligencia
{
    void Start()
    {
        vida = 5f;
        defensa = 0f;
        velocidad = 2f;
    }
    public void Patrullar()
    {

    }
    public void Detecta()
    {

    }
    public Vector3 Persigue()
    {
        return Vector3.zero;
    }
}
