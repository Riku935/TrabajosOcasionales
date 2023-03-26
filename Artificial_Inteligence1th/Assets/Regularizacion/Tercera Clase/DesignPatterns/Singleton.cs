using UnityEngine;

public class Singleton : MonoBehaviour
{
    //Fields
    private static Singleton _instance;
    
    //Properties
    public static Singleton Instance 
    {
        get
        {
            if(Instance == null)
            {
                Debug.Log("Game manager no existe en la escena");
            }
            return _instance;
        }
        set
        {
            Instance = value;
        } 
    }


    private void Awake()
    {
        //Verificar si ya existe una instancia Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        //Si no existe
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
