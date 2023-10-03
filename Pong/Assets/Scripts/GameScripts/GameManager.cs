using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text paddle1Score;
    [SerializeField] private TMP_Text paddle2Score;
    [SerializeField] private Transform paddle1Transform;
    [SerializeField] private Transform paddle2Transform;
    [SerializeField] private Transform ballTransform;

    private int paddleScore1;
    private int paddleScore2;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public void Paddle1Scored()
    {
        paddleScore1++;
        paddle1Score.text = paddleScore1.ToString();

    }
    public void Paddle2Scored()
    {
        paddleScore2++;
        paddle2Score.text = paddleScore2.ToString();

    }
    public void Restart()
    {
        paddle1Transform.position = new Vector2(paddle1Transform.position.x, 0);
        paddle2Transform.position = new Vector2(paddle2Transform.position.x, 0);
        ballTransform.position = new Vector2(0, 0);

    }
}
