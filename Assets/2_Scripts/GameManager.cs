using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore;
    private int score;

    private void Awake()
    {
        Instance = this;
    }

    internal void CalculateScore(bool isApple)
    {
        if(isApple)
        {
            score++;
        }
        else
        {
            score--;
        }
        UiManager.instance.OnScoreChange(this.score, maxScore);
    }
}
