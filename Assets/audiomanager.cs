using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class audiomanager : MonoBehaviour
{


    [SerializeField] AudioSource bgmusicSource;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioMixer mixer;
    public AudioLowPassFilter filter;
  
    public AudioClip mainMenu;
    public AudioClip carRevInitial;
    public AudioClip carRevLoop;
    public AudioClip carCrash;
    public AudioClip buttonBeep;

    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            PlayMenuBgm();
            filter.enabled = false;
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1)) 
        {
            PlayInitialPart();
        }
    }
    public void PlayInitialPart()
    {
        bgmusicSource.clip = carRevInitial;
        bgmusicSource.Play();
        Invoke("PlayLoopWithoutError", carRevInitial.length);
    }

    public void PlayLoopWithoutError()
    {
        if (bgmusicSource.clip == carRevInitial)
        {
            PlayLoopPart();
        }
    }
    public void PlayLoopPart()
    {
   
        bgmusicSource.clip = carRevLoop;
        bgmusicSource.loop = true;
        bgmusicSource.Play();
    }

    public void PlayMenuBgm()
    {
        bgmusicSource.clip = mainMenu;
        bgmusicSource.loop = true;
        bgmusicSource.Play();
    }

    public void playSFX(AudioClip audioClip)
    {
        sfxSource.PlayOneShot(audioClip);
    }

    public void pauseBgm()
    {
        bgmusicSource.Pause();
    }

    public void toggleFilter()
    {
        filter.enabled = !filter.enabled;
    }

    public void SetBgmVolume(float volume)
    {
        bgmusicSource.volume = volume;
        PlayerPrefs.SetFloat("BgmVolume", volume);
    }

    public void SetSfxVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("SfxVolume", volume);
    }

    public float GetBgmVolume()
    {
        return bgmusicSource.volume;
    }

    public float GetSfxVolume()
    {
        return sfxSource.volume;
    }

    private void LoadVolumeSettings()
    {
        if (PlayerPrefs.HasKey("BgmVolume"))
        {
            bgmusicSource.volume = PlayerPrefs.GetFloat("BgmVolume");
        }
        if (PlayerPrefs.HasKey("SfxVolume"))
        {
            sfxSource.volume = PlayerPrefs.GetFloat("SfxVolume");
        }
    }


}
