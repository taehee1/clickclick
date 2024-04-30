using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smile : MonoBehaviour
{
    public Animator smileanim;
    public static Smile Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Smileanim()
    {
        smileanim.Play("smile",-1,0);
    }
}
