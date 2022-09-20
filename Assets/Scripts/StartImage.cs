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
        SettingUI.Instance.SettingBgmSound(startAudio);
        
        StartCoroutine(BlinkTxt());
        
        Invoke(nameof(HideAlphaImage), 1f);
        
        //Load();
    }

    // void OnSceneLoaded(Scene scene, LoadSceneMode level)
    // {       
    //     Debug.Log(1);
    //     SettingUI.Instance.SettingBgmSound(startAudio);
    //
    //     Test();
    //     // alphaImage.SetActive(false);
    // }
    //
    // public void Test()
    // {
    //     Debug.Log(2);
    //     StartCoroutine(BlinkTxt());
    //     
    //     Invoke(nameof(HideAlphaImage), 1f);
    // }
    //
    // private void OnEnable()
    // {
    //     SceneManager.sceneLoaded += OnSceneLoaded;
    // }
    //
    // private void OnDisable()
    // {
    //     SceneManager.sceneLoaded -= OnSceneLoaded;
    // }


    private void HideAlphaImage()
    {
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
        dataResetUI.SetActive(true);

        SettingUI.Instance.SettingSfxSound(clickAudio);
    }

    public void ResetData()
    {
        UserDataManager.Instance.user.isOpening = false;
        UserDataManager.Instance.user.userName = "";
        PlayerPrefs.DeleteAll();
        
        // SceneManager.LoadSceneAsync(0);

        Application.Quit();
    }

    public void HideDataUI()
    {
        dataResetUI.SetActive(false);

        SettingUI.Instance.SettingSfxSound(clickAudio);
    }
}
