using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PausedMenu : MonoBehaviour
{
    public GameObject paused_menu;
    public bool is_paused;

    [SerializeField]
    GameController gameController;

    void Start()
    {
        paused_menu.SetActive(false);
        is_paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        if (!gameController.game_over)
        {
            paused_menu.SetActive(true);
            Time.timeScale = 0;
            is_paused = true;
        }

    }

    public void ResumeGame()
    {
        paused_menu.SetActive(false);
        Time.timeScale = 1;
        is_paused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

}

