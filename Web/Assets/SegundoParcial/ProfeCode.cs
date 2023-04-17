using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ProfeCode : MonoBehaviour
{
    

    class PostItem
    {
        public string Game_Name;
        public bool IsReleased;
        public string ReleaseDay;
        public string ReleaseMonth;
        public string ReleaseYear;

        public PostItem(string gameName, bool released, string day, string month, string year)
        {
            this.Game_Name = gameName;
            IsReleased = released;
            ReleaseDay = day;
            ReleaseMonth = month;
            ReleaseYear = year;
        }
    }
    //[SerializeField] string nameGame = "Mario Bros";
    public InputField nameGame;
    public bool gameReleased = true;

    [SerializeField] InputField day;
    [SerializeField] InputField month;
    [SerializeField] InputField year;

    [SerializeField] InputField urlField;


    async void Start()
    {
        //await PostRequest();
    }
    public async void StartPost()
    {
        await PostRequest();
    }

    public void YesButton()
    {
        gameReleased = true;
    }
    public void NoButton()
    {
        gameReleased = false;
    }
    async Task PostRequest()
    {
        string url = urlField.text.ToString();
        PostItem mypost = new PostItem(nameGame.text.ToString(), gameReleased, day.text.ToString(), month.text.ToString(), year.text.ToString());
        string payload = JsonUtility.ToJson(mypost);
        UploadHandler customUploadHandler = new UploadHandlerRaw(
            System.Text.Encoding.UTF8.GetBytes(payload));
        customUploadHandler.contentType = "application/json";

        using var www = new UnityWebRequest(url, "POST");
        www.uploadHandler = customUploadHandler;
        www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        var operation = www.SendWebRequest();

        while (!operation.isDone)
            await Task.Yield();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            Debug.Log("Something failed: " + www.downloadHandler.text);
        }
    }
}
