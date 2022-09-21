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
    
    [SerializeField] private GameObject openingUIGo;
    [SerializeField] private GameObject tutorialUIGo;
    [SerializeField] private GameObject tutorialTxtBoxLine;
    [SerializeField] private GameObject inputFiledGo;
    [SerializeField] private GameObject nameSelectImageGo;
    [SerializeField] private GameObject nextBtnImageGo;
    [SerializeField] private GameObject nameSelectUIGo;

    [SerializeField] private Image fadeImage;
    [SerializeField] private Image settingImage;
    
    [SerializeField] private Sprite lobbySettingImage;

    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private TextMeshProUGUI nameSelectUITxt;
    
    
    [SerializeField] private AudioClip openingSceneChangeAudio;
    [SerializeField] private AudioClip tutorialBgm;
    [SerializeField] private AudioClip sceneChangeAudio;
    [SerializeField] private AudioClip clickAudio;
    
    public AudioSource typeSound;

    private List<string> _listSentences;
    private List<Sprite> _listCharters;
    private List<Sprite> _listDialogueWindows;
    
    private readonly WaitForSeconds _yieldViewDelay = new WaitForSeconds(0.1f);
    private readonly WaitForSeconds _yieldAnimDelay = new WaitForSeconds(1f);
    private readonly WaitForSeconds _yieldCharterChangeDelay = new WaitForSeconds(0.5f);
    private readonly WaitForSeconds _yieldNoCharterChangeDelay = new WaitForSeconds(0.05f);
    
    private readonly Vector2 _settingImageChangeSizeDelta = new Vector2(128, 110);
    

    private readonly Vector3 _txtBtnBasePos = new Vector3(430, -277, 0);
    private readonly Vector3 _fadeImageMovePos = new Vector3(-1570, 0, 0);
    private readonly Vector3 _settingImageMovePos = new Vector3(447, 797, 0);
    private readonly Vector3 _settingImageChangeScale = new Vector3(1.45f, 1.45f, 1.45f);
    
    
    private bool _isTalk;
    private bool _clickActivated;
    private readonly bool _isTrue = true;
    
    private int _count;

    private float textDelay = 0.02f;
    private float _time;
    private float _currentFadeTime = 1f;
    
    [SerializeField] private TextMeshProUGUI conversation;
    [SerializeField] private TextMeshProUGUI charterName;
    [SerializeField] private Image charterImage;
    [SerializeField] private Image dialogueWindow;
    [SerializeField] private Animator charterAnimator;
    [SerializeField] private Animator txtBtnAnimator;
    [SerializeField] private GameObject txtBtnImageGo;
    [SerializeField] private Image txtBtnImage;

    [SerializeField] private TextMeshProUGUI tutorialConversation;
    [SerializeField] private TextMeshProUGUI tutorialCharterName;
    [SerializeField] private Image tutorialCharterImage;
    [SerializeField] private Image tutorialWindow;
    [SerializeField] private Animator tutorialCharterAnimator;
    [SerializeField] private Animator tutorialTxtBtnAnimator;
    [SerializeField] private GameObject tutorialTxtBtnImageGo;
    [SerializeField] private Image tutorialTxtBtnImage;

    [SerializeField] private RuntimeAnimatorController drawController;
    [SerializeField] private RuntimeAnimatorController charterController;
    [SerializeField] private Animator charterImageAnimator;

    [SerializeField] private TextMeshProUGUI testtxt;
    
    public float m_DoubleClickSecond = 0.25f;
    private bool m_IsOneClick = false;
    private double m_Timer = 0;

    private bool _isOpeningSkip;

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

    private void Update()
    {
        // OnDoubleClick();

        if (_isTalk.Equals(true) && _clickActivated.Equals(false))
        {
            if (m_IsOneClick && ((Time.time - m_Timer) > m_DoubleClickSecond))
            {
                m_IsOneClick = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (!m_IsOneClick)
                {
                    m_Timer = Time.time;
                    m_IsOneClick = true;
                }
                else if (m_IsOneClick && ((Time.time - m_Timer) < m_DoubleClickSecond))
                {
                    m_IsOneClick = false;
                    //아래에 더블클릭에서 처리하고싶은 이벤트 작성
                    textDelay = 0.001f;
                }
            }
        }
        
    }
    //
    // private void OnDoubleClick()
    // {
    //     if (Input.touchCount >= 2)
    //     {
    //         testtxt.text = "ㅎㅇ";
    //     }
    // }

    public void ShowDialogue(Dialogue dialogue, string situationCase, TextMeshProUGUI conversationTxt, TextMeshProUGUI charterNameTxt, Image charterImageIn, Image dialogueWindowImage, Animator charterAnimatorIn, Animator txtBtnAnimatorIn, GameObject txtBtnImageGoIn, Image txtBtnImageIn)
    {
        _isTalk = true;
        
        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            _listSentences.Add(dialogue.sentences[i]);
            _listCharters.Add(dialogue.charterImages[i]);
            _listDialogueWindows.Add(dialogue.dialogueWindows[i]);

            if (PlayerPrefs.HasKey("PlayerName").Equals(true))
            {
                string playerName = PlayerPrefs.GetString("PlayerName");
                
                _listSentences[i] = _listSentences[i].Replace("[플레이어]", playerName);
            }
        }

        conversation = conversationTxt;

        charterName = charterNameTxt;

        charterImage = charterImageIn;

        dialogueWindow = dialogueWindowImage;

        charterAnimator = charterAnimatorIn;

        txtBtnAnimator = txtBtnAnimatorIn;

        txtBtnImageGo = txtBtnImageGoIn;

        txtBtnImage = txtBtnImageIn;

        if (_isOpeningSkip.Equals(true))
        {
            charterImage.sprite = _listCharters[_count];
        }

        StartCoroutine(StartDialogueCoroutine(situationCase));
    }
    
    private void ExitDialogue(string situationCase)
    {
        _count = 0;
        conversation.text = "";
        _listSentences.Clear();
        _listCharters.Clear();
        _listDialogueWindows.Clear();
        _isTalk = false;
        
        // 대화 종료
        switch (situationCase)
        {
            case "Opening":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightFlow());
                break;
            case "Tutorial":
                conversation.text = "튜토리얼이 끝났습니다";
                break;
        }
    }

    private IEnumerator StartDialogueCoroutine(string situationCase)
    {
        if (_count > 0)
        {
            if (_listDialogueWindows[_count] != _listDialogueWindows[_count - 1])
            {
                // 알파 값 실행 움직이는 애니메이션 실행
                // 대화창 다를 경우 실행  
            }
            else
            {
                if (_isOpeningSkip.Equals(false))
                {
                    // 캐릭터 이미지가 다를 경우
                    if (_listCharters[_count] != _listCharters[_count - 1])
                    {
                        switch (situationCase)
                        {
                            case "Opening":
                                SettingUI.Instance.SettingSfxSound(openingSceneChangeAudio);
                                break;
                        }
                    
                        charterAnimator.SetBool("isAlpha", true);
                        yield return _yieldCharterChangeDelay;
                        charterImage.sprite = _listCharters[_count];
                        charterAnimator.SetBool("isAlpha", false);
                    
                        // 이미지 이름이 Name_background가 들어가면 아래 코드 실행
                        if (_listCharters[_count].name.Contains("Name_background").Equals(true))
                        {
                            charterImageAnimator.runtimeAnimatorController = drawController;
                            nextBtnImageGo.SetActive(false);
                            tutorialTxtBoxLine.SetActive(false);
                            inputFiledGo.SetActive(true);
                            nameSelectImageGo.SetActive(true);
                        }
                        
                        // 이름에 Valet가 들어가면 아래 코드 실행
                        if (_listCharters[_count].name.Contains("Valet").Equals(true))
                        {
                            charterImageAnimator.runtimeAnimatorController = charterController;
                            charterName.text = "집사";
                        }
                    }
                    else
                    {
                        yield return _yieldNoCharterChangeDelay;
                    }
                }
                else
                {
                    _isOpeningSkip = false;
                    
                    yield return _yieldNoCharterChangeDelay;
                }
                
                
            }
        }
        else
        {
            charterImage.sprite = _listCharters[_count];
        }

        for (int i = 0; i < _listSentences[_count].Length; i++)
        {
            conversation.text += _listSentences[_count][i];

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
        if (_isTalk.Equals(true) && _clickActivated.Equals(true))
        {
            textDelay = 0.02f;
            _clickActivated = false;
            txtBtnImageGo.SetActive(false);
            _count++;
            conversation.text = "";
            StopCoroutine(BlinkTxtBtnImage());
            txtBtnAnimator.SetBool("IsDown", false);
            txtBtnImage.rectTransform.localPosition = _txtBtnBasePos;

            if (_count.Equals(_listSentences.Count))
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
        while (_isTrue.Equals(true))
        {
            txtBtnAnimator.SetBool("IsDown", true);
            
            yield return _yieldViewDelay;
            
            txtBtnAnimator.SetBool("IsDown", false);
            
            yield return _yieldAnimDelay;
        }
    }
    
    private IEnumerator FadeRightFlow()
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
        
        while (fadeImage.rectTransform.localPosition.x > -1550f)
        {
            _time += Time.deltaTime * 0.1f;

            fadeImage.rectTransform.localPosition = 
                Vector3.Lerp(fadeImage.rectTransform.localPosition, _fadeImageMovePos, _time);

            openingUIGo.SetActive(false);

            ChangeSettingImage();

            tutorialUIGo.SetActive(true);

            yield return null;
        }
        
        SettingUI.Instance.SettingBgmSound(tutorialBgm);
        
        fadeImage.gameObject.SetActive(false);

        ShowTutorial(0);
        
        yield return null;
    }

    public void ChangeSettingImage()
    {
        settingImage.rectTransform.localPosition = _settingImageMovePos;
        settingImage.rectTransform.sizeDelta = _settingImageChangeSizeDelta;
        settingImage.rectTransform.localScale = _settingImageChangeScale;
            
        settingImage.sprite = lobbySettingImage;
    }

    public void ShowTutorial(int num)
    {
        _count = num;

        if (num != 0)
        {
            _isOpeningSkip = true;
        }
        
        
        // 텍스트 출력
        ShowDialogue(DialogueTxt.Instance.tutorialDialogue, "Tutorial", tutorialConversation, tutorialCharterName, tutorialCharterImage, tutorialWindow, tutorialCharterAnimator, tutorialTxtBtnAnimator, tutorialTxtBtnImageGo, tutorialTxtBtnImage);

    }

    public void ShowNameSelectUI()
    {
        if (nameTxt.text.Length != 1)
        {
            nameSelectUIGo.SetActive(true);

            nameSelectUITxt.text = nameTxt.text; //  + "(으)로 결정 하시겠습니까?";
            
            SettingUI.Instance.SettingSfxSound(clickAudio);
        }
    }

    public void OkName()
    {
        UserDataManager.Instance.user.isOpening = true;
        UserDataManager.Instance.user.userName = nameTxt.text;
        PlayerPrefs.SetInt("Opening", 1);
        PlayerPrefs.SetString("PlayerName", nameTxt.text);
        PlayerPrefs.Save();
        
        SettingUI.Instance.SettingSfxSound(clickAudio);
        
        NextBtn("Tutorial");
        nextBtnImageGo.SetActive(true);
        tutorialTxtBoxLine.SetActive(true);
        inputFiledGo.SetActive(false);
        nameSelectImageGo.SetActive(false);
        HideNameSelectUI();
        
        
        
        _count = 3;
        // 텍스트 출력
        ShowDialogue(DialogueTxt.Instance.tutorialDialogue, "Tutorial", tutorialConversation, tutorialCharterName, tutorialCharterImage, tutorialWindow, tutorialCharterAnimator, tutorialTxtBtnAnimator, tutorialTxtBtnImageGo, tutorialTxtBtnImage);

    }
    
    public void HideNameSelectUI()
    {
        nameSelectUIGo.SetActive(false);
        
        SettingUI.Instance.SettingSfxSound(clickAudio);
    }
}
