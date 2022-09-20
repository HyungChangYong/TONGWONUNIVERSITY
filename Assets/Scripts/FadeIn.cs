using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] private GameObject startImageGo;
    [SerializeField] private GameObject openingImageGo;
    [SerializeField] private GameObject tutorialImageGo;
    
    [SerializeField] private Image fadeImage;
    
    [SerializeField] private AudioClip sceneChangeAudio;
    [SerializeField] private AudioClip openingAudio;
    [SerializeField] private AudioClip tutorialAudio;
    
    [SerializeField] private TextMeshProUGUI openingConversation;
    [SerializeField] private TextMeshProUGUI openingCharterName;
    [SerializeField] private Image openingCharterImage;
    [SerializeField] private Image openingDialogueWindow;
    [SerializeField] private Animator openingCharterAnimator;
    [SerializeField] private Animator openingTxtBtnAnimator;
    [SerializeField] private GameObject openingTxtBtnImageGo;
    [SerializeField] private Image openingTxtBtnImage;
    
    private readonly WaitForSeconds _yieldViewDelay = new WaitForSeconds(0.1f);

    private float _time;
    private float _currentFadeTime = 1f;
    
    public void Fade()
    {
        SettingUI.Instance.SettingSfxSound(sceneChangeAudio);

        if (PlayerPrefs.HasKey("Opening"))
        {
            StartCoroutine(FadeTutorial());
        }
        else
        {
            StartCoroutine(FadeFlow());
        }
        // if (UserDataManager.Instance.user.isOpening.Equals(false))
        // {
        //     StartCoroutine(FadeFlow());
        // }
        // else
        // {
        //     StartCoroutine(FadeTutorial());
        // }
    }
    
    private IEnumerator FadeFlow()
    {
        fadeImage.gameObject.SetActive(true);
        
        _time = 0f;
        
        Color alpha = fadeImage.color;
        
        while (alpha.a < 1f)
        {
            _time += Time.deltaTime / _currentFadeTime;
            
            alpha.a = Mathf.Lerp(0, 1, _time);
            
            fadeImage.color = alpha;
            
            yield return null;
        }
        _time = 0f;
        
        yield return _yieldViewDelay;
        
        while (alpha.a > 0f)
        {
            _time += Time.deltaTime / _currentFadeTime;
            
            alpha.a = Mathf.Lerp(1, 0, _time);
            
            fadeImage.color = alpha;
            
            startImageGo.SetActive(false);
            openingImageGo.SetActive(true);

            yield return null;
        }
        
        SettingUI.Instance.SettingBgmSound(openingAudio);
        
        fadeImage.gameObject.SetActive(false);
        
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.openingDialogue, "Opening", openingConversation, openingCharterName, openingCharterImage, openingDialogueWindow, openingCharterAnimator, openingTxtBtnAnimator, openingTxtBtnImageGo, openingTxtBtnImage);
        
        yield return null;
    }
    
    private IEnumerator FadeTutorial()
    {
        fadeImage.gameObject.SetActive(true);
        
        _time = 0f;
        
        Color alpha = fadeImage.color;
        
        while (alpha.a < 1f)
        {
            _time += Time.deltaTime / _currentFadeTime;
            
            alpha.a = Mathf.Lerp(0, 1, _time);
            
            fadeImage.color = alpha;
            
            yield return null;
        }
        _time = 0f;
        
        yield return _yieldViewDelay;
        
        while (alpha.a > 0f)
        {
            _time += Time.deltaTime / _currentFadeTime;
            
            alpha.a = Mathf.Lerp(1, 0, _time);
            
            fadeImage.color = alpha;
            
            startImageGo.SetActive(false);

            DialogueManager.Instance.ChangeSettingImage();
            
            tutorialImageGo.SetActive(true);

            yield return null;
        }
        
        SettingUI.Instance.SettingBgmSound(tutorialAudio);
        
        fadeImage.gameObject.SetActive(false);

        DialogueManager.Instance.ShowTutorial(3);
        
        yield return null;
    }
}
