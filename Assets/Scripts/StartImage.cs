using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class StartImage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI touchToStartTxt;

    [SerializeField] private Image touchToStartBackImage;

    [SerializeField] private bool isTrue;

    // 가비지 콜렉터를 생성하지 않기 위한 변수
    private readonly WaitForSeconds _yieldViewDelay = new WaitForSeconds(1f);

    [SerializeField] private GameObject settingUIGo;

    [SerializeField] private AudioClip startAudio;
    
    [SerializeField] private AudioClip clickAudio;
    
    [SerializeField] private GameObject gameExitUI;

    [SerializeField] private FadeIn fadeIn;

    [SerializeField] private GameObject alphaImage;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BlinkTxt());

        SettingUI.Instance.SettingBgmSound(startAudio);
        
        Invoke("HideAlphaImage", 1f);
    }

    private void HideAlphaImage()
    {
        alphaImage.SetActive(false);
    }

    private IEnumerator BlinkTxt()
    {
        while (isTrue.Equals(true))
        {
            // 변수에 몬스터 이미지 컬러 값을 넣음
            Color alpha = touchToStartBackImage.color;
            
            // 알파 값을 담을 지역 변수
            float npcAlpha = 0f;
            // 알파 이미지를 조절할 시간을 담을 지역 변수
            float npcAlphaTime = 1f;

            // 변수 초기화
            npcAlpha = 0f;

            // 딜레이 타임 0.1f
            yield return _yieldViewDelay;

            // 알파 값이 0보다 큰 동안에 아래 코드 실행
            while (alpha.a > 0.5f)
            {
                // Debug.Log(1);
                // 실제 시간 / 설정한 딜레이 시간을 계산한 값을 변수에 넣음
                npcAlpha += Time.deltaTime / npcAlphaTime;

                // 알파 값 조절
                alpha.a = Mathf.Lerp(1, 0, npcAlpha);

                // 조절한 알파 값을 이미지의 컬러 값에 넣음
                touchToStartTxt.color = new Color(72f / 255f, 44f / 255f, 89f / 255f, alpha.a);
                touchToStartBackImage.color = alpha;

                yield return null;
            }
            
            // 알파 값이 255보다 작을 동안에 아래 코드 실행
            while (alpha.a < 1f)
            {
                // 실제 시간 / 설정한 딜레이 시간을 계산한 값을 변수에 넣음
                npcAlpha += Time.deltaTime / npcAlphaTime;

                // 알파 값 조절
                alpha.a = Mathf.Lerp(0, 1, npcAlpha);

                // 조절한 알파 값을 이미지의 컬러 값에 넣음
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
        gameExitUI.SetActive(true);

        if (isClick.Equals(true))
        {
            SettingUI.Instance.SettingSfxSound(clickAudio);
        }
       
        
        
        // 애플리케이션 종료
        // 
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
        Debug.Log("데이터 초기화");

        SettingUI.Instance.SettingSfxSound(clickAudio);
    }
}
