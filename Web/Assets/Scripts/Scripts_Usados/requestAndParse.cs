using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System;
using SimpleJSON;
using UnityEditor;
using UnityEngine.Events;
public class requestAndParse: MonoBehaviour{
string resutado ="";
public ContenedorPersonas contenedorPersonas;
public UnityEvent evento;

[SerializeField]
int numResultados = 2;
async void Start(){
    //await GetRequest();
    // Debug.Log("De regreso al metodo start");
    // Debug.Log("Resultado: "+ resutado);
}

    async public void Request()
    {
        await GetRequest();
    }
    async Task GetRequest(){
     //string Url ="https://randomuser.me/api?results="+ numResultados;
     
     string Url = "https://official-joke-api.appspot.com/random_joke";
     using var www = UnityWebRequest.Get(Url);

     var operation = www.SendWebRequest();

     while(!operation.isDone)
        await Task.Yield();

    if(www.result== UnityWebRequest.Result.Success){
        //contenedorPersonas.personas = new Persona; ESTO ES LO QUE HAY QUE CAMBIAR
        Debug.Log($"Success: {www.downloadHandler.text}");
        resutado =www.downloadHandler.text; 
        try{
            JSONNode root = JSONNode.Parse(resutado);
            //Debug.Log("Raiz: "+ root);
            //Debug.Log(root["setup"]);
            Debug.Log(root["setup"]);
            Debug.Log(root["punchline"]);

                //foreach (var r in root["results"]){
                        // Debug.Log(r);
                        // Debug.Log(r.Value);

                        //Debug.Log(r.Value["name"]); 
                        //Debug.Log(r.Value["name"]["first"]);
                        Persona p = ScriptableObject.CreateInstance<Persona>();

                        p.joke = (root["setup"]);
                        p.answer = (root["punchline"]);
                        //p.nombre = r.Value["name"]["first"];
                        //p.apellido=r.Value["name"]["last"];
                        //p.direccion = r.Value["location"]["street"]["number"];
                        //p.email = r.Value["email"];


                    // Debug.Log(r.Value["name"]); 
                    // Debug.Log(r.Value["name"]["first"]);


                    //AssetDatabase.CreateAsset(p, "Assets/Personas/"+p.nombre+".asset");
                    contenedorPersonas.personas.Add(p);
                    //}
                    evento.Invoke();
                     
        }
        catch{
            Debug.Log("Algo salio mal convirtiendo la respuesta en objetos");
        }
    }
}
}