using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject notePrefab = null;
    [SerializeField] private GameObject noteSpawn;
    [SerializeField] private float noteGap = 6f;

    [SerializeField] private SpriteRenderer btnSpriteRenderer;
    [SerializeField] private Sprite normalBtnSprite;
    [SerializeField] private Sprite selectBtnSprite;
    [SerializeField] private Animation anim;

    private List<Note> noteList = new List<Note>();

    void Start()
    {
        for (int i = 0; i < noteMaxNum; i++)
        {
            GameObject noteGameobj = Instantiate(notePrefab);
            noteGameobj.transform.SetParent(noteSpawn.transform);
            noteGameobj.transform.localPosition = Vector3.up * this.noteList.Count * noteGap;
            Note note = noteGameobj.GetComponent<Note>();

            noteList.Add(note);
        }
    }
    public void OnInput(bool isSelect)
    {
        if (isSelect)
        {
            anim.Play();
            btnSpriteRenderer.sprite = selectBtnSprite;
        }
    }

    public void callAniDone()
    {
        btnSpriteRenderer.sprite = normalBtnSprite;
    }
}
