using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Post : MonoBehaviour
{
    private string serverIP = "tu_direccion_ip"; // Reemplaza "tu_direccion_ip" con la dirección IP a la que deseas enviar los datos.
    private string postURL = "http://172.16.48.37:5000/serv/ricardo/score"; // Reemplaza "tu_ruta_api" con la ruta de tu API.
    private string url = "http://172.16.48.37:5000/serv/ricardo/score/";
    public string playerName;
    public int playerScore;
    private void Update()
    {
        playerName = GameManager.instance.highestName;
        playerScore = GameManager.instance.highestScore;
    }
    public void SendData()
    {
        StartCoroutine(PostData());
    }
   
    IEnumerator PostData()
    {
        WWWForm form = new WWWForm();
        form.AddField("data", playerScore);

        // Crear una solicitud POST
        UnityWebRequest request = UnityWebRequest.Post(url, form);

        // Enviar la solicitud y esperar la respuesta
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            Debug.Log("Solicitud POST exitosa");
            Debug.Log("Respuesta del servidor: " + request.downloadHandler.text);
        }
    }
}
