using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour{


    public static SoundManager instance = null;

    public AudioClip sanitizer_shoot;
    public AudioClip virus_hit;
    public AudioClip power_up;
    public AudioClip game_over;


    private AudioSource soundEffectAudio;

    // We basically intialize the audio
    void Start()
    {
        if (instance== null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }

        AudioSource theSource = GetComponent<AudioSource>();
        soundEffectAudio = theSource;

    }


    // Now a method that other objects in the game can call on to make sounds-- therfore public
        
        public void play_Requested_Audio(AudioClip input_sound)
        {   
            soundEffectAudio.PlayOneShot(input_sound);
        }




}
