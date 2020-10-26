using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;

	[SerializeField]
	AudioMixer MainaudioMixer;

	public float music_preset;
	public float sfx_preset;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;
			s.source.outputAudioMixerGroup = s.mixerGroup;
		}
	}

    void Start()
    {
		InitGameVolume();
		InitMusicMuted();
		InitSfxMuted();
		Play("BackgroundMusic");
    }

    public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + sound + " not found!");
			return;
		}
		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}

	void InitGameVolume()
	{
		if (!PlayerPrefs.HasKey("MainVolume"))
		{
			PlayerPrefs.SetFloat("MainVolume", 0);
		}
		float player_volume = PlayerPrefs.GetFloat("MainVolume");
		MainaudioMixer.SetFloat("MainVolume", player_volume);
	}

	void InitMusicMuted()
    {
		if (!PlayerPrefs.HasKey("MusicMuted"))
		{
			PlayerPrefs.SetFloat("MusicMuted", 0);
		}
		int music_muted = PlayerPrefs.GetInt("MusicMuted");
		MainaudioMixer.SetFloat("MusicVolume", (music_muted ==1)? -80 : music_preset);
	}

	void InitSfxMuted()
	{
		if (!PlayerPrefs.HasKey("SfxMuted"))
		{
			PlayerPrefs.SetFloat("SfxMuted", 0);
		}
		int sfx_muted = PlayerPrefs.GetInt("SfxMuted");
		MainaudioMixer.SetFloat("SfxVolume", (sfx_muted == 1) ? -80 : sfx_preset);
	}

}
