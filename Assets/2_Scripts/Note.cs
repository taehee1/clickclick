using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private SpriteRenderer SpriteRenderer;
    [SerializeField] private Sprite appleSprite;
    [SerializeField] private Sprite blueberrySprite;

    private bool isApple;

    public void Destroy()
    {
        GameObject.Destroy(gameObject);
    }

    public void DeleteNote()
    {
        GameManager.Instance.CalculateScore(isApple);
        if (isApple )
        {
            SoundManager.instance.Sound(0);
        }
        else
        {
            SoundManager.instance.Sound(1);
        }
        Destroy();
    }

    internal void SetSprite(bool isApple)
    {
        this.isApple = isApple;
        SpriteRenderer.sprite = isApple ? appleSprite : blueberrySprite;
    }
}
