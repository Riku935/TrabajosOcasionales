using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private TMP_Text paddle1Score;
    [SerializeField] private TMP_Text paddle2Score;
    [SerializeField] private TMP_Text player1;
    [SerializeField] private TMP_Text player2;
    [SerializeField] private TMP_Text maxScore;

    [SerializeField] private Transform paddle1Transform;
    [SerializeField] private Transform paddle2Transform;
    [SerializeField] private Transform ballTransform;

    [SerializeField] public int highestScore;
    [SerializeField] public string highestName;


    public int score1;
    public int score2;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        player1.text = PlayerPrefs.GetString("Player1");
        player2.text = PlayerPrefs.GetString("Player2");
    }
    private void Update()
    {
        UpdateHighestScore();
        
    }
    void UpdateHighestScore()
    {
        if (score1 > score2)
        {
            highestScore = score1;
            highestName = PlayerPrefs.GetString("Player1");
        }
        else
        {
            highestScore = score2;
            highestName = PlayerPrefs.GetString("Player2");

        }
    }

    public void Paddle1Scored()
    {
        score1++;
        paddle1Score.text = score1.ToString();

    }
    public void Paddle2Scored()
    {
        score2++;
        paddle2Score.text = score2.ToString();

    }
    public void Restart()
    {
        paddle1Transform.position = new Vector2(paddle1Transform.position.x, 0);
        paddle2Transform.position = new Vector2(paddle2Transform.position.x, 0);
        ballTransform.position = new Vector2(0, 0);
    }
    private void OnDestroy()
    {
        instance = null;
    }

}
