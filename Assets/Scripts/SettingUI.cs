using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private Scrollbar scrollbar;
    
    public AudioSource clickSound;

    public AudioSource bgmAudioSource;

    // Update is called once per frame
    void Update()
    {
        clickSound.volume = scrollbar.value;
        
        bgmAudioSource.volume = scrollbar.value;
    }
}
