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
    private void Start()
    {
        UiManager.instance.OnScoreChange(this.score, maxScore);
        NoteManager.instance.Create();
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

        UiManager.instance.OnScoreChange(score, maxScore);
    }
}
