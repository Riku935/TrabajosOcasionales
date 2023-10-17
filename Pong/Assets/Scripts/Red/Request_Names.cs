using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;
using System;
using TMPro;

public class Request_Names : MonoBehaviour
{
    public static Request_Names instance;
    public TMP_InputField ipInputField1;
    public TMP_InputField ipInputField2;
    public TMP_Text resultText1;
    public TMP_Text resultText2;
    public string name1;
    public string name2;
    private void Awake()
    {
        instance = this;
    }
    public void MakeRequests()
    {
        string ipAddress1 = ipInputField1.text + "/api/v1/nombre";
        string ipAddress2 = ipInputField2.text + "/api/v1/nombre";

        // Asegúrate de validar las direcciones IP antes de realizar las solicitudes.

        try
        {
            string response1 = GetInformationFromIP(ipAddress1);
            string response2 = GetInformationFromIP(ipAddress2);

            // Puedes procesar la información de las respuestas como lo necesites.
            resultText1.text =response1;
            resultText2.text =response2;
            name1 = response1;
            name2 = response2;
            Debug.Log(response1);
        }
        catch (Exception e)
        {
            Debug.LogError("Error en la solicitud: " + e.Message);
        }
    }

    private string GetInformationFromIP(string ipAddress)
    {
        using (WebClient client = new WebClient())
        {
            // Realiza una solicitud a la dirección IP.
            string response = client.DownloadString("http://" + ipAddress);

            return response;
        }
    }
    private void OnDestroy()
    {
        instance = null;
    }
}
