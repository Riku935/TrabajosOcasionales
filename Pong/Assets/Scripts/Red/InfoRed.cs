using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoRed : MonoBehaviour
{
    private Request requestScript;
    public InputField ipsInputField;

    private void Start()
    {
        requestScript = GetComponent<Request>();
        List<string> secondList = requestScript.ipsList;
    }
    public void imprimir()
    {
        List<string> secondList = requestScript.ipsList;
        string textoLista = string.Join(", ", secondList);
        ipsInputField.text = textoLista;
    }
}
