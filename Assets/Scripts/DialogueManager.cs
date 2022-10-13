using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = System.Random;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    
    [SerializeField] private GameObject openingUIGo;
    [SerializeField] private GameObject tutorialUIGo;
    [SerializeField] private GameObject lobbyUIGo;
    [SerializeField] private GameObject tutorialTxtBoxLine;
    [SerializeField] private GameObject inputFiledGo;
    [SerializeField] private GameObject nameSelectImageGo;
    [SerializeField] private GameObject nextBtnImageGo;
    [SerializeField] private GameObject nameSelectUIGo;
    [SerializeField] private GameObject iconDescriptionGo;

    [SerializeField] private Transform settingUIParent;
    [SerializeField] private Transform tutorialSettingUIParent;
    [SerializeField] private Transform settingUIParentTr;

    [SerializeField] private Image fadeImage;
    [SerializeField] private Image dataImage;
    [SerializeField] private Image infoImage;
    [SerializeField] private Image settingImage;
    
    [SerializeField] private Sprite lobbySettingImage;

    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private TextMeshProUGUI nameSelectUITxt;
    [SerializeField] private TextMeshProUGUI choiceTxt;
     
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
    private readonly WaitForSeconds _yieldCharterChangeDelay = new WaitForSeconds(1f);
    private readonly WaitForSeconds _yieldNoCharterChangeDelay = new WaitForSeconds(0.05f);
    
    private readonly Vector2 _settingImageChangeSizeDelta = new Vector2(128, 110);

    private readonly Vector3 _txtBtnBasePos = new Vector3(430, -277, 0);
    private readonly Vector3 _fadeImageMovePos = new Vector3(-1570, 0, 0);
    private readonly Vector3 _settingImageMovePos = new Vector3(447, 797, 0);
    private readonly Vector3 _settingImageChangeScale = new Vector3(1.45f, 1.45f, 1.45f);
    
    
    private bool _isTalk;
    private bool _clickActivated;
    private readonly bool _isTrue = true;
    
    public int count;

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
    [SerializeField] private RuntimeAnimatorController drawController1;
    [SerializeField] private RuntimeAnimatorController charterController;
    [SerializeField] private RuntimeAnimatorController charterController1;
    
    // [SerializeField] private Animator charterImageAnimator;

    [SerializeField] private TMP_FontAsset blackOutline;
    [SerializeField] private TMP_FontAsset whiteOutline;

    [SerializeField] private Sprite whiteNextBtn;
    [SerializeField] private Sprite blackNextBtn;

    [SerializeField] private Image tutorialAlphaImage;
    [SerializeField] private Image arrowSign;

    [SerializeField] private Sprite[] tutorialIconAlphaImages;

    [SerializeField] private Vector3[] arrowSignTr;

    [SerializeField] private int[] addNowHeart;
    [SerializeField] private int[] addCoin;

    public float m_DoubleClickSecond = 0.25f;
    private bool m_IsOneClick = false;
    private double m_Timer = 0;

    private bool _isOpeningSkip;

    private int _randomCultivation;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        count = 0;
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
            charterImage.sprite = _listCharters[count];
        }

        StartCoroutine(StartDialogueCoroutine(situationCase));
    }
    
    private void ExitDialogue(string situationCase)
    {
        count = 0;
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
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                PlayerPrefs.SetInt("Tutorial", 1);
                PlayerPrefs.Save();
                StartFadeData();
                break;
            case "ValetCall":
                choiceTxt.text = "[ " + DialogueTxt.Instance.valetCallDialogue.sentences[1] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowThreeChoice(0);
                // 선택지 세팅
                break;
            case "Cultivation":
                //conversation.text = "대화 종료";
                StartCoroutine(FadeInfo(0));
                // StartFadeData();
                // 선택지 세팅
                break;
        }
    }

    private void ChangeWindowImage()
    {
        dialogueWindow.sprite = _listDialogueWindows[count];
        charterImage.sprite = _listCharters[count];
        charterAnimator.SetBool("IsAlpha", false);
    }

    public void StartFadeData()
    {
        StartCoroutine(FadeDate(tutorialUIGo));
    }

    private IEnumerator StartDialogueCoroutine(string situationCase)
    {
        if (count > 0)
        {
            if (_listDialogueWindows[count] != _listDialogueWindows[count - 1])
            {
                charterAnimator.runtimeAnimatorController = charterController;

                // 이미지 이름이 Name_background가 들어가면 아래 코드 실행
                if (_listCharters[count - 1].name.Contains("Name_background").Equals(true))
                {
                    charterAnimator.runtimeAnimatorController = drawController;
                }

                if (_isOpeningSkip.Equals(false))
                {
                    switch (situationCase)
                    {
                        case "Tutorial":
                            if (count == 29)
                            {
                                yield return _yieldCharterChangeDelay;
                                dialogueWindow.sprite = _listDialogueWindows[count];
                                charterImage.sprite = _listCharters[count];
                            }
                            else
                            {
                                charterAnimator.SetBool("IsAlpha", true); 
                                yield return _yieldCharterChangeDelay;
                                ChangeWindowImage();
                            }
                            break;
                        case "ValetCall":
                        {
                            charterAnimator.SetBool("IsAlpha", true); 
                            yield return _yieldCharterChangeDelay;
                            ChangeWindowImage();
                        }
                            break;
                        case "Cultivation":
                            {
                                charterAnimator.SetBool("IsAlpha", true); 
                                yield return _yieldCharterChangeDelay;
                                ChangeWindowImage();
                            }
                            break;
                    }
                    
                    switch (situationCase)
                    {
                        case "Tutorial":
                            switch (count)
                            {
                                case 3:
                                    charterAnimator.runtimeAnimatorController = charterController1;
                                    break;
                                case 12:
                                    charterAnimator.runtimeAnimatorController = charterController1;
                                    break;
                                case 18:
                                    charterAnimator.runtimeAnimatorController = charterController1;
                                    break;
                                case 23:
                                    charterAnimator.runtimeAnimatorController = charterController1;
                                    break;
                                case 27:
                                    charterAnimator.runtimeAnimatorController = charterController1;
                                    break;
                            }
                            break;
                    }
                }
                    
                // 이미지 이름이 Name_background가 들어가면 아래 코드 실행
                if (_listCharters[count].name.Contains("Name_background").Equals(true))
                {
                    charterAnimator.runtimeAnimatorController = drawController1;
                    dialogueWindow.sprite = _listDialogueWindows[count];
                    charterImage.sprite = _listCharters[count];
                    nextBtnImageGo.SetActive(false);
                    tutorialTxtBoxLine.SetActive(false);
                    inputFiledGo.SetActive(true);
                    nameSelectImageGo.SetActive(true);
                }

                // 이름에 Valet가 들어가면 아래 코드 실행
                if (_listCharters[count].name.Contains("Valet").Equals(true))
                {
                    // charterAnimator.runtimeAnimatorController = charterController;
                    charterName.text = "집사";
                }
                else if (_listCharters[count].name.Contains("Girl").Equals(true))
                {
                    charterName.text = PlayerPrefs.GetString("PlayerName");
                }
                else
                {
                    charterName.text = "";
                }

                switch (situationCase)
                    {
                        case "Tutorial":
                            if (count == 29)
                            {
                                charterName.text = "";
                            }
                            break;
                        case "Cultivation":
                            if (count == 2)
                            {
                                _randomCultivation = UnityEngine.Random.Range(0, 6);

                                switch (_randomCultivation)
                                {
                                    case 0:
                                        _listSentences[3] = "오늘은 사교계 인물들을 외우며 하루를 보냈다.";
                                        break;
                                    case 1:
                                        _listSentences[3] = "오늘은 집사와 함께 황실 예법을 공부하며 시간을 보냈다.";
                                        break;
                                    case 2:
                                        _listSentences[3] = "이후 해가 질 때까지 도서관에서 다양한 책을 읽으며 시간을 보냈다.";
                                        break;
                                    case 3:
                                        _listSentences[3] = "이후 발이 저릴 때까지 춤을 연습하고 나니 하루가 지나있었다.";
                                        break;
                                    case 4:
                                        _listSentences[3] = "이후 살롱 마담에게 카탈로그를 부탁해 최신 유행하는 드레스를 구경하며 안목을 길렀다.";
                                        break;
                                    case 5:
                                        _listSentences[3] = "사교계 행사에 대비하여 예의 있게 욕하는 방법을 배우며 하루를 보냈다.";
                                        break;
                                }
                                
                                // charterName.text = "";
                            }
                            break;
                    }

                if (_listDialogueWindows[count].name.Contains("Think_Box").Equals(true))
                {
                    conversation.font = blackOutline;
                    txtBtnImage.sprite = blackNextBtn;
                }
                else
                {
                    conversation.font = whiteOutline;
                    txtBtnImage.sprite = whiteNextBtn;
                }
            }
            else
            {
                if (_isOpeningSkip.Equals(false))
                {
                    // 캐릭터 이미지가 다를 경우
                    if (_listCharters[count] != _listCharters[count - 1])
                    {
                        charterAnimator.runtimeAnimatorController = drawController;
                        
                        switch (situationCase)
                        {
                            case "Opening":
                                SettingUI.Instance.SettingSfxSound(openingSceneChangeAudio);
                                
                                charterAnimator.SetBool("IsAlpha", true);
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                charterAnimator.SetBool("IsAlpha", false);
                                break;
                            case "Tutorial":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                switch (count)
                                {
                                    // 날짜 활성
                                    case 32:
                                        iconDescriptionGo.SetActive(true);
                                        settingUIParent.SetParent(tutorialSettingUIParent);
                                        StartArrowSignAnim(0);
                                        break;
                                    case 33:
                                        tutorialAlphaImage.sprite = tutorialIconAlphaImages[0];
                                        StartArrowSignAnim(2);
                                        break;
                                    case 34:
                                        StartArrowSignAnim(2);
                                        break;
                                    case 35:
                                        tutorialAlphaImage.sprite = tutorialIconAlphaImages[1];
                                        StartArrowSignAnim(4);
                                        break;
                                    case 36:
                                        tutorialAlphaImage.sprite = tutorialIconAlphaImages[2];
                                        StartArrowSignAnim(6);
                                        break;
                                    case 37:
                                        StartArrowSignAnim(6);
                                        break;
                                    case 38:
                                        tutorialAlphaImage.sprite = tutorialIconAlphaImages[3];
                                        StartArrowSignAnim(8);
                                        break;
                                    case 39:
                                        StartArrowSignAnim(8);
                                        break;
                                    case 40:
                                        tutorialAlphaImage.gameObject.SetActive(false);
                                        settingUIParent.SetParent(settingUIParentTr);
                                        break;
                                }
                                break;
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
        // 대화 시작 부분
        else
        {
            charterImage.sprite = _listCharters[count];
        }

        for (int i = 0; i < _listSentences[count].Length; i++)
        {
            conversation.text += _listSentences[count][i];

            if (i % 7 == 1)
            {
                typeSound.Play();
            }
            
            yield return new WaitForSeconds(textDelay);
        }

        
        Invoke("DelayNext", 0.2f);
        txtBtnImageGo.SetActive(true);
        StartCoroutine(BlinkTxtBtnImage());
    }
    
    private void StartArrowSignAnim(int num)
    {
        arrowSign.gameObject.SetActive(true);
        arrowSign.transform.localPosition = arrowSignTr[num];
        arrowSign.transform.localEulerAngles = arrowSignTr[num + 1];
        StartCoroutine(BlinkArrow());
        // 코루틴 호출
    }
    
    private IEnumerator BlinkArrow()
    {
        while (_isTrue.Equals(true))
        {
            Color alpha = arrowSign.color;
            
            float npcAlpha;
            float npcAlphaTime = 1f;
            
            npcAlpha = 0f;
            
            yield return _yieldViewDelay;
            
            while (alpha.a > 0.5f)
            {
                npcAlpha += Time.deltaTime / npcAlphaTime;
                
                alpha.a = Mathf.Lerp(1, 0, npcAlpha);
                
                arrowSign.color = alpha;

                yield return null;
            }
            
            while (alpha.a < 1f)
            {
                npcAlpha += Time.deltaTime / npcAlphaTime;
                
                alpha.a = Mathf.Lerp(0, 1, npcAlpha);
                
                arrowSign.color = alpha;
                
                yield return null;
            }
        }
    }
        
    private void DelayNext()
    {
        _clickActivated = true;
    }

    public void NextBtn(string situationCase)
    {
        if (charterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            if (_isTalk.Equals(true) && _clickActivated.Equals(true))
            {
                textDelay = 0.02f;
                _clickActivated = false;
                txtBtnImageGo.SetActive(false);
                count++;
                conversation.text = "";
                StopCoroutine(BlinkTxtBtnImage());
                txtBtnAnimator.SetBool("IsDown", false);
                txtBtnImage.rectTransform.localPosition = _txtBtnBasePos;

                switch (situationCase)
                {
                    case "Tutorial":
                        if (count != 34 && count != 37 && count != 39)
                        {
                            StopCoroutine(BlinkArrow());
                            arrowSign.gameObject.SetActive(false);
                        }
                        arrowSign.color = new Color(1, 1, 1, 1);
                        break;
                }

                if (count.Equals(_listSentences.Count))
                {
                    //StopCoroutine(StartDialogueCoroutine(situationCase));
                    StopAllCoroutines();
                    ExitDialogue(situationCase);
                }
                else
                {
                    // StopCoroutine(StartDialogueCoroutine(situationCase));
                    StopAllCoroutines();
                    StartCoroutine(StartDialogueCoroutine(situationCase));
                }
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
    
    private IEnumerator FadeInfo(int num)
    {
        // 이미지 파일 변경 코드 추가
        
        SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
        
        infoImage.gameObject.SetActive(true);
        
        _time = 0f;
        
        Color alpha = infoImage.color;
        
        while (alpha.a < 1f)
        {
            _time += Time.deltaTime / _currentFadeTime;
            
            alpha.a = Mathf.Lerp(0, 1, _time);
            
            infoImage.color = alpha;
            
            yield return null;
        }
        _time = 0f;
        
        yield return _yieldAnimDelay;

        StartFadeData();
        AddDate();
        
        switch (num)
        {
            case 0:
                LobbyManager.Instance.nowHeart[0] += addNowHeart[_randomCultivation];
                LobbyManager.Instance.coin += addCoin[_randomCultivation];
                LobbyManager.Instance.SettingCoin();
                break;
        }
        
        
        LobbyManager.Instance.ResetLobby();
        
        // while (alpha.a > 0)
        // {
        //     _time += Time.deltaTime / _currentFadeTime;
        //     
        //     alpha.a = Mathf.Lerp(1, 0, _time);
        //     
        //     infoImage.color = alpha;
        //
        //     lobbyUIGo.SetActive(true);
        //     
        //     yield return null;
        // }
        
        yield return null;
    }
    
    
    private IEnumerator FadeDate(GameObject go)
    {
        dataImage.gameObject.SetActive(true);
        
        _time = 0f;
        
        Color alpha = dataImage.color;
        
        while (alpha.a < 1f)
        {
            _time += Time.deltaTime / _currentFadeTime;
            
            alpha.a = Mathf.Lerp(0, 1, _time);
            
            dataImage.color = alpha;
            
            yield return null;
        }
        _time = 0f;
        
        yield return _yieldAnimDelay;
        
        while (alpha.a > 0)
        {
            _time += Time.deltaTime / _currentFadeTime;
            
            alpha.a = Mathf.Lerp(1, 0, _time);
            
            dataImage.color = alpha;
            
            go.SetActive(false);
            
            lobbyUIGo.SetActive(true);
            infoImage.gameObject.SetActive(false);
            infoImage.color = new Color(1, 1, 1, 0);

            yield return null;
        }
        
        dataImage.gameObject.SetActive(false);
        
        yield return null;
    }

    private void AddDate()
    {
        LobbyManager.Instance.date += 1;
        LobbyManager.Instance.SettingDate();
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
        count = num;

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
        PlayerPrefs.SetInt("Opening", 1);
        PlayerPrefs.SetString("PlayerName", nameTxt.text);
        PlayerPrefs.SetInt("Date", 1);
        PlayerPrefs.Save();
        
        LobbyManager.Instance.date = PlayerPrefs.GetInt("Date");
        LobbyManager.Instance.SettingDate();
        
        SettingUI.Instance.SettingSfxSound(clickAudio);
        
        NextBtn("Tutorial");
        nextBtnImageGo.SetActive(true);
        tutorialTxtBoxLine.SetActive(true);
        inputFiledGo.SetActive(false);
        nameSelectImageGo.SetActive(false);
        HideNameSelectUI();
        
        
        _listSentences.Clear();
        _listCharters.Clear();
        _listDialogueWindows.Clear();
        count = 3;
        // 텍스트 출력
        ShowDialogue(DialogueTxt.Instance.tutorialDialogue, "Tutorial", tutorialConversation, tutorialCharterName, tutorialCharterImage, tutorialWindow, tutorialCharterAnimator, tutorialTxtBtnAnimator, tutorialTxtBtnImageGo, tutorialTxtBtnImage);

    }
    
    public void HideNameSelectUI()
    {
        nameSelectUIGo.SetActive(false);
        
        SettingUI.Instance.SettingSfxSound(clickAudio);
    }

    public void SettingChoiceNum(int num)
    {
        
    }
}
