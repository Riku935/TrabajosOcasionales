using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Post : MonoBehaviour
{
    private string serverIP = "tu_direccion_ip"; // Reemplaza "tu_direccion_ip" con la dirección IP a la que deseas enviar los datos.
    private string postURL = "http://" + "172.12.123." + "/tu_ruta_api"; // Reemplaza "tu_ruta_api" con la ruta de tu API.

    public string playerName;
    public int playerScore;
    private void Update()
    {
        playerName = GameManager.instance.highestName;
        playerScore = GameManager.instance.highestScore;
    }
    public void SendData()
    {
        StartCoroutine(PostData(playerName, GameManager.instance.highestScore));
    }
   
    IEnumerator PostData(string name, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre", name);
        form.AddField("score", score.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post(postURL, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError("Error al enviar datos: " + www.error);
            }
            else
            {
                Debug.Log("Datos enviados con éxito.");
            }
        }
    }
}
