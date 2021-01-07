using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject bg_selector_page;
    public GameObject audio_manager_page;
    public GameObject pu_upgrader_page;

    public void Start()
    {
        optionsMenu.SetActive(true);
        bg_selector_page.SetActive(false);
        audio_manager_page.SetActive(false);
        pu_upgrader_page.SetActive(false);

    }

    public void GoHome()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void OpenBgSelector()
    {
        optionsMenu.SetActive(false);
        bg_selector_page.SetActive(true);
    }

    public void OpenAudioManager()
    {
        optionsMenu.SetActive(false);
        audio_manager_page.SetActive(true);
    }

    public void OpenPuUpgrader()
    {
        optionsMenu.SetActive(false);
        pu_upgrader_page.SetActive(true);
    }

    public void OptionsMain(GameObject current_page)
    {
        current_page.SetActive(false);
        optionsMenu.SetActive(true);
    }
}
