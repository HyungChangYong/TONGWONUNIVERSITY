using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private float textDelay;

    public TextMeshProUGUI conversation;
    public Image openingCharterImage;
    // public Image dialogueWindow;

    private List<string> _listSentences;
    private List<Sprite> _listCharters;
    private List<Sprite> _listDialogueWindows;

    private int _count; // 대화 진행 상황 카운트

    public Animator drawAnimator;

    public bool isTalk = false;
    private bool _clickActivated = false;

    public AudioSource typeSound;

    [SerializeField] private GameObject txtBtnImageGo;
    
    [SerializeField] private Image txtBtnImage;
    
    [SerializeField] private bool isTrue;
    
    [SerializeField] private AudioClip openingSceneChangeAudio;
    [SerializeField] private AudioClip tutorialBgm;
    [SerializeField] private AudioClip sceneChangeAudio;
    
    // 가비지 콜렉터를 생성하지 않기 위한 변수
    private readonly WaitForSeconds _yieldViewDelay = new WaitForSeconds(0.1f);
    private readonly WaitForSeconds _yieldAnimDelay = new WaitForSeconds(1f);

    [SerializeField] private Animator txtBtnAnimator;
    
    // Fade 이미지를 담을 변수
    [SerializeField] private Image fadeImage;

    // 실제 시간을 담을 변수
    private float _time;
    // 몇초 동안 페이드인 또는 페이드 아웃을 시킬지 정하는 변수 (1초로 설정)
    private float _currentFadeTime = 1f;

    [SerializeField] private GameObject openingUIGo;
    [SerializeField] private GameObject tutorialUIGo;

    [SerializeField] private Image settingImage;
    [SerializeField] private Sprite lobbySettingImage;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _count = 0;
        conversation.text = "";
        _listSentences = new List<string>();
        _listCharters = new List<Sprite>();
        _listDialogueWindows = new List<Sprite>();
    }

    public void ShowDialogue(Dialogue dialogue, string situationCase)
    {
        isTalk = true;
        
        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            _listSentences.Add(dialogue.sentences[i]);
            _listCharters.Add(dialogue.charterImages[i]);
            _listDialogueWindows.Add(dialogue.dialogueWindows[i]);
        }

        StartCoroutine(StartDialogueCoroutine(situationCase));
    }
    
    public void ExitDialogue(string situationCase)
    {
        _count = 0;
        conversation.text = "";
        _listSentences.Clear();
        _listCharters.Clear();
        _listDialogueWindows.Clear();
        isTalk = false;
        
        // 추후 이부분 삭제
        switch (situationCase)
        {
            case "Opening":
                StartCoroutine(FadeRightFlow());
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                break;
        }
    }

    private IEnumerator StartDialogueCoroutine(string situationCase)
    {
        if (_count > 0)
        {
            if (_listDialogueWindows[_count] != _listDialogueWindows[_count - 1])
            {
                // 대화창 다를 경우 실행  
            }
            else
            {
                if (_listCharters[_count] != _listCharters[_count - 1])
                {
                    switch (situationCase)
                    {
                        case "Opening":
                            drawAnimator.SetBool("isAlpha", true);
                            SettingUI.Instance.SettingSfxSound(openingSceneChangeAudio);
                            yield return new WaitForSeconds(0.5f);
                            openingCharterImage.sprite = _listCharters[_count];
                            drawAnimator.SetBool("isAlpha", false);
                            break;
                    }
                }
                else
                {
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
        else
        {
            switch (situationCase)
            {
                case "Opening":
                    openingCharterImage.sprite = _listCharters[_count];
                    break;
            }
        }

        for (int i = 0; i < _listSentences[_count].Length; i++)
        {
            conversation.text += _listSentences[_count][i]; // 1글자씩 출력
            if (i % 7 == 1)
            {
                typeSound.Play();
            }
            
            yield return new WaitForSeconds(textDelay);
        }

        _clickActivated = true;
        txtBtnImageGo.SetActive(true);
        StartCoroutine(BlinkTxtBtnImage());
    }

    public void NextBtn(string situationCase)
    {
        if (isTalk.Equals(true) && _clickActivated.Equals(true))
        {
            _clickActivated = false;
            txtBtnImageGo.SetActive(false);
            _count++;
            conversation.text = "";
            StopCoroutine(BlinkTxtBtnImage());
            txtBtnAnimator.SetBool("IsDown", false);
            txtBtnImage.rectTransform.localPosition = new Vector3(430, -277, 0);

            if (_count == _listSentences.Count)
            {
                StopAllCoroutines();
                ExitDialogue(situationCase);
            }
            else
            {
                StopAllCoroutines();
                StartCoroutine(StartDialogueCoroutine(situationCase));
            }
        }
    }
    
    private IEnumerator BlinkTxtBtnImage()
    {
        while (isTrue.Equals(true))
        {
            // 변수에 몬스터 이미지 컬러 값을 넣음
            Color alpha = txtBtnImage.color;
            
            // 알파 값을 담을 지역 변수
            float npcAlpha = 0f;
            // 알파 이미지를 조절할 시간을 담을 지역 변수
            float npcAlphaTime = 1f;

            txtBtnAnimator.SetBool("IsDown", true);

            // 딜레이 타임 0.1f
            yield return _yieldViewDelay;
            
            txtBtnAnimator.SetBool("IsDown", false);
            
            yield return _yieldAnimDelay;
        }
    }
    
    private IEnumerator FadeRightFlow()
    {
        // fadeImage를 활성화 시킴
        fadeImage.gameObject.SetActive(true);
        
        // 변수에 0이라는 값을 넣어줌 (변수 초기화)
        _time = 0f;
        
        // 임시 변수에 fadeImage의 컬러 값을 넣어줌
        Color alpha = fadeImage.color;
        
        // 임시 변수 값이 1보다 작을 동안 아래 코드 실행 (fadeImage의 알파 값이 255보다 작다면)
        while (alpha.a < 1f)
        {
            // 실제시간 / 설정한 시간을 계산해 변수에 더해줌
            _time += Time.deltaTime / _currentFadeTime;
            
            // 임시 변수에 위에 계산한 값을 넣어줌
            alpha.a = Mathf.Lerp(0, 1, _time);
            
            // 설정한 색을 fadeImage에 넣어줌
            fadeImage.color = alpha;
            
            // 다음 1프레임까지 대기
            yield return null;
        }
        // 변수에 0이라는 값을 넣어줌
        _time = 0f;
    
        // 0.1초 까지 대기 
        yield return new WaitForSeconds(0.1f);
    
        // 임시 변수 값이 0보다 큰 동안 아래 코드 실행 (fadeImage의 알파 값이 255보다 크다면)
        while (alpha.a > 0f)
        {
            // 실제시간 / 설정한 시간을 계산해 변수에 더해줌
            _time += Time.deltaTime * 0.1f;

            fadeImage.rectTransform.localPosition =
                Vector3.Lerp(fadeImage.rectTransform.localPosition, new Vector3(-1670, 0, 0), _time);
            // 임시 변수에 위에 계산한 값을 넣어줌
            // alpha.a = Mathf.Lerp(1, 0, _time);

            // fadeImage.fillAmount = alpha.a;
            
            // 설정한 색을 fadeImage에 넣어줌
            // fadeImage.color = alpha;
            
            openingUIGo.SetActive(false);

            settingImage.rectTransform.localPosition = new Vector3(447, 797, 0);
            settingImage.rectTransform.sizeDelta = new Vector2(128, 110);
            settingImage.rectTransform.localScale = new Vector3(1.45f, 1.45f, 1.45f);
            
            settingImage.sprite = lobbySettingImage;
            
            tutorialUIGo.SetActive(true);
            
            SettingUI.Instance.SettingBgmSound(tutorialBgm);

            // 다음 1프레임까지 대기
            yield return null;
        }
        // fadeImage를 비활성화 시킴
        fadeImage.gameObject.SetActive(false);
        
        // 텍스트 출력
        // DialogueManager.Instance.ShowDialogue(dialogue, "Opening");
    
        // 다음 1프레임까지 대기
        yield return null;
    }
}
