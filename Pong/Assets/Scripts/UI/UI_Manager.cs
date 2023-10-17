using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI_Manager : MonoBehaviour
{
    public string name1;
    public string name2;

    public static UI_Manager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void updateNames()
    {
        name1 = Request_Names.instance.name1;
        name2 = Request_Names.instance.name2;
        PlayerPrefs.SetString("Player1", name1);
        PlayerPrefs.SetString("Player2", name2);
    }
}
