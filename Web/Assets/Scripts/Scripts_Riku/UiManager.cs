using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager obj;
    public GameObject startPanel;
    public GameObject gamePanel;
    private void Awake()
    {
        obj = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void StartGame()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);

    }
    private void OnDestroy()
    {
        obj = null;
    }
}
