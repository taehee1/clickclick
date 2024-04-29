using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTmp;
    AudioSource audioSource;
    

    private void Start()
    {
        scoreTmp.text = $"Score : {GameManager.Instance.score}";
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
