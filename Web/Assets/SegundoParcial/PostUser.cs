using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

public class PostUser : MonoBehaviour
{
    string nombre = "Mario Bros";
    void Start()
    {
        string url = "http://localhost:5057/api/releaseditems";
        WWWForm form = new WWWForm();
        form.AddField("game_Name", nombre);
        form.AddField("isReleased", "true");
        form.AddField("releaseDay", "6");
        form.AddField("releaseMonth", "4");
        form.AddField("releaseYear", "98");
        
        UnityWebRequest request = UnityWebRequest.Post(url, form);
        request.SetRequestHeader("Content-Type", "application/json");
        //request.uploadHandler = new UploadHandlerRaw(form.data);
        request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(JsonUtility.ToJson(form)));
        //request.downloadHandler = new DownloadHandlerBuffer();
        StartCoroutine(SendRequest(request));
        Debug.Log(JsonUtility.ToJson(form));
    }

    IEnumerator SendRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
        }
    }
}
