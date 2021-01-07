using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialMenu : MonoBehaviour
{
    public GameObject tutorialMenu;
    [SerializeField]
    GameObject[] tutorial_panels;

    public void Start()
    {
        tutorialMenu.SetActive(true);
        foreach (GameObject panel in tutorial_panels)
        {
            panel.SetActive(false);
        }
    }

    public void GoHome()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void OpenTutorial(GameObject tutorial_page)
    {
        tutorialMenu.SetActive(false);
        tutorial_page.SetActive(true);
    }

    public void TutorialMain(GameObject current_page)
    {
        current_page.SetActive(false);
        tutorialMenu.SetActive(true);
    }
}
