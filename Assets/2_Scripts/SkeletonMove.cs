using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMove : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.CrossFade("Idle", 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.CrossFade("Walk", 0, 0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.CrossFade("Death",0,0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            anim.CrossFade("Attack",0,0);
        }
    }
}
