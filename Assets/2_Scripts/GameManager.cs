using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore;
    [SerializeField] private int notegroupcreatscore = 10;
    [SerializeField] private GameObject gameClearObj;
    [SerializeField] private GameObject gameOverObj;

    private int score;
    private int nextnotegroupscore;

    [SerializeField] private float maxtime = 30f;

    public bool IsGameDone
    {
        get
        {
            if (gameClearObj.activeSelf || gameOverObj.activeSelf)
                return true;
            else
                return false;
        }
    }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UiManager.instance.OnScoreChange(this.score, maxScore);
        NoteManager.instance.Create();

        gameClearObj.SetActive(false);
        gameOverObj.SetActive(false);

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

            if(IsGameDone)
            {
                yield break;
            }
        }

        //gmaeover
        gameOverObj.SetActive(true);
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
            
            if (maxScore <= score)
            {
                gameClearObj.SetActive(true);
            }

        }
        else
        {
            score--;
            nextnotegroupscore--;
        }

        UiManager.instance.OnScoreChange(score, maxScore);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
