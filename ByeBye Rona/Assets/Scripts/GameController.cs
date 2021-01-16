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

    public bool high_score_acheived { get; set; }

    float current_score;
    float high_score;

    [SerializeField]
    int virus_population_max;

    //turn this off when soap is out
    public bool playing { get; set; }
    public bool game_over { get; set; }
    public bool is_paused { get; set; }


    [SerializeField]
    Image population_bar;

    int current_virus_population;

    [SerializeField]
    TextMeshProUGUI population_text;

    [SerializeField]
    GameObject game_over_screen;

    [SerializeField]
    GameObject paused_screen;
    
    [SerializeField]
    float seconds_to_max_difficulty;

    void Start()
    {
        playing = true;
        population_bar = population_bar.GetComponent<Image>();
        game_over_screen.SetActive(false);
        game_over = false;
        paused_screen.SetActive(false);
        is_paused = false;
        high_score_acheived = false;
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

        ////////////////Tester///////////
        //seconds_to_max_difficulty = PlayerPrefs.GetFloat("test_secs_to_max");
        //virus_population_max = PlayerPrefs.GetInt("test_population_max");
    }


    void Update()
    {
        if (game_over)
        {
            return;
        }
        CaluculateScore();

        current_virus_population = VirusController.instance.alive_viruses.Count;
        population_bar.fillAmount =  ((float) current_virus_population/ virus_population_max);
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
        return Mathf.Clamp01(current_score / seconds_to_max_difficulty);
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
            AdManager.HideBanner();
        }
    }

    public void PauseGame()
    {
        if (!game_over)
        {
            paused_screen.SetActive(true);
            AdManager.ShowBanner();
            Time.timeScale = 0;
            is_paused = true;
        }
    }

    int GetLeaderBoardScore()
    {
        #if UNITY_ANDROID
            return Mathf.RoundToInt(current_score * 1000);
        #elif UNITY_IOS
            return Mathf.RoundToInt(current_score * 100);
        #endif
    }
    public void EndGame()
    {
        game_over = true;
        timer_text.color = Color.red;
        AudioManager.instance.Play("GameOver");

        if (current_score > PlayerPrefs.GetFloat("HighScore") )
        {
            SetHighScore();
        }

        int lb_score = GetLeaderBoardScore();
        LeaderBoard.instance.SubmitScoreToLeaderboard(lb_score);
        sanitizer.enable_shooter = false;
        VirusController.instance.viruses_can_expire = false;
        VirusController.instance.viruses_can_spawn = false;
        VirusController.instance.viruses_can_upgrade = false;

        int new_playtime= PlayerPrefs.GetInt("GamesPlayed") + 1;
        PlayerPrefs.SetInt("GamesPlayed", new_playtime);

        AdManager.ShowBanner();
        game_over_screen.SetActive(true);
        game_over_screen.GetComponent<GameOverMenu>().GenerateMessage();
    }

    void SetHighScore()
    {
        high_score_acheived=true;
        PlayerPrefs.SetFloat("HighScore", current_score);
        high_score= PlayerPrefs.GetFloat("HighScore");

        int minutes = Mathf.FloorToInt(high_score / 60f);
        int seconds = Mathf.FloorToInt(high_score % 60f);
        int milliseconds = Mathf.FloorToInt((high_score * 100f) % 100f);
        high_score_text.text = minutes + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
    }
}
