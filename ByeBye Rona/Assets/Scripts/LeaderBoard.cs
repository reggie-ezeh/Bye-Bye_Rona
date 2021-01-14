using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class LeaderBoard : MonoBehaviour
{

    public static LeaderBoard instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    public void SubmitScoreToLeaderboard(long score)
    {
        Leaderboards.HighScoreBoard.SubmitScore(score);
    }
}
