using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartBtn : MonoBehaviour
{

    public void ClickStartBtn()
    {
        SceneManager.LoadScene("Main");
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
