using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Request : MonoBehaviour
{
    public string ipAddress = "172.16.48.32";
    private string rutaArchivo = "C:\\Apache24\\htdocs\\api\\v1\\dinamico\\score";

    private string responseText;
    public InputField ipsInputField;

    public List<string> ipsList = new List<string>();

    public List<string> namesList = new List<string>();
    public List<string> ageList = new List<string>();
    public List<string> viciosList = new List<string>();
    public List<string> lenguajesList = new List<string>();


    private void Start()
    {
        Debug.Log(ipAddress);
    }

    public void Probar()
    {
        StartCoroutine(MakeRequest());
    }
    public void imprimir()
    {
        string textoLista = string.Join(", ", ipsList);
        ipsInputField.text = textoLista;
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

        HashSet<string> direccionesIP = ParsearRespuesta(respuesta);

        foreach (string direccionIP in direccionesIP)
        {
            Debug.Log(direccionIP);
            ipsList.Add(direccionIP);
        }
        imprimir();
    }
    public static HashSet<string> ParsearRespuesta(string respuesta)
    {
        HashSet<string> direccionesIP = new HashSet<string>();

        string[] partes = respuesta.Split(new[] { '(', ')', '[', ']', ',', '\'' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < partes.Length; i += 2)
        {
            string parteActual = partes[i].Trim();
            if (EsDireccionIPValida(parteActual))
            {
                direccionesIP.Add(parteActual);
            }
        }
        return direccionesIP;
    }
    public static bool EsDireccionIPValida(string cadena)
    {
        System.Net.IPAddress direccionIP;
        return System.Net.IPAddress.TryParse(cadena, out direccionIP);
    }

}
