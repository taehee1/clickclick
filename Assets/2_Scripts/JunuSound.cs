using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunuSound : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioSource AudioSource1;
    private int JunuAngry;

    public void Junu()
    {
        JunuAngry++;
        if (JunuAngry > 5)
        {
            AudioSource1.Play();
            JunuAngry = 0;
        }
        else
        {
            AudioSource.Play();
        }
    }
}
