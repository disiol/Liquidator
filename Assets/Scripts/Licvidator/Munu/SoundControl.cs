using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    // public GameObject menuPanel;
    public AudioMixerGroup audioMixerGroup;
    public Slider slider;
    public Toggle toggle;
    public string nameVolume;

    private bool toggleEnabled;
    private float sliderValue;

    private static string SLIDER_VAULUE_SAFE_KEY;
    private static string TONGLE_MUT_SAFE_KEY;

    //TODO настройка звуков потдельностsaveKeyи сохронеие изагрузка значения громкости

    private void Start()
    {
        TONGLE_MUT_SAFE_KEY = nameVolume + "tongleMut";
        SLIDER_VAULUE_SAFE_KEY = nameVolume + "ChangeVoulume";

        toggle.isOn = PlayerPrefs.GetInt(TONGLE_MUT_SAFE_KEY, 0) == 1;
        slider.value = PlayerPrefs.GetFloat(SLIDER_VAULUE_SAFE_KEY, 0); 
        
        Debug.Log("SoundControl Start enabled = " + TONGLE_MUT_SAFE_KEY + " " + toggleEnabled);
        Debug.Log("SoundControl Start enabled = " + SLIDER_VAULUE_SAFE_KEY + " " + sliderValue);
        

        
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void TongleMut()
    {
        toggleEnabled = toggle.isOn;
        Debug.Log("SoundControl TongleMusic enabled = " + toggleEnabled);

        if (toggleEnabled)
        {
            audioMixerGroup.audioMixer.SetFloat(nameVolume, -80);
            
            //TODO  сохронеие изагрузка значения громкости
        }
        else if (!toggleEnabled)
        {
            audioMixerGroup.audioMixer.SetFloat(nameVolume, 0);
        }

        PlayerPrefs.SetInt(TONGLE_MUT_SAFE_KEY, toggleEnabled ? 0 : 1);
        PlayerPrefs.Save();
    }

    public void ChangeVoulume()
    {
        sliderValue = slider.value;
        Debug.Log("SoundControl ChangeVoulume sliderValue = " + sliderValue);
        float lerp = Mathf.Lerp(-80, 0, sliderValue);
        Debug.Log("SoundControl ChangeVoulume lerp = " + lerp);

        audioMixerGroup.audioMixer.SetFloat(nameVolume, sliderValue);
        //TODO настройка звуков потдельности сохронеие изагрузка значения громкости
        PlayerPrefs.SetFloat(SLIDER_VAULUE_SAFE_KEY, sliderValue);
        PlayerPrefs.Save();
    }
}