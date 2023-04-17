using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager obj;
    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject jokePanel;
    public GameObject answerPanel;
    public GameObject LikePanel;
    public GameObject informationPanel;
    public TMP_Text goodJokes;
    public int goodJokesCount;
    private void Awake()
    {
        obj = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        UpdateJokes();
    }
    private void UpdateJokes()
    {
        goodJokes.text = "" + goodJokesCount;
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
        LikePanel.SetActive(false);
        goodJokesCount++;
    }
    public void DisLikeButton()
    {
        GameManager.obj.Dislike = true;
        GameManager.obj.like = false;
        GameManager.obj.next = false;
        GameManager.obj.Reaload = false;
        LikePanel.SetActive(false);
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
        LikePanel.SetActive(true);

        GameManager.obj.jokeAnswer = false;
        GameManager.obj.next = true;
        GameManager.obj.Reaload = false;
    }
    public void InformationPanel()
    {
        informationPanel.SetActive(true);
        gamePanel.SetActive(false);
    }
    public void closeInfo()
    {
        informationPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    private void OnDestroy()
    {
        obj = null;
    }
}
