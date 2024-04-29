using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTmp;
    public TextMeshProUGUI bestScoreTmp;
    public static int score;
    public static int bestScore;
    AudioSource audioSource;

    private void Start()
    {
        scoreTmp.text = $"Score : {score}";
        bestScoreTmp.text = $"Best Score : {bestScore}";
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
