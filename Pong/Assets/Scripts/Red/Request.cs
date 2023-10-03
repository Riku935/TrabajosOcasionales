using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Request : MonoBehaviour
{
    public string ipAddress = "172.16.48.32";
    private string rutaArchivo = "C:\\Apache24\\htdocs\\api\\v1\\dinamico\\score";

    private string responseText;
    private void Start()
    {
        Debug.Log(ipAddress);
    }
    public void Probar()
    {
        StartCoroutine(MakeRequest());
    }
    IEnumerator MakeRequest()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(ipAddress))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error al realizar la solicitud: " + request.error);
            }
            else
            {
                responseText = request.downloadHandler.text;
                Debug.Log("Respuesta del servidor: " + responseText);
                File.WriteAllText(rutaArchivo, responseText);
                Parsear();
            }
        }
    }
    public void Parsear()
    {
        string respuesta = responseText;

        List<string> nombres = ParsearRespuesta(respuesta);

        foreach (string nombre in nombres)
        {
            Debug.Log(nombre);
        }
    }
    public static List<string> ParsearRespuesta(string respuesta)
    {
        List<string> nombres = new List<string>();

        // Dividir la respuesta en tres partes usando las comas y paréntesis
        string[] partes = respuesta.Split(new[] { '(', ')', '[', ']', ',', '\'' }, StringSplitOptions.RemoveEmptyEntries);

        
        for (int i = 0; i < partes.Length; i += 2)
        {
            nombres.Add(partes[i].Trim());
        }

        return nombres;
    }
}
