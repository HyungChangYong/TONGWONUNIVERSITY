using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class StartImage : MonoBehaviour
{
    [SerializeField] private FadeIn fadeIn;

    [SerializeField] private GameObject settingUIGo;
    [SerializeField] private GameObject gameExitUI;
    [SerializeField] private GameObject alphaImage;
    [SerializeField] private GameObject dataResetUI;

    [SerializeField] private Image touchToStartBackImage;
    
    [SerializeField] private TextMeshProUGUI touchToStartTxt;
    
    [SerializeField] private AudioClip startAudio;
    [SerializeField] private AudioClip clickAudio;
    
    private readonly bool _isTrue = true;
    
    private readonly WaitForSeconds _yieldViewDelay = new WaitForSeconds(1f);

    void Start()
    {
        Application.targetFrameRate = 60;
        
        Time.timeScale = 1;
        
        SettingUI.Instance.SettingBgmSound(startAudio);
      
        StartCoroutine(BlinkTxt());
        
        Invoke(nameof(HideAlphaImage), 1f);
        
        //Load();
    }

    private void HideAlphaImage()
    {
        // Debug.Log("인보크 실행");
        alphaImage.SetActive(false);
    }

    private IEnumerator BlinkTxt()
    {
        while (_isTrue.Equals(true))
        {
            Color alpha = touchToStartBackImage.color;
            
            float npcAlpha;
            float npcAlphaTime = 1f;
            
            npcAlpha = 0f;
            
            yield return _yieldViewDelay;
            
            while (alpha.a > 0.5f)
            {
                npcAlpha += Time.deltaTime / npcAlphaTime;
                
                alpha.a = Mathf.Lerp(1, 0, npcAlpha);
                
                touchToStartTxt.color = new Color(72f / 255f, 44f / 255f, 89f / 255f, alpha.a);
                touchToStartBackImage.color = alpha;

                yield return null;
            }
            
            while (alpha.a < 1f)
            {
                npcAlpha += Time.deltaTime / npcAlphaTime;
                
                alpha.a = Mathf.Lerp(0, 1, npcAlpha);
                
                touchToStartTxt.color = new Color(72f / 255f, 44f / 255f, 89f / 255f, alpha.a);
                touchToStartBackImage.color = alpha;
                
                yield return null;
            }
        }
    }

    public void ShowSettingUI(RectTransform image)
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);
        
        Time.timeScale = 0;
        
        settingUIGo.SetActive(true);
    }
    
    public void HideSettingUI(RectTransform image)
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);

        Time.timeScale = 1;
        
        settingUIGo.SetActive(false);
    }
    
    public void StartToLobby()
    {
        fadeIn.Fade();
    }
    
    public void ShowGameExitUI(bool isClick)
    {
        if (isClick.Equals(true))
        {
            SettingUI.Instance.SettingSfxSound(clickAudio);
        }
        
        gameExitUI.SetActive(true);
    }

    public void GameExit()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);
        
        Application.Quit();
    }
    
    public void HideGameExitUI()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);
        
        gameExitUI.SetActive(false);
    }
    
    public void ShowDataUI()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);
        
        dataResetUI.SetActive(true);
    }

    public void HideDataUI()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);
        
        dataResetUI.SetActive(false);        
    }

    public void ResetData()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);
        
        fadeIn.FadeData();
    }
}
