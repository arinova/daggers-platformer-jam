using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioClip gameMusic;

    [SerializeField] AudioClip sceneSwitchSwoosh;
    [SerializeField] AudioClip pilotLaser;

    [Space(10)]
    [SerializeField] AudioSource musicChannel;
    [SerializeField] List<AudioSource> sfxChannels;

    int currentSFXChannel = 0;
    int highestSFXChannel = 0;

    public static AudioManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;

        if (musicChannel == null) Debug.LogError("AudioManager: Music Channel is null");
        foreach (AudioSource sfxChannel in sfxChannels)
        {
            if (sfxChannel == null) Debug.LogError("Audio Manager: One of the SFX Channels is null");
        }

        highestSFXChannel = sfxChannels.Count - 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Music
    void PlayMusic(AudioClip music)
    {
        if (music == null)
        {
            Debug.LogWarning("Attempted to play a null music clip.  Not playing music");
            return;
        }
        // This conditional will only allow swapping of the music if the music is changing
        //  - This lets multiple areas with the same music feel contiguous
        if (musicChannel.clip != music)
        {
            musicChannel.Stop();
            musicChannel.clip = music;
            musicChannel.Play();
        }
    }
    public void PlayMenuMusic()
    {
        PlayMusic(menuMusic);
    }
    public void PlayGameMusic()
    {
            PlayMusic(gameMusic);

    }

    public void StopMusic()
    {
        if(musicChannel.isPlaying) musicChannel.Stop();
    }
    #endregion

    #region Sound Effects
    void PlaySoundEffect(AudioClip soundEffect)
    {
        if (soundEffect == null)
        {
            Debug.LogWarning("Attempted to play a null sfx clip.  Not playing sfx");
            return;
        }

        NextSFXChannel();
        if (!sfxChannels[currentSFXChannel].isPlaying)
        {
            sfxChannels[currentSFXChannel].Stop();
            sfxChannels[currentSFXChannel].clip = soundEffect;
            sfxChannels[currentSFXChannel].Play();
        }
    }

    public void PlaySceneSwitchSwooshSFX()
    {
        PlaySoundEffect(sceneSwitchSwoosh);
    }
    public void PlayPilotLaserSFX()
    {
        PlaySoundEffect(pilotLaser);
    }

    // This cycles the indices of the sfx channel list and makes "currentSFXChannel" appropriate throughout the class
    // - This is called by PlayMusic() and PlaySoundEffect() before stopping the sound/music, replacing the clip, and playing the new clip
    void NextSFXChannel()
    {
        currentSFXChannel++;
        if (currentSFXChannel > highestSFXChannel)
            currentSFXChannel = 0;

    }
    #endregion
}
