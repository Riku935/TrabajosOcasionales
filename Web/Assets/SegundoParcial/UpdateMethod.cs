using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using UnityEngine.UI;
using System;

public class UpdateMethod : MonoBehaviour
{
    class PostItem
    {
        public string i_d;
        public string Game_Name;
        public bool IsReleased;
        public string ReleaseDay;
        public string ReleaseMonth;
        public string ReleaseYear;

        public PostItem(string ID ,string gameName, bool released, string day, string month, string year)
        {
            i_d = ID;
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
    [SerializeField] InputField id;

    //public int id;

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
        string url = urlField.text.ToString()+"/"+id;
        PostItem mypost = new PostItem(id.text.ToString(),nameGame.text.ToString(), gameReleased, day.text.ToString(), month.text.ToString(), year.text.ToString());
        string payload = JsonUtility.ToJson(mypost);
        UploadHandler customUploadHandler = new UploadHandlerRaw(
            System.Text.Encoding.UTF8.GetBytes(payload));
        customUploadHandler.contentType = "application/json";

        using var www = new UnityWebRequest(url, "PUT");
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
