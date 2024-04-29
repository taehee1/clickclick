using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Main");
        ScoreManager.score = 0;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
