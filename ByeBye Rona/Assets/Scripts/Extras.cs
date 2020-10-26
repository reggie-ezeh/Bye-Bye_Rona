using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Extras : MonoBehaviour
{
    public GameObject extrasMenu;
    public GameObject howtoHelp_page;
    public GameObject credits_page;


    public void Start()
    {
        extrasMenu.SetActive(true);
        howtoHelp_page.SetActive(false);
        credits_page.SetActive(false);
    }

    public void GoHome()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void OpenHowToHelp()
    {
        extrasMenu.SetActive(false);
        howtoHelp_page.SetActive(true);
    }


    public void OpenCredits()
    {
        extrasMenu.SetActive(false);
        credits_page.SetActive(true);
    }


    public void WilliamIG()
    {
        Application.OpenURL("http://www.instagram.com/willswift/");
    }

    public void WebsiteLinker(string url)
    {
        Application.OpenURL(url);
    }
}
