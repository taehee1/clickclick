using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore;
    [SerializeField] private int notegroupcreatscore = 10;

    private int score;
    private int nextnotegroupscore;

    [SerializeField] private float maxtime = 30f;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UiManager.instance.OnScoreChange(this.score, maxScore);
        NoteManager.instance.Create();

        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        float currentTime = 0;

        while (currentTime < maxtime)
        {
            currentTime += Time.deltaTime;
            UiManager.instance.OnTimerChange(currentTime, maxtime);
            yield return null;
        }

        //gmaeover
        Debug.Log("gameover");
    }

    internal void CalculateScore(bool isApple)
    {
        if(isApple)
        {
            score++;
            nextnotegroupscore++;

            if(notegroupcreatscore <= nextnotegroupscore)
            {
                nextnotegroupscore = 0;
                NoteManager.instance.CreateNoteGroup();
            }

        }
        else
        {
            score--;
            nextnotegroupscore--;
        }

        UiManager.instance.OnScoreChange(score, maxScore);
    }
}
