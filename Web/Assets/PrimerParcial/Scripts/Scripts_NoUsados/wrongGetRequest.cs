using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using TMPro;
using System;

public class wrongGetRequest : MonoBehaviour
{
    string resutado ="";
   
    string Url ="https://randomuser.me/api";

    void Start()
    {
        GetRequest(Url);
        Debug.Log("Resultado: "+ resutado);
    }
   
    void GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            webRequest.SendWebRequest();
            Debug.Log(webRequest.result);
            Debug.Log( ":\nReceived: " + webRequest.downloadHandler.text);
            resutado =webRequest.downloadHandler.text; 
        }
    }
}
