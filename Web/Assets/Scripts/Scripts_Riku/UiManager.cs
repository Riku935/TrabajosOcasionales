using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager obj;
    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject jokePanel;
    public GameObject answerPanel;
    private void Awake()
    {
        obj = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void StartGame()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);

    }
    public void LikeButton()
    {
        GameManager.obj.like = true;
        GameManager.obj.Dislike = false;
        GameManager.obj.next = false;
        GameManager.obj.Reaload = false;

    }
    public void DisLikeButton()
    {
        GameManager.obj.Dislike = true;
        GameManager.obj.like = false;
        GameManager.obj.next = false;
        GameManager.obj.Reaload = false;
    }
    public void NewJoke()
    {
        GameManager.obj.Reaload = true;
        GameManager.obj.like = false;
        GameManager.obj.Dislike = false;
        GameManager.obj.next = false;
        jokePanel.SetActive(true);
        answerPanel.SetActive(false);
        GameManager.obj.jokeAnswer = true;
    }
    public void NextButton()
    {
        jokePanel.SetActive(false);
        answerPanel.SetActive(true);
        GameManager.obj.jokeAnswer = false;
        GameManager.obj.next = true;
        GameManager.obj.Reaload = false;
    }
    private void OnDestroy()
    {
        obj = null;
    }
}
