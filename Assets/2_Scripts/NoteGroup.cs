using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject notePrefab = null;
    [SerializeField] private GameObject noteSpawn;
    [SerializeField] private float noteGap = 6f;

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

    void Update()
    {
        
    }
}
