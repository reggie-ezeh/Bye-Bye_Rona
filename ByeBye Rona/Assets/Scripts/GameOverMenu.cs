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
    string hint_message;

    [SerializeField]
    string new_hs_message;

    [SerializeField]
    string[] random_messages;

    public void GenerateMessage()
    {
        if (GameController.instance.high_score_acheived)
        {
            game_over_info.text = new_hs_message + high_score_reference.text;
            StartCoroutine(Yay());
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
                game_over_info.text = hint_message; 
            }
        }
    }

    public void GoHome()
    {
        Time.timeScale = 1;
        AdManager.HideBanner();
        SceneManager.LoadScene(0);
        int playcount = PlayerPrefs.GetInt("GamesPlayed");
        if (playcount % 4 == 2)
        {
            AdManager.ShowStandardAd();
        }
    }

    public void TryAgain()
    {
        AdManager.HideBanner();
        gameObject.SetActive(false);
        int playcount = PlayerPrefs.GetInt("GamesPlayed");
        if (playcount % 4 == 1)
        {
            AdManager.ShowStandardAd();
        }
        SceneManager.LoadScene(1);
    }

    IEnumerator Yay()
    {
        yield return new WaitForSeconds(1.5f);
        AudioManager.instance.Play("HighScore");
    }
}

