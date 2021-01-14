using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PausedMenu : MonoBehaviour
{
    public void ResumeGame()
    {
        Time.timeScale = 1;
        GameController.instance.is_paused = false;
        gameObject.SetActive(false);
        AdManager.HideBanner();
        AdManager.HideBanner();
    }

    public void Restart()
    {
        AdManager.HideBanner();
        SceneManager.LoadScene(1);
        AdManager.HideBanner();
    }

    public void Quit()
    {
        AdManager.HideBanner();
        Time.timeScale = 1;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        AdManager.HideBanner();
    }

}

