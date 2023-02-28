using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class simpleText : MonoBehaviour
{
    public ContenedorPersonas contenedorPersonas;

    TMP_Text jokeText;
    TMP_Text answerText;
    public bool oneortwo = true;
    void Awake()
    {
        jokeText = gameObject.GetComponent<TMP_Text>();
        answerText = gameObject.GetComponent<TMP_Text>();
    }
    private void Update()
    {
        if (GameManager.obj.jokeAnswer)
        {
            printJoke();
        }
        else
        {
            printAnswer();
        }
    }

    public void printJoke() 
    {
        string personasText ="";
        foreach(Persona p in contenedorPersonas.personas)
        {
            personasText += p.joke ;
            //personasText+=p.direccion+", ";
            //personasText += p.email + ", ";
        }
        jokeText.text=personasText;
    }
    public void printAnswer()
    {
        string personasText = "";
        foreach (Persona p in contenedorPersonas.personas)
        {
            personasText += p.answer;
            //personasText+=p.direccion+", ";
            //personasText += p.email + ", ";
        }
        answerText.text = personasText;
    }
}
