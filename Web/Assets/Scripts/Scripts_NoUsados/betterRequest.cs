using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class betterRequest : MonoBehaviour
{
       string resutado ="";
   
    void Start()
    {
        StartCoroutine(GetRequest());
        Debug.Log("De regreso al metodo start");
        Debug.Log("Resultado: "+ resutado);
    }
   
    IEnumerator GetRequest()
    {
        string uri ="https://randomuser.me/api";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.Success:
                    Debug.Log( ":\nReceived: " + webRequest.downloadHandler.text);
                    resutado =webRequest.downloadHandler.text; 
                    
                    break;
            }
        }
    }
}
