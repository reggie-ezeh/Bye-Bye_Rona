using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameAudioSettings : MonoBehaviour
{
    [SerializeField]
    AudioMixer MainaudioMixer;

    [SerializeField]
    Slider volume_slider;

    bool music_is_muted;
    bool sfx_is_muted;

    [SerializeField]
    Button music_button;
    [SerializeField]
    Button sfx_button;
    [SerializeField]
    Sprite sound_sprite;
    [SerializeField]
    Sprite nosound_sprite;

    [SerializeField]
    TextMeshProUGUI music_info;
    [SerializeField]
    TextMeshProUGUI sfx_info;


    void Start()
    {
        volume_slider.value = PlayerPrefs.GetFloat("MainVolume");
        music_is_muted = PlayerPrefs.GetInt("MusicMuted") == 1;
        sfx_is_muted = PlayerPrefs.GetInt("SfxMuted") == 1;
        UpdateMusic();
        UpdateSfx();
    }

    public void AdjustVolume (float volume)
    {
        MainaudioMixer.SetFloat("MainVolume", volume);
        PlayerPrefs.SetFloat("MainVolume", volume);
    }

    public void ToggleMusicMute()
    {
        music_is_muted = !music_is_muted;
        MainaudioMixer.SetFloat("MusicVolume", music_is_muted ? -80 : AudioManager.instance.music_preset);
        PlayerPrefs.SetInt("MusicMuted", music_is_muted ? 1 : 0);
        UpdateMusic();
    }

    public void ToggleSfxMute()
    {
        sfx_is_muted = !sfx_is_muted;
        MainaudioMixer.SetFloat("SfxVolume", sfx_is_muted ? -80 : AudioManager.instance.sfx_preset);
        PlayerPrefs.SetInt("SfxMuted", sfx_is_muted ? 1 : 0);
        UpdateSfx();
    }

    void UpdateMusic()
    {
        if (music_is_muted)
        {
            music_button.image.sprite = sound_sprite;
            music_info.text = "Tap to unmute";
        }
        else
        {
            music_button.image.sprite = nosound_sprite;
            music_info.text = "Tap to mute";
        }
    }
    void UpdateSfx()
    {
        if (sfx_is_muted)
        {
            sfx_button.image.sprite = sound_sprite;
            sfx_info.text = "Tap to unmute";
        }
        else
        {
            sfx_button.image.sprite = nosound_sprite;
            sfx_info.text = "Tap to mute";
        }
    }

}
