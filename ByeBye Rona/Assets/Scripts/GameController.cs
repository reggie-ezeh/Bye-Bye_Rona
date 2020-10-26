using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    [SerializeField]
    Image BgReference;
    [SerializeField]
    Sprite[] AllBackgrounds;
    Sprite playerBg;

    [SerializeField]
    TextMeshProUGUI timer_text;

    [SerializeField]
    Sanitizer sanitizer;

    [SerializeField]
    TextMeshProUGUI high_score_text;

    float current_score;
    float high_score;

    [SerializeField]
    int virus_population_max;

    //turn this off when soap is out
    public bool playing;

    public bool game_over;

    [SerializeField]
    Image population_bar;

    int current_virus_population;

    [SerializeField]
    TextMeshProUGUI population_text;

    [SerializeField]
    GameObject game_over_screen;

    public float seconds_to_max_difficulty;


    void Start()
    {
        playing = true;
        population_bar = population_bar.GetComponent<Image>();
        game_over_screen.SetActive(false);
        game_over = false;
        current_score = 0;
        current_virus_population = 0;
        Time.timeScale = 1;
        InitBg();

        //if a high score already exists, display it
        if (PlayerPrefs.HasKey("HighScore"))
        {
            high_score_text.text = PlayerPrefs.GetFloat("HighScore").ToString("f2");
            high_score = PlayerPrefs.GetFloat("HighScore");
            int minutes = Mathf.FloorToInt(high_score / 60f);
            int seconds = Mathf.FloorToInt(high_score % 60f);
            int milliseconds = Mathf.FloorToInt((high_score * 100f) % 100f);
            high_score_text.text = minutes + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
        }
        else
        {
            high_score_text.text = "0:00";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (game_over)
        {
            return;
        }

        CaluculateScore();

        current_virus_population = VirusController.instance.alive_viruses.Count;
        population_bar.fillAmount =  ( (float) current_virus_population/ virus_population_max);
        population_text.text = current_virus_population.ToString() + "/" + virus_population_max.ToString();

        if ( current_virus_population> virus_population_max)
        {
            EndGame();
        }
    }

    void InitBg()
    {
        playerBg = AllBackgrounds[PlayerPrefs.GetInt("SelectedBackground")];
        BgReference.sprite = playerBg;
    }

    public float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / seconds_to_max_difficulty);
    }

    void CaluculateScore()
    {
        if (playing)
        {
            current_score += Time.deltaTime;
            int minutes = Mathf.FloorToInt(current_score / 60f);
            int seconds = Mathf.FloorToInt(current_score % 60f);
            int milliseconds = Mathf.FloorToInt((current_score * 100f) % 100f);
            timer_text.text = minutes + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
        }
    }

    public void EndGame()
    {
        game_over = true;
        timer_text.color = Color.red;

        game_over_screen.SetActive(true);

        if (current_score > PlayerPrefs.GetFloat("HighScore") )
        {
            SetHighScore();
        }

        sanitizer.enable_shooter = false;
        VirusController.instance.viruses_can_expire = false;
        VirusController.instance.viruses_can_spawn = false;
        VirusController.instance.viruses_can_upgrade = false;

        int new_playtime= PlayerPrefs.GetInt("GamesPlayed") + 1;
        PlayerPrefs.SetInt("GamesPlayed", new_playtime);
    }

    void SetHighScore()
    {
        PlayerPrefs.SetFloat("HighScore", current_score);
        high_score= PlayerPrefs.GetFloat("HighScore");

        int minutes = Mathf.FloorToInt(high_score / 60f);
        int seconds = Mathf.FloorToInt(high_score % 60f);
        int milliseconds = Mathf.FloorToInt((high_score * 100f) % 100f);
        high_score_text.text = minutes + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");

        //Display message "NEW High Score: PlayerPrefs.GetInt("Highscore") "
    }
}
