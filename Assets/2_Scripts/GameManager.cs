using System;
using System.Collections;
using Unity.VisualScripting;
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
    [SerializeField] private float maxtime = 30f;

    private int nextnotegroupscore;

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
        UiManager.instance.OnScoreChange(ScoreManager.score, maxScore);
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

        if (ScoreManager.score > ScoreManager.bestScore)
        {
            ScoreManager.bestScore = ScoreManager.score;
            PlayerPrefs.SetInt("bestScore", ScoreManager.bestScore);
        }

        //gmaeover
        SceneManager.LoadScene("Gameover Scene");
    }

    internal void CalculateScore(bool isApple)
    {
        if(isApple)
        {
            ScoreManager.score++;
            nextnotegroupscore++;

            if(notegroupcreatscore <= nextnotegroupscore)
            {
                nextnotegroupscore = 0;
                NoteManager.instance.CreateNoteGroup();
            }
            
            if (maxScore <= ScoreManager.score)
            {
                gameClearObj.SetActive(true);
            }

        }
        else
        {
            ScoreManager.score--;
            nextnotegroupscore--;
        }

        UiManager.instance.OnScoreChange(ScoreManager.score, maxScore);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
