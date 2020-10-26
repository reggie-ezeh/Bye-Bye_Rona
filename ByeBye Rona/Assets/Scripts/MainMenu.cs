using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Startgame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void OpenTutorial()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void OpenOptions() 
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    public void OpenExtras()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }

    public void OpenLeaderboard()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }


}
