using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameReady = false;
    public bool jokeAnswer = true;
    public static GameManager obj;
    private void Awake()
    {
        obj = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        StartGame();
    }
    void StartGame()
    {
        if (gameReady == true) 
        {
            UiManager.obj.StartGame();
        }
    }
    private void OnDestroy()
    {
        obj = null;
    }
}
