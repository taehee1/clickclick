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
    [SerializeField] private KeyCode keyCode;

    public KeyCode KeyCode
    {
        get
        {
            return keyCode;
        }
    }

    private List<Note> noteList = new List<Note>();

    void Start()
    {
        for (int i = 0; i < noteMaxNum; i++)
        {
            CreateNote(true);
        }
    }

    private void CreateNote(bool isApple)
    {
        GameObject noteGameobj = Instantiate(notePrefab);
        noteGameobj.transform.SetParent(noteSpawn.transform);
        noteGameobj.transform.localPosition = Vector3.up * this.noteList.Count * noteGap;
        Note note = noteGameobj.GetComponent<Note>();
        note.SetSprite(isApple);

        noteList.Add(note);
    }

    public void OnInput(bool isApple)
    {
        //노트삭제
        if (noteList.Count > 0)
        {
            Note delNote = noteList[0];
            delNote.DeleteNote();
            noteList.RemoveAt(0);
        }

        //노트생성
        CreateNote(isApple);

        for (int i = 0; i < noteList.Count; i++)
            noteList[i].transform.localPosition = Vector3.up * i * noteGap;

        //노트 애니메이션
        anim.Play();
        btnSpriteRenderer.sprite = selectBtnSprite;
    }

    public void callAniDone()
    {
        btnSpriteRenderer.sprite = normalBtnSprite;
    }
}
