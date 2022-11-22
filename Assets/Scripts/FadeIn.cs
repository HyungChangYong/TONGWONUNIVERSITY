using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    [SerializeField] private GameObject startImageGo;
    [SerializeField] private GameObject openingImageGo;
    [SerializeField] private GameObject tutorialImageGo;
    
    [SerializeField] private Image fadeImage;
    [SerializeField] private Image dataImage;
    
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

        if (PlayerPrefs.HasKey("Tutorial"))
        {
            if (PlayerPrefs.HasKey("IanFirst"))
            {
                DailyRoutine.Instance.isFirst[0] = true;
            }
            
            if (PlayerPrefs.HasKey("NoaFirst"))
            {
                DailyRoutine.Instance.isFirst[1] = true;
            }
            
            if (PlayerPrefs.HasKey("AustinFirst"))
            {
                DailyRoutine.Instance.isFirst[2] = true;
            }
            
            if (PlayerPrefs.HasKey("IanShowHeart"))
            {
                LobbyManager.Instance.isShowHeart[1] = true;
            }

            if (PlayerPrefs.HasKey("NoaShowHeart"))
            {
                LobbyManager.Instance.isShowHeart[2] = true;
            }
            
            if (PlayerPrefs.HasKey("AustinShowHeart"))
            {
                LobbyManager.Instance.isShowHeart[3] = true;
            }
            
            for (int i = 0; i < LobbyManager.Instance.isAlbum.Length; i++)
            {
                if (PlayerPrefs.HasKey(i.ToString()))
                {
                    LobbyManager.Instance.ClearAlbum(i);
                }
            }

            LobbyManager.Instance.nowHeart[0] = PlayerPrefs.GetFloat("PlayerHeart");
            // 주석 처리
            LobbyManager.Instance.nowHeart[1] = PlayerPrefs.GetFloat("IanHeart");
            // 주석 처리
            LobbyManager.Instance.nowHeart[2] = PlayerPrefs.GetFloat("NoaHeart");
            // 주석 처리
            LobbyManager.Instance.nowHeart[3] = PlayerPrefs.GetFloat("AustinHeart");

            // 주석 처리
            DialogueManager.Instance.endingWhoNum = PlayerPrefs.GetInt("Ending");
            ChoiceManager.Instance.event4WhoNum = PlayerPrefs.GetInt("Event4");
            ChoiceManager.Instance.event3WhoNum = PlayerPrefs.GetInt("Event3");
            LobbyManager.Instance.date = PlayerPrefs.GetInt("Date");
            LobbyManager.Instance.coin = PlayerPrefs.GetInt("Coin");
            LobbyManager.Instance.SettingCoin();
            LobbyManager.Instance.SettingDate();
            // 날짜 값 불러오기
            StartCoroutine(FadeLobby());
        }
        else if (PlayerPrefs.HasKey("Opening"))
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
    
    private IEnumerator FadeLobby()
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
            dataImage.color = new Color(1, 1, 1, 1);
            dataImage.gameObject.SetActive(true);

            DialogueManager.Instance.ChangeSettingImage();

            yield return null;
        }
        
        SettingUI.Instance.SettingBgmSound(tutorialAudio);
        DialogueManager.Instance.StartFadeData();
        fadeImage.gameObject.SetActive(false);
        

        yield return null;
    }

    public void FadeData()
    {
        StartCoroutine(FadeDataCoroutine());
    }
    
    private IEnumerator FadeDataCoroutine()
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.transform.localPosition = new Vector3(540, 0, 0);
        _time = 0f;

        Time.timeScale = 1;
        
        Color alpha = fadeImage.color;
        
        while (alpha.a < 1f)
        {
            _time += Time.deltaTime / _currentFadeTime;
            
            alpha.a = Mathf.Lerp(0, 1, _time);
            
            fadeImage.color = alpha;
            
            yield return null;
        }
        // _time = 0f;
        
        yield return _yieldViewDelay;
        
        PlayerPrefs.DeleteAll();
        
        SceneManager.LoadScene(0);
        
        yield return null;
    }
}
