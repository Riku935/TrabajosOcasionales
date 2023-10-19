using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class Request : MonoBehaviour
{
    public string ipAddress = "http://172.16.48.37:5000/serv/ricardo/get/score";
    private string rutaArchivo = "C:\\Apache24\\htdocs\\api\\v1\\dinamico\\score";

    private string responseText;
    [SerializeField] private TMP_Text maxScore;

    public float respuesta;

    private void Start()
    {
        //Debug.Log(ipAddress);
        StartCoroutine(MakeRequest());

    }
    private void Update()
    {
        maxScore.text = "Max Score:" + responseText;
        updateScore();
    }
    void updateScore()
    {
        if (GameManager.instance.score1 > respuesta)
        {
            maxScore.text = "Max Score:" + GameManager.instance.score1;

        }
        if (GameManager.instance.score2 > respuesta)
        {
            maxScore.text = "Max Score:" + GameManager.instance.score2;

        }
        if (GameManager.instance.score2 > GameManager.instance.score1)
        {
            //maxScore.text = "Max Score:" + GameManager.instance.score2;

        }
        if (GameManager.instance.score1 > GameManager.instance.score2)
        {
            //maxScore.text = "Max Score:" + GameManager.instance.score1;

        }
    }
    public void Probar()
    {
    }
    public void imprimir()
    {
        //string textoLista = string.Join(", ", ipsList);
        //ipsInputField.text = textoLista;
    }
    IEnumerator MakeRequest()
    {
        while (true)
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
                    //File.WriteAllText(rutaArchivo, responseText);
                    //Parsear();
                    if (float.TryParse(responseText, out respuesta))
                    {
                        Debug.Log(respuesta);
                    }
                }

            }
            yield return new WaitForSecondsRealtime(2f);
        }
        
    }
    public void Parsear()
    {
        string respuesta = responseText;

        HashSet<string> direccionesIP = ParsearRespuesta(respuesta);

        foreach (string direccionIP in direccionesIP)
        {
            Debug.Log(direccionIP);
            //ipsList.Add(direccionIP);
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
