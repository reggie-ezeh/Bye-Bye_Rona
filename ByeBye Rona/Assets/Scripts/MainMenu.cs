using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    int visited;
    public GameObject testpanel;

    void Start()
    {
        visited = PlayerPrefs.GetInt("OpenedMenu") + 1;
        PlayerPrefs.SetInt("OpenedMenu", visited);
        StartCoroutine(BannerHide());
        //////Tester//////
        testpanel.SetActive(false);
    }


    public void Startgame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void OpenTutorial()
    {
        if (visited % 3 == 0) { AdManager.ShowStandardAd(); }
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void OpenOptions() 
    {
        if (visited % 3 == 1) { AdManager.ShowStandardAd(); }
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    public void OpenExtras()
    {
        if (visited % 3 == 2) { AdManager.ShowStandardAd(); }
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }

    public void OpenTester()
    {
        testpanel.SetActive(true);
    }

    IEnumerator BannerHide()
    {
        while (true)
        {
            AdManager.HideBanner();
            yield return new WaitForSeconds(1.5f);
        }
    }
}
