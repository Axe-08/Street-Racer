using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class volumeSettings : MonoBehaviour
{
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;

    public AudioSource sfxSource;
    public AudioSource bgmSource;

    public TMP_Text bgmValueText;
    public TMP_Text sfxValueText;

   

      
        private void Start()
    {
        if (!PlayerPrefs.HasKey("sfxVolume"))
        {
            PlayerPrefs.SetFloat("sfxVolume", 1f);
        }
        if (!PlayerPrefs.HasKey("bgmVolume"))
        {
            PlayerPrefs.SetFloat("bgmVolume", 1f);
        }
        Loadbgm();
        LoadSfx();
        bgmValueText.text = (bgmSlider.value * 100).ToString("F0")+"%";
        sfxValueText.text = (sfxSlider.value * 100).ToString("F0")+"%";
    }
    public void changeSFXVolume()
    {
        sfxSource.volume = sfxSlider.value;
        SaveSfx();
        sfxValueText.text = (sfxSlider.value * 100).ToString("F0") + "%";
    }
    public void SaveSfx()
    {
        PlayerPrefs.SetFloat("sfxVolume",sfxSlider.value);
    }
    public void LoadSfx()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    public void changebgmVolume()
    {
        bgmSource.volume = bgmSlider.value;
        Savebgm();
        bgmValueText.text = (bgmSlider.value * 100).ToString("F0") + "%";
       
    }
    public void Savebgm()
    {
        PlayerPrefs.SetFloat("bgmVolume", bgmSlider.value);
    }
    public void Loadbgm()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("bgmVolume");
    }
}
