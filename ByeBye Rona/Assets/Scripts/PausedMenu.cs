using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PausedMenu : MonoBehaviour
{
    public void ResumeGame()
    {
        GameController.instance.playing = true;
        Time.timeScale = 1;
        GameController.instance.is_paused = false;
        gameObject.SetActive(false);
        GameController.instance.HideBanner();
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

}

