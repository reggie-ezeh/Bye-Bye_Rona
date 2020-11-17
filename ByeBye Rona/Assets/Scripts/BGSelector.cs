using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BGSelector : MonoBehaviour
{
    [SerializeField]
    GameObject scrollbar;
    private float scroll_pos = 0;
    float[] pos;
    int games_played;

    int player_current_bg;

    [SerializeField]
    TextMeshProUGUI play_more_text;
    [SerializeField]
    TextMeshProUGUI selected_bg_notification;
    [SerializeField]
    Button Ad_button;
    [SerializeField]
    Button SelectBg_button;
    [SerializeField]
    TextMeshProUGUI Ad_failed_message;

    int current_BG_index;
    //used to tell when a the user has moved
    int old_pointer;

    // Start is called before the first frame update
    void Start()
    {
        games_played = PlayerPrefs.GetInt("GamesPlayed");
        player_current_bg = PlayerPrefs.GetInt("SelectedBackground");
        PlayerPrefs.SetInt("BG0_Status", 1);
        old_pointer = -1;
        Ad_failed_message.gameObject.SetActive(false);
    }

    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.touchCount > 0)
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                current_BG_index = i;
                if (old_pointer != current_BG_index)
                {
                        ResetChoices();
                        CheckBgStatus();

                    old_pointer = current_BG_index;
                }

                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.1f);
                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }

    }

    private void ResetChoices()
    {
        play_more_text.gameObject.SetActive(false);
        selected_bg_notification.gameObject.SetActive(false);
        Ad_button.gameObject.SetActive(false);
        SelectBg_button.gameObject.SetActive(false);
    }

    //this method is used to check if a background has been unlocked
    void CheckBgStatus()
    {
        //eg: BG3_Status=0 or BG3_Status=1
        // 0=not available , 1=available
        string bg_status_key = "BG"+current_BG_index.ToString()+"_Status";

        if( PlayerPrefs.GetInt(bg_status_key) == 0)
        {
            CanWatchAd(current_BG_index);
        }
        else
        {
            if (player_current_bg == current_BG_index)
            {
                selected_bg_notification.gameObject.SetActive(true);
            }
            else
            {
                SelectBg_button.gameObject.SetActive(true);
            }
        }
    }

    void CanWatchAd(int i)
    {
        if ( games_played > (i * 5))
        {
            Ad_button.gameObject.SetActive(true);
        }
        else
        {
            play_more_text.gameObject.SetActive(true);
            play_more_text.text = "Complete " + ((i * 5) - games_played +1) + " more game(s) to unlock";
        }
    }

    public void WatchAd()
    {
        AdManager.ShowRewardedAd(MakeBgAvailable, AdSkipped, AdFailed);
    }

    //after the player has watched the ad
    void MakeBgAvailable()
    {
        string bg_status_key = "BG"+current_BG_index.ToString()+"_Status";
        PlayerPrefs.SetInt(bg_status_key, 1);
        CheckBgStatus();
    }


    //when player clicks to select a background
    public void SelectBg()
    {
        PlayerPrefs.SetInt("SelectedBackground", current_BG_index);
        player_current_bg = PlayerPrefs.GetInt("SelectedBackground");

        ResetChoices();
        CheckBgStatus();
    }

    void AdSkipped()
    {
        StartCoroutine(SkipMessage());
    }

    void AdFailed()
    {
        StartCoroutine(FailMessage());
    }

    IEnumerator SkipMessage()
    {
        Ad_failed_message.gameObject.SetActive(true);
        Ad_failed_message.text = "Ad skipped; Failed to Unlock Background";
        yield return new WaitForSeconds(3);
        Ad_failed_message.gameObject.SetActive(false);
    }
    IEnumerator FailMessage()
    {
        Ad_failed_message.gameObject.SetActive(true);
        Ad_failed_message.text = "Ad failed to load";
        yield return new WaitForSeconds(3);
        Ad_failed_message.gameObject.SetActive(false);
    }
}