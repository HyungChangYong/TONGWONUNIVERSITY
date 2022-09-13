using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    public static SettingUI Instance;
    
    [SerializeField] private Scrollbar scrollbar;
    
    [SerializeField] private AudioSource sfxSound;

    [SerializeField] private AudioSource bgmAudioSource;

    private void Awake()
    {
        Instance = this;
    }

    public void SettingSfxSound(AudioClip audioClip)
    {
        sfxSound.clip = audioClip;
        
        sfxSound.Play();
    }
    
    public void SettingBgmSound(AudioClip audioClip)
    {
        bgmAudioSource.clip = audioClip;
        
        bgmAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        sfxSound.volume = scrollbar.value;
        
        bgmAudioSource.volume = scrollbar.value;
        
        DialogueManager.Instance.typeSound.volume = scrollbar.value;
        
        DialogueManager.Instance.enterSound.volume = scrollbar.value;
    }
}
