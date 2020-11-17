using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI game_over_info;

    [SerializeField]
    TextMeshProUGUI high_score_reference;

    [SerializeField]
    string[] random_messages;

    public void GenerateMessage()
    {
        if (GameController.instance.high_score_acheived)
        {
            game_over_info.text = "CONGRATS! New HighScore: " + high_score_reference.text;
        }
        else
        {
            game_over_info.fontSize = 30;
            game_over_info.color = Color.white;

            if (PlayerPrefs.GetInt("PUsFull") ==1)
            {
                var index = Random.Range(0, (random_messages.Length - 1));
                game_over_info.text = random_messages[index];
            }
            else
            {
                game_over_info.text = "Hint: Upgrading your PowerUps can help you achieve a higher score " +
                    "You can upgrade your PowerUps from the Options Menu"; 
            }

        }
    }

    public void GoToMain()
    {
        Time.timeScale = 1;
        AdManager.HideBanner();
        SceneManager.LoadScene(0);
        int playcount = PlayerPrefs.GetInt("GamesPlayed");
        if (playcount % 3 == 2)
        {
            AdManager.ShowStandardAd();
        }
    }

    public void TryAgain()
    {
        AdManager.HideBanner();
        gameObject.SetActive(false);
        int playcount = PlayerPrefs.GetInt("GamesPlayed");
        if (playcount % 3 == 1)
        {
            AdManager.ShowStandardAd();
        }
        SceneManager.LoadScene(1);
    }
}

