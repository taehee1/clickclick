using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private GameObject noteGroupPrefabs;
    [SerializeField] private float noteGroupGap = 1f;
    [SerializeField]
    private KeyCode[] wholeKeyCodesArr = new KeyCode[]
    {
        KeyCode.A,KeyCode.S,KeyCode.D,KeyCode.F,KeyCode.G,KeyCode.H,KeyCode.J,KeyCode.K,KeyCode.L
    };
    [SerializeField] private int initNoteGroupNum = 2;

    public static NoteManager instance;
    private List<NoteGroup> noteGroupList = new List<NoteGroup>();
    
    private void Awake()
    {
        instance = this;
    }

    public void Create()
    {
        for(int i = 0; i < initNoteGroupNum; i++)
        {
            CreateNoteGroup(wholeKeyCodesArr[i]);
        }
    }

    public void CreateNoteGroup()
    {
        int noteGroupCount = noteGroupList.Count;
        KeyCode keyCode = wholeKeyCodesArr[noteGroupCount];
        CreateNoteGroup(keyCode);
    }

    public void CreateNoteGroup(KeyCode keyCode)
    {
        GameObject noteGroupObj = Instantiate(noteGroupPrefabs);
        noteGroupObj.transform.position = Vector3.right * noteGroupList.Count * noteGroupGap;

        NoteGroup noteGroup = noteGroupObj.GetComponent<NoteGroup>();
        noteGroup.Create(keyCode);

        noteGroupList.Add(noteGroup);
    }

    public void OnInput(KeyCode keyCode)
    {
        int randid = Random.Range(0, 2);
        bool isApple = randid == 0 ? true : false;

        foreach (NoteGroup noteGroup in noteGroupList)
        {
            if(keyCode == noteGroup.KeyCode)
            {
                noteGroup.OnInput(isApple);
                break;
            }
        }
    }
}