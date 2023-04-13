using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DeleteMethod : MonoBehaviour
{
    UnityWebRequestAsyncOperation operation;
    //public string apiUrl = "http://localhost:5057/api/releaseditems";
    //public int id;
    public InputField id;
    public InputField apiUrl;

    private async void Start()
    {
        
    }

    public async void Delete()
    {
        await DeleteElement();
        Debug.Log("lo hace");
    }

    public async Task DeleteElement()
    {
        string newUrl = apiUrl.text.ToString() + "/" + id.text.ToString();
        UnityWebRequest request = UnityWebRequest.Delete(newUrl);
        operation = request.SendWebRequest();
        while (!operation.isDone) { await Task.Yield(); }
    }
}
