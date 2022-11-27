using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = System.Random;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    [TextArea(1, 3)]
    [SerializeField] private String endingTxt;
    [SerializeField] private TextMeshProUGUI endingTxts;
    [SerializeField] private GameObject endingTxtGo;

    [SerializeField] private GameObject openingUIGo;
    [SerializeField] private GameObject tutorialUIGo;
    [SerializeField] private GameObject lobbyUIGo;
    [SerializeField] private GameObject tutorialTxtBoxLine;
    [SerializeField] private GameObject inputFiledGo;
    [SerializeField] private GameObject nameSelectImageGo;
    [SerializeField] private GameObject nextBtnImageGo;
    [SerializeField] private GameObject nameSelectUIGo;
    [SerializeField] private GameObject iconDescriptionGo;
    [SerializeField] private GameObject choiceEndingUIGo;
 
    [SerializeField] private Transform settingUIParent;
    [SerializeField] private Transform tutorialSettingUIParent;
    [SerializeField] private Transform settingUIParentTr;

    [SerializeField] private Image endingCharacterBackImage;
    [SerializeField] private Image getMaximImageCancelImage;
    [SerializeField] private Image getMaximImage;
    [SerializeField] private Image whiteFadeImage;
    [SerializeField] private Image fadeImage;
    [SerializeField] private Image dataImage;
    [SerializeField] private Image infoImage;
    [SerializeField] private Image reputationImage;
    [SerializeField] private Image settingImage;
    [SerializeField] private Image[] fadeBlurImage;
    [SerializeField] private Image[] endingCharacterImage;

    [SerializeField] private Sprite lobbySettingImage;
    // 0 교양 증가, 1 이안 호감도 증가, 2 노아 호감도 증가, 3 아스틴 호감도 증가, 4 변화 없음
    [SerializeField] private Sprite[] infoSprite;

    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private TextMeshProUGUI nameSelectUITxt;
    [SerializeField] private TextMeshProUGUI choiceTxt;
     
    [SerializeField] private AudioClip openingSceneChangeAudio;
    [SerializeField] private AudioClip tutorialBgm;
    [SerializeField] private AudioClip sceneChangeAudio;
    [SerializeField] private AudioClip clickAudio;
    [SerializeField] private AudioClip surpriseAudio;
    [SerializeField] private AudioClip dropAudio;
    [SerializeField] private AudioClip breakAudio;
    [SerializeField] private AudioClip rainAudio;
    [SerializeField] private AudioClip rattleAudio;
    [SerializeField] private AudioClip dangerousAudio;
    [SerializeField] private AudioClip doorAudio;
    [SerializeField] private AudioClip wristAudio;
    [SerializeField] private AudioClip shopBellAudio;
    [SerializeField] private AudioClip musicBox2Audio;
    [SerializeField] private AudioClip horseAudio;
    [SerializeField] private AudioClip catAudio;
    [SerializeField] private AudioClip littleBirdAudio;
    [SerializeField] private AudioClip wave2Audio;
    [SerializeField] private AudioClip footSteps;
    [SerializeField] private AudioClip peopleAudio;
    [SerializeField] private AudioClip coinAudio;
    [SerializeField] private AudioClip square3Audio;
    [SerializeField] private AudioClip curtainAudio;
    [SerializeField] private AudioClip readyAudio;
    [SerializeField] private AudioClip debut1Audio;
    [SerializeField] private AudioClip cheekAudio;
    [SerializeField] private AudioClip party1Audio;
    [SerializeField] private AudioClip fireAudio;
    [SerializeField] private AudioClip illustrationAudio;
    [SerializeField] private AudioClip endingGlass;
    [SerializeField] private AudioClip park1Audio;
    [SerializeField] private AudioClip footSteps2;
    [SerializeField] private AudioClip footSteps3;
    [SerializeField] private AudioClip sweatTeaAudio;
    [SerializeField] private AudioClip magicAudio;
    [SerializeField] private AudioClip ianAudio;
    [SerializeField] private AudioClip heartBeat3Audio;
    [SerializeField] private AudioClip noaAudio;
    [SerializeField] private AudioClip cureAudio;
    [SerializeField] private AudioClip austinAudio;
    [SerializeField] private AudioClip summerNightBugAudio;
    [SerializeField] private AudioClip ian1Audio;
    [SerializeField] private AudioClip ian2Audio;
    [SerializeField] private AudioClip ian3Audio;
    [SerializeField] private AudioClip noa1Audio;
    [SerializeField] private AudioClip nockAudio;
    [SerializeField] private AudioClip noa2Audio;
    [SerializeField] private AudioClip noa3Audio;
    [SerializeField] private AudioClip austin1Audio;
    [SerializeField] private AudioClip austin2Audio;
    [SerializeField] private AudioClip austin3Audio;
    [SerializeField] private AudioClip valetAudio;
    [SerializeField] private AudioClip arrowUIAudio;
    [SerializeField] private AudioClip questionAudio;
    [SerializeField] private AudioClip hitAudio;
    [SerializeField] private AudioClip sparkleAudio;
    [SerializeField] private AudioClip sparkle0Audio;
    [SerializeField] private AudioClip sparkle2Audio;
    [SerializeField] private AudioClip sparkle3Audio;
    [SerializeField] private AudioClip sparkle5Audio;
    [SerializeField] private AudioClip find1Audio;
    [SerializeField] private AudioClip find2Audio;
    [SerializeField] private AudioClip find3Audio;
    [SerializeField] private AudioClip stepsAudio;
    [SerializeField] private AudioClip steps2Audio;
    [SerializeField] private AudioClip steps3Audio;
    [SerializeField] private AudioClip steps4Audio;
    [SerializeField] private AudioClip know1Audio;
    [SerializeField] private AudioClip wonder1Audio;
    [SerializeField] private AudioClip wonder2Audio;
    [SerializeField] private AudioClip wonder3Audio;
    [SerializeField] private AudioClip sharpnessAudio;
    [SerializeField] private AudioClip embarrassmentAudio;
    [SerializeField] private AudioClip pongAudio;
    [SerializeField] private AudioClip personAudio;
    [SerializeField] private AudioClip chair1Audio;
    [SerializeField] private AudioClip ppyong1Audio;
    [SerializeField] private AudioClip ppyong2Audio;
    [SerializeField] private AudioClip ppyong4Audio;
    [SerializeField] private AudioClip breath3Audio;
    [SerializeField] private AudioClip sharpeyesAudio;
    [SerializeField] private AudioClip HatefeelingAudio;
    [SerializeField] private AudioClip sigh2Audio;
    [SerializeField] private AudioClip ExclamationAudio;
    [SerializeField] private AudioClip Exclamation2Audio;
    [SerializeField] private AudioClip Exclamation3Audio;
    [SerializeField] private AudioClip snapAudio;
    [SerializeField] private AudioClip Horse_Run2Audio;
    [SerializeField] private AudioClip storm2Audio;
    [SerializeField] private AudioClip rockAudio;
    [SerializeField] private AudioClip fire2Audio;
    [SerializeField] private AudioClip anxiousfeelingAudio;
    [SerializeField] private AudioClip absurdAudio;
    [SerializeField] private AudioClip TringAudio;
    [SerializeField] private AudioClip dressAudio;
    [SerializeField] private AudioClip treeAudio;
    [SerializeField] private AudioClip shockAudio;
    [SerializeField] private AudioClip windAudio;
    [SerializeField] private AudioClip waterAudio;
    [SerializeField] private AudioClip sweatAudio;
    [SerializeField] private AudioClip PatchingAudio;
    [SerializeField] private AudioClip selectAudio;
    
    
    [SerializeField] private bool[] isActiveEndingCharacter;
 
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

    private float textDelay = 0.015f;
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

    private int event4WhoNum;
    public int endingWhoNum;

    private bool _isBuyDialogueEnd;

    public GameObject shopUI;

    [SerializeField] private GameObject placeUIGo;

    private string _event2Case;

    private string _situationCase;

    private bool _isCancelIllustration;
    private bool _isChoiceEndingCharacter;
    private bool _isSelectEndingCharacter;

    private int _endongNum;

    public void ClickEndingCharacter(int num)
    {
        if (_isChoiceEndingCharacter.Equals(false))
        {
            if (isActiveEndingCharacter[num].Equals(false))
            {
                endingCharacterImage[num].color = new Color(0.5f, 0.5f, 0.5f);
        
                switch (num)
                {
                    case 0:
                        endingCharacterImage[num].rectTransform.sizeDelta = new Vector2(1120, 752);
                        break;
                    case 1:
                        endingCharacterImage[num].rectTransform.sizeDelta = new Vector2(1116, 861);
                        break;
                    case 2:
                        endingCharacterImage[num].rectTransform.sizeDelta = new Vector2(1145, 783);
                        break;
                }
            }
            else
            {
                endingCharacterImage[num].color = new Color(42f / 255f, 42f / 255f, 42f / 255f);
            }
        }
    }

    private bool _isClickAudio;
    public void ClickUpEndingCharacter(int num)
    {
        _isClickAudio = false;
        if (_isChoiceEndingCharacter.Equals(false))
        {
            endingWhoNum = 1 + num;

            if (isActiveEndingCharacter[num].Equals(false))
            {
                endingCharacterImage[num].color = new Color(1f, 1f, 1f);

                switch (num)
                {
                    case 0:
                        endingCharacterImage[num].rectTransform.sizeDelta = new Vector2(1080, 727);
                        endingCharacterImage[1].color = new Color(85f / 255f, 85f / 255f, 85f / 255f);
                        endingCharacterImage[2].color = new Color(85f / 255f, 85f / 255f, 85f / 255f);
                        isActiveEndingCharacter[1] = true;
                        isActiveEndingCharacter[2] = true;
                        break;
                    case 1:
                        endingCharacterImage[num].rectTransform.sizeDelta = new Vector2(1080, 833);
                        endingCharacterImage[0].color = new Color(85f / 255f, 85f / 255f, 85f / 255f);
                        endingCharacterImage[2].color = new Color(85f / 255f, 85f / 255f, 85f / 255f);
                        isActiveEndingCharacter[0] = true;
                        isActiveEndingCharacter[2] = true;
                        break;
                    case 2:
                        endingCharacterImage[num].rectTransform.sizeDelta = new Vector2(1080, 739);
                        endingCharacterImage[0].color = new Color(85f / 255f, 85f / 255f, 85f / 255f);
                        endingCharacterImage[1].color = new Color(85f / 255f, 85f / 255f, 85f / 255f);
                        isActiveEndingCharacter[0] = true;
                        isActiveEndingCharacter[1] = true;
                        break;
                }
                
                if (_isSelectEndingCharacter.Equals(false))
                {
                    _isSelectEndingCharacter = true;
                }
                else
                {
                    _isClickAudio = true;
                    switch (event4WhoNum)
                    {
                        case 1:
                            if (ChoiceManager.Instance.isAddIanHeart.Equals(true))
                            {
                                StartCoroutine(FadeInfoEvent(8, 0, 1, 15));
                            }
                            else
                            {
                                StartCoroutine(FadeInfoEvent(8, 0, 9, 10));
                            }
                            break;
                        case 2:
                            if (ChoiceManager.Instance.isAddIanHeart.Equals(true))
                            {
                                StartCoroutine(FadeInfoEvent(8, 0, 2, 15));
                            }
                            else
                            {
                                StartCoroutine(FadeInfoEvent(8, 0, 10, 10));
                            }
                            break;
                        case 3:
                            if (ChoiceManager.Instance.isAddIanHeart.Equals(true))
                            {
                                StartCoroutine(FadeInfoEvent(8, 0, 3, 15));
                            }
                            else
                            {
                                StartCoroutine(FadeInfoEvent(8, 0, 11, 10));
                            }
                            break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < endingCharacterImage.Length; i++)
                {
                    endingCharacterImage[i].color = new Color(1f, 1f, 1f);
                    isActiveEndingCharacter[i] = false;
                    _isSelectEndingCharacter = false;
                }
            }
        }

        if (_isClickAudio.Equals(true))
        {
            SettingUI.Instance.SettingSfx1Sound(selectAudio);
        }
        else
        {
            SettingUI.Instance.SettingSfx1Sound(clickAudio);
        }
    }

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
                    textDelay = 0.0005f;
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

        _situationCase = situationCase;
        
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
                LobbyManager.Instance.SettingDate();
                break;
            case "ValetCall":
                choiceTxt.text = "[ " + DialogueTxt.Instance.valetCallDialogue.sentences[1] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowThreeChoice(0);
                // 선택지 세팅
                break;
            case "SaturdayValetCall":
                choiceTxt.text = "[ " + DialogueTxt.Instance.valetCallDialogue.sentences[1] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowThreeChoice(0);
                break;
            case "GoingOut":
                WorldManager.Instance.ShowWorldUI();
                break;
            case "Cultivation":
                //conversation.text = "대화 종료";
                StartCoroutine(FadeInfo(0));
                // StartFadeData();
                break;
            case "CallPeddler":
                charterAnimator.SetBool("IsAlpha", true);
                Invoke("ShowSHopUIDelay", 1);
                // charterImage.gameObject.SetActive(false);
                break;
            case "BuyPaddler":
                _isBuyDialogueEnd = true;
                
                LobbyManager.Instance.ValetCall();
                break;
            case "CancelShowUI":
                LobbyManager.Instance.ValetCall();
                break;
            case "BuyPotion":
                choiceTxt.text = "[ " + DialogueTxt.Instance.buyPotionDialogue.sentences[4] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowThreeChoice(1);
                break;
            case "UsePotion":
                LobbyManager.Instance.ValetCall();
                break;
            case "OverlapUsePotion":
                choiceTxt.text = "[ " + DialogueTxt.Instance.buyPotionDialogue.sentences[4] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowThreeChoice(1);
                break;
            case "BuyChoco":
                choiceTxt.text = "[ " + DialogueTxt.Instance.buyChocoDialogue.sentences[4] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowThreeChoice(2);
                break;
            case "PlaceSelect":
                choiceTxt.text = "[ " + DialogueTxt.Instance.placeSelectDialogue.sentences[0] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(3);
                break;
            case "HomeLock":
                WorldManager.Instance.ResetTxtBox();
                break;
            case "FirstIan":
                StartCoroutine(FadeInfo(1));
                break;
            case "FirstNoa":
                StartCoroutine(FadeInfo(2));
                break;
            case "FirstAustin":
                StartCoroutine(FadeInfo(3));
                break;
            case "NobodyElse":
                StartCoroutine(FadeInfo(4));
                break;
            case "TownIan1":
                StartCoroutine(FadeInfo(1));
                break;
            case "TownIan2":
                choiceTxt.text = "[ " + DialogueTxt.Instance.townIan2Dialogue.sentences[9] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(4);
                break;
            case "TownIan2Fun":
                DailyRoutine.Instance.TownIan2Select();
                break;
            case "TownIan2Tiresome":
                DailyRoutine.Instance.TownIan2Select();
                break;
            case "TownIan2Select":
                CheckIsAddIanHeart();
                break;
            case "TownIan3":
                choiceTxt.text = "[ " + DialogueTxt.Instance.townIan3Dialogue.sentences[9] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(5);
                break;
            case "TownIan3Hi":
                CheckIsAddIanHeart();
                break;
            case "TownIan3Ignore":
                CheckIsAddIanHeart();
                break;
            case "TownIan4":
                StartCoroutine(FadeInfo(1));
                break;
            case "TownNoa1":
                choiceTxt.text = "[ " + DialogueTxt.Instance.townNoa1Dialogue.sentences[12] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(6);
                break;
            case "TownNoa1Mistake":
                DailyRoutine.Instance.TownNoa1Select();
                break;
            case "TownNoa1Stand":
                DailyRoutine.Instance.TownNoa1Select();
                break;
            case "TownNoa1Select":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightTown(4, 7, DialogueTxt.Instance.townNoa1SelectNextDialogue, "TownNoa1SelectNext", 1, true));
                break;
            case "TownNoa1SelectNext":
                CheckIsAddNoaHeart();
                break;
            case "TownNoa2":
                SettingUI.Instance.SettingSfxSound(doorAudio);
                StartCoroutine(FadeRightTown(12, 8, DialogueTxt.Instance.townNoa2NextDialogue, "TownNoa2Next", 1, true));
                break;
            case "TownNoa2Next":
                StartCoroutine(FadeInfo(2));
                break;
            case "TownNoa3":
                StartCoroutine(FadeInfo(2));
                break;
            case "TownNoa4":
                choiceTxt.text = "[ " + DialogueTxt.Instance.townNoa4Dialogue.sentences[20] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(7);
                break;
            case "TownNoa4Cheer":
                DailyRoutine.Instance.TownNoa4Select();
                break;
            case "TownNoa4Question":
                DailyRoutine.Instance.TownNoa4Select();
                break;
            case "TownNoa4Select":
                CheckIsAddNoaHeart();
                break;
            case "TownAustin1":
                StartCoroutine(FadeInfo(3));
                break;
            case "TownAustin2":
                choiceTxt.text = "[ " + DialogueTxt.Instance.townAustin2Dialogue.sentences[15] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(8);
                break;
            case "TownAustin2FireFestival":
                CheckIsAddAustinHeart();
                break;
            case "TownAustin2Around":
                CheckIsAddAustinHeart();
                break;
            case "TownAustin3":
                StartCoroutine(FadeInfo(3));
                break;
            case "TownAustin4":
                SettingUI.Instance.SettingSfxSound(shopBellAudio);
                StartCoroutine(FadeRightTown(12, 14, DialogueTxt.Instance.townAustin4NextDialogue, "TownAustin4Next", 0, true));
                break;
            case "TownAustin4Next":
                SettingUI.Instance.SettingSfxSound(shopBellAudio);
                StartCoroutine(FadeRightTown(4, 99, DialogueTxt.Instance.townAustin4OutStoreDialogue, "TownAustin4OutStore", 0, false));
                break;
            case "TownAustin4OutStore":
                StartCoroutine(FadeInfo(3));
                break;
            case "RestaurantIan1":
                choiceTxt.text = "[ " + DialogueTxt.Instance.restaurantIan1Dialogue.sentences[7] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(9);
                break;
            case "RestaurantIan1EatWell":
                CheckIsAddIanHeart();
                break;
            case "RestaurantIan1QuestionEat":
                CheckIsAddIanHeart();
                break;
            case "RestaurantIan2":
                StartCoroutine(FadeInfo(1));
                break;
            case "RestaurantNoa1":
                StartCoroutine(FadeInfo(2));
                break;
            case "RestaurantNoa2":
                choiceTxt.text = "[ " + DialogueTxt.Instance.restaurantNoa2Dialogue.sentences[15] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(10);
                break;
            case "RestaurantNoa2Good":
                DailyRoutine.Instance.RestaurantNoa2Select();
                break;
            case "RestaurantNoa2Perfect":
                DailyRoutine.Instance.RestaurantNoa2Select();
                break;
            case "RestaurantNoa2Select":
                CheckIsAddNoaHeart();
                break;
            case "RestaurantNoa3":
                SettingUI.Instance.SettingSfxSound(doorAudio);
                StartCoroutine(FadeRightTown(14, 7, DialogueTxt.Instance.restaurantNoa3NextDialogue, "RestaurantNoa3Next", 0, true));
                break;
            case "RestaurantNoa3Next":
                StartCoroutine(FadeInfo(2));
                break;
            case "RestaurantAustin1":
                StartCoroutine(FadeInfo(3));
                break;
            case "RestaurantAustin2":
                SettingUI.Instance.SettingSfxSound(doorAudio);
                StartCoroutine(FadeRightTown(6, 16, DialogueTxt.Instance.restaurantAustin2NextDialogue, "RestaurantAustin2Next", 0, true));
                break;
            case "RestaurantAustin2Next":
                choiceTxt.text = "[ " + DialogueTxt.Instance.restaurantAustin2NextDialogue.sentences[11] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(11);
                break;
            case "RestaurantAustin2Copy":
                DailyRoutine.Instance.RestaurantAustin2Select();
                break;
            case "RestaurantAustin2Wait":
                DailyRoutine.Instance.RestaurantAustin2Select();
                break;
            case "RestaurantAustin2Select":
                CheckIsAddAustinHeart();
                break;
            case "ParkIan1":
                choiceTxt.text = "[ " + DialogueTxt.Instance.parkIan1Dialogue.sentences[9] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(12);
                break;
            case "ParkIan1Plants":
                CheckIsAddIanHeart();
                break;
            case "ParkIan1NightSky":
                CheckIsAddIanHeart();
                break;
            case "ParkIan2":
                StartCoroutine(FadeInfo(1));
                break;
            case "ParkIan3":
                choiceTxt.text = "[ " + DialogueTxt.Instance.parkIan3Dialogue.sentences[14] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(13);
                break;
            case "ParkIan3Exercise":
                CheckIsAddIanHeart();
                break;
            case "ParkIan3Walk":
                DailyRoutine.Instance.ParkIan3Exercise();
                break;
            case "ParkIan4":
                StartCoroutine(FadeInfo(1));
                break;
            case "ParkIan5":
                choiceTxt.text = "[ " + DialogueTxt.Instance.parkIan5Dialogue.sentences[5] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(14);
                break;
            case "ParkIan5LookFlower":
                CheckIsAddIanHeart();
                break;
            case "ParkIan5Rest":
                CheckIsAddIanHeart();
                break;
            case "ParkNoa1":
                choiceTxt.text = "[ " + DialogueTxt.Instance.parkNoa1Dialogue.sentences[12] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(15);
                break;
            case "ParkNoa1Dog":
                DailyRoutine.Instance.ParkNoa1Select();
                break;
            case "ParkNoa1Bird":
                DailyRoutine.Instance.ParkNoa1Select();
                break;
            case "ParkNoa1Select":
                CheckIsAddNoaHeart();
                break;
            case "ParkNoa2":
                StartCoroutine(FadeInfo(2));
                break;
            case "ParkNoa3":
                if (PlayerPrefs.HasKey("PlayerName").Equals(true))
                {
                    string playerName = PlayerPrefs.GetString("PlayerName");
                
                    DialogueTxt.Instance.parkNoa3Dialogue.sentences[5] = DialogueTxt.Instance.parkNoa3Dialogue.sentences[5].Replace("[플레이어]", playerName);
                }
                choiceTxt.text = "[ " + DialogueTxt.Instance.parkNoa3Dialogue.sentences[5] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(16);
                break;
            case "ParkNoa3CuriosityPeople":
                DailyRoutine.Instance.ParkNoa3Select();
                break;
            case "ParkNoa3StupidPeople":
                DailyRoutine.Instance.ParkNoa3Select();
                break;
            case "ParkNoa3Select":
                CheckIsAddNoaHeart();
                break;
            case "ParkAustin1":
                StartCoroutine(FadeInfo(3));
                break;
            case "ParkAustin2":
                choiceTxt.text = "[ " + DialogueTxt.Instance.parkAustin2Dialogue.sentences[4] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(17);
                break;
            case "ParkAustin2TogetherFind":
                DailyRoutine.Instance.ParkAustin2Chasing();
                break;
            case "ParkAustin2Chasing":
                CheckIsAddAustinHeart();
                break;
            case "ParkAustin3":
                choiceTxt.text = "[ " + DialogueTxt.Instance.parkAustin3Dialogue.sentences[6] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(18);
                break;
            case "ParkAustin3Friend":
                DailyRoutine.Instance.ParkAustin3Select();
                break;
            case "ParkAustin3Stay":
                DailyRoutine.Instance.ParkAustin3Select();
                break;
            case "ParkAustin3Select":
                CheckIsAddAustinHeart();
                break;
            case "BeachIan1":
                StartCoroutine(FadeInfo(1));
                break;
            case "BeachIan2":
                choiceTxt.text = "[ " + DialogueTxt.Instance.beachIan2Dialogue.sentences[20] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(19);
                break;
            case "BeachIan2LookStar":
                DailyRoutine.Instance.BeachIan2Select();
                break;
            case "BeachIan2GuideStar":
                DailyRoutine.Instance.BeachIan2Select();
                break;
            case "BeachIan2Select":
                CheckIsAddIanHeart();
                break;
            case "BeachNoa1":
                StartCoroutine(FadeInfo(2));
                break;
            case "BeachNoa2":
                choiceTxt.text = "[ " + DialogueTxt.Instance.beachNoa2Dialogue.sentences[7] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(20);
                break;
            case "BeachNoa2TomorrowSend":
                DailyRoutine.Instance.BeachNoa2Select();
                break;
            case "BeachNoa2ThinkSend":
                DailyRoutine.Instance.BeachNoa2Select();
                break;
            case "BeachNoa2Select":
                CheckIsAddNoaHeart();
                break;
            case "BeachAustin1":
                StartCoroutine(FadeInfo(3));
                break;
            case "BeachAustin2":
                SettingUI.Instance.StopSfxLoopSound();
                choiceTxt.text = "[ " + DialogueTxt.Instance.beachAustin2Dialogue.sentences[25] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(21);
                break;
            case "BeachAustin2Sleep":
                DailyRoutine.Instance.BeachAustin2Select();
                break;
            case "BeachAustin2OpenEye":
                DailyRoutine.Instance.BeachAustin2Select();
                break;
            case "BeachAustin2Select":
                CheckIsAddAustinHeart();
                break;
            case "GalleryIan1":
                StartCoroutine(FadeInfo(4));
                break;
            case "GalleryNoa1":
                StartCoroutine(FadeInfo(2));
                break;
            case "GalleryNoa2":
                choiceTxt.text = "[ " + DialogueTxt.Instance.galleryNoa2Dialogue.sentences[11] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(22);
                break;
            case "GalleryNoa2Anger":
                DailyRoutine.Instance.GalleryNoa2Select();
                break;
            case "GalleryNoa2Ignore":
                DailyRoutine.Instance.GalleryNoa2Select();
                break;
            case "GalleryNoa2Select":
                CheckIsAddNoaHeart();
                break;
            case "GalleryAustin1":
                choiceTxt.text = "[ " + DialogueTxt.Instance.galleryAustin1Dialogue.sentences[10] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(23);
                break;
            case "GalleryAustin1ComingOut":
                DailyRoutine.Instance.GalleryAustin1Select();
                break;
            case "GalleryAustin1Enjoy":
                DailyRoutine.Instance.GalleryAustin1Select();
                break;
            case "GalleryAustin1Select":
                CheckIsAddAustinHeart();
                break;
            case "GalleryAustin2":
                StartCoroutine(FadeInfo(3));
                break;
            case "HomeIan1":
                choiceTxt.text = "[ " + DialogueTxt.Instance.homeIan1Dialogue.sentences[4] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(24);
                break;
            case "HomeIan1Talk":
                CheckIsAddIanHeart();
                break;
            case "HomeIan1Curiosity":
                CheckIsAddIanHeart();
                break;
            case "HomeIan2":
                StartCoroutine(FadeInfo(1));
                break;
            case "HomeNoa1":
                StartCoroutine(FadeRightTown(21, 99, DialogueTxt.Instance.homeNoa1NextDialogue, "HomeNoa1Next", 0, false));
                break;
            case "HomeNoa1Next":
                choiceTxt.text = "[ " + DialogueTxt.Instance.homeNoa1NextDialogue.sentences[3] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(25);
                break;
            case "HomeNoa1Cooperation":
                CheckIsAddNoaHeart();
                break;
            case "HomeNoa1Force":
                CheckIsAddNoaHeart();
                break;
            case "HomeNoa2":
                StartCoroutine(FadeInfo(2));
                break;
            case "HomeAustin1":
                choiceTxt.text = "[ " + DialogueTxt.Instance.homeAustin1Dialogue.sentences[8] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(26);
                break;
            case "HomeAustin1PrayerTalk":
                CheckIsAddAustinHeart();
                break;
            case "HomeAustin1NoPrayerTalk":
                CheckIsAddAustinHeart();
                break;
            case "HomeAustin2":
                choiceTxt.text = "[ " + DialogueTxt.Instance.homeAustin2Dialogue.sentences[8] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(27);
                break;
            case "HomeAustin2ThrowStone":
                CheckIsAddAustinHeart();
                break;
            case "HomeAustin2CallAustin":
                CheckIsAddAustinHeart();
                break;
            case "HomeAustin3":
                StartCoroutine(FadeInfo(3));
                break;
            case "Event1":
                choiceTxt.text = "[ " + DialogueTxt.Instance.event1Dialogue.sentences[12] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowFiveChoice(28);
                break;
            case "Event1Manner":
                StartCoroutine(FadeInfoEvent(0, 20, 1, 5));
                break;
            case "Event1Dance":
                StartCoroutine(FadeInfoEvent(0, 20, 2, 5));
                break;
            case "Event1TeaCeremony":
                StartCoroutine(FadeInfoEvent(0, 20, 3, 5));
                break;
            case "Event1SpeakArt":
                StartCoroutine(FadeInfoEvent(0, 20, 4, 5));
                break;
            case "Event1SwardArt":
                StartCoroutine(FadeInfoEvent(5, 0, 6, 5));
                break;
            case "Event2":
                StartCoroutine(FadeImage());
                break;
            case "Event2Next":
                choiceTxt.text = "[ " + DialogueTxt.Instance.event2NextDialogue.sentences[28] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowSixChoice(30);
                break;
            case "Event2Ignore":
                SettingEventCase("Event2Ignore");
                break;
            case "Event2Right":
                SettingEventCase("Event2Right");
                break;
            case "Event2Rebut":
                SettingRotationMaxim(1080, 1920, 0);
                StartCoroutine(GetMaximAlbum(0, false));
                break;
            case "GetAlbum1":
                SettingEventCase("Event2Rebut");
                break;
            case "Event2HitCheek":
                SettingRotationMaxim(1080, 1920, 0);
                StartCoroutine(GetMaximAlbum(1, false));
                break;
            case "GetAlbum2":
                SettingEventCase("Event2HitCheek");
                break;
            case "Event2WineSpray":
                charterAnimator.SetBool("IsAlpha", true);
                Invoke("DelayGetMaximAlbum2", 1);
                break;
            case "GetAlbum3":
                SettingEventCase("Event2WineSpray");
                break;
            case "Event2Cry":
                SettingEventCase("Event2Cry");
                break;
            case "Event2Select":
                ChoiceManager.Instance.isSelectEvent3 = true;
                
                choiceTxt.text = "[ " + DialogueTxt.Instance.event2Select.sentences[14] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowThreeChoice(32);
                break;
            case "Event3Ian":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(3, 0, DialogueTxt.Instance.event3IanNextDialogue, "Event3IanNext", 0, true));
                break;
            case "Event3IanNext":
                charterAnimator.SetBool("IsAlpha", true);
                Invoke("DelayGetMaximAlbum3", 1);
                break;
            case "GetAlbum4":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(1, 1, DialogueTxt.Instance.getAlbum4NextDialogue, "GetAlbum4Next", 0, true));
                break;
            case "GetAlbum4Next":
                choiceTxt.text = "[ " + DialogueTxt.Instance.getAlbum4NextDialogue.sentences[63] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(33);
                break;
            case "Even3IanDrink":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeDream(4));
                break;
            case "Even3IanWait":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(2, 0, DialogueTxt.Instance.even3IanWaitNextDialogue, "Even3IanWaitNext", 0, false));
                break;
            case "Even3IanWaitNext":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeDream(4));
                break;
            case "Event3Noa":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(1, 1, DialogueTxt.Instance.event3NoaNextDialogue, "Event3NoaNext", 1, true));
                break;
            case "Event3NoaNext":
                choiceTxt.text = "[ " + DialogueTxt.Instance.event3NoaNextDialogue.sentences[47] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(34);
                break;
            case "Event3NoaStay":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(5, 2, DialogueTxt.Instance.event3NoaStayNextDialogue, "Event3NoaStayNext", 1, true));
                break;
            case "Event3NoaStayNext":
                LobbyManager.Instance.Event3NoaSelect();
                break;
            case "Event3NoaAvoid":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(5, 2, DialogueTxt.Instance.event3NoaAvoidNextDialogue, "Event3NoaAvoidNext", 0, true));
                break;
            case "Event3NoaAvoidNext":
                LobbyManager.Instance.Event3NoaSelect();
                break;
            case "Event3NoaSelect":
                charterAnimator.SetBool("IsAlpha", true);
                Invoke("DelayGetMaximAlbum4", 1);
                break;
            case "GetAlbum5":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeDream(4));
                break;
            case "Event3Austin":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(3, 0, DialogueTxt.Instance.event3AustinNextDialogue, "Event3AustinNext", 1, false));
                break;
            case "Event3AustinNext":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(1, 1, DialogueTxt.Instance.event3AustinPartyDialogue, "Event3AustinParty", 0, true));
                break;
            case "Event3AustinParty":
                SettingUI.Instance.SettingSfxSound(footSteps2);
                StartCoroutine(FadeRightHome(5, 3, DialogueTxt.Instance.event3AustinPartyNextDialogue, "Event3AustinPartyNext", 1, true));
                break;
            case "Event3AustinPartyNext":
                choiceTxt.text = "[ " + DialogueTxt.Instance.event3AustinPartyNextDialogue.sentences[26] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(35);
                break;
            case "Event3AustinBelieve":
                LobbyManager.Instance.Event3AustinSelect();
                break;
            case "Event3AustinWind":
                LobbyManager.Instance.Event3AustinSelect();
                break;
            case "Event3AustinSelect":
                charterAnimator.runtimeAnimatorController = charterController;
                charterAnimator.SetBool("IsAlpha", true);
                Invoke("DelayGetMaximAlbum5", 1);
                break;
            case "GetAlbum6":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeDream(4));
                break;
            case "Event3Next":
                ChoiceManager.Instance.isSelectEvent3 = true;
                
                choiceTxt.text = "[ " + DialogueTxt.Instance.event3NextDialogue.sentences[3] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowThreeChoice(36);
                break;
            case "Event4Ian":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(6, 0, DialogueTxt.Instance.event4IanNextDialogue, "Event4IanNext", 0, false));
                break;
            case "Event4IanNext":
                choiceTxt.text = "[ " + DialogueTxt.Instance.event4IanNextDialogue.sentences[43] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(37);
                break;
            case "Event4IanFrankly":
                LobbyManager.Instance.Event4IanSelect();
                break;
            case "Event4IanBright":
                LobbyManager.Instance.Event4IanSelect();
                break;
            case "Event4IanSelect":
                charterAnimator.runtimeAnimatorController = charterController;
                charterAnimator.SetBool("IsAlpha", true);
                Invoke("DelayGetMaximAlbum6", 1);
                break;
            case "GetAlbum7":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(7, 0, DialogueTxt.Instance.getAlbum7NextDialogue, "GetAlbum7Next", 0, false));
                break;
            case "GetAlbum7Next":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                if (LobbyManager.Instance.nowHeart[0] >= 54)
                {
                    StartCoroutine(FadeRightHome(9, 4, DialogueTxt.Instance.event4DreamDialogue, "Event4Dream", 0, true));
                }
                else
                {
                    if (ChoiceManager.Instance.isAddIanHeart.Equals(true))
                    {
                        StartCoroutine(FadeInfoEvent(8, 0, 1, 15));
                    }
                    else
                    {
                        StartCoroutine(FadeInfoEvent(8, 0, 9, 10));
                    }
                }
                break;
            case "Event4Noa":
                choiceTxt.text = "[ " + DialogueTxt.Instance.event4NoaDialogue.sentences[144] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(38);
                break;
            case "Event4NoaOkay":
                charterAnimator.runtimeAnimatorController = charterController;
                charterAnimator.SetBool("IsAlpha", true);
                Invoke("DelayGetMaximAlbum7", 1);
                break;
            case "GetAlbum8":
                LobbyManager.Instance.Event4NoaSelect();
                break;
            case "Event4NoaGood":
                LobbyManager.Instance.Event4NoaSelect();
                break;
            case "Event4NoaSelect":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                if (LobbyManager.Instance.nowHeart[0] >= 54)
                {
                    StartCoroutine(FadeRightHome(9, 4, DialogueTxt.Instance.event4DreamDialogue, "Event4Dream", 0, true));
                }
                else
                {
                    if (ChoiceManager.Instance.isAddIanHeart.Equals(true))
                    {
                        StartCoroutine(FadeInfoEvent(8, 0, 2, 15));
                    }
                    else
                    {
                        StartCoroutine(FadeInfoEvent(8, 0, 10, 10));
                    }
                }
                break;
            case "Event4Austin":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(8, 0, DialogueTxt.Instance.event4AustinNextDialogue, "Event4AustinNext", 1, false));
                break;
            case "Event4AustinNext":
                SettingRotationMaxim(1080, 1920, 0);
                StartCoroutine(GetMaximAlbum(8, false));
                break;
            case "GetAlbum9":
                choiceTxt.text = "[ " + DialogueTxt.Instance.getAlbum9Dialogue.sentences[35] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowTwoChoice(39);
                break;
            case "Event4AustinJoke":
                LobbyManager.Instance.Event4AustinSelect();
                break;
            case "Event4AustinThink":
                LobbyManager.Instance.Event4AustinSelect();
                break;
            case "Event4AustinSelect":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                if (LobbyManager.Instance.nowHeart[0] >= 54)
                {
                    StartCoroutine(FadeRightHome(9, 4, DialogueTxt.Instance.event4DreamDialogue, "Event4Dream", 0, true));
                }
                else
                {
                    if (ChoiceManager.Instance.isAddIanHeart.Equals(true))
                    {
                        StartCoroutine(FadeInfoEvent(8, 0, 3, 15));
                    }
                    else
                    {
                        StartCoroutine(FadeInfoEvent(8, 0, 11, 10));
                    }
                }
                break;
            case "Event4Dream":
                charterAnimator.runtimeAnimatorController = charterController;
                charterAnimator.SetBool("IsAlpha", true);
                Invoke("DelayChoiceEndingCharacter", 1);
                break;
            case "HappyEndingIan":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(11, 0, DialogueTxt.Instance.happyEndingIanNextDialogue, "HappyEndingIanNext", 1, false));
                break;
            case "HappyEndingIanNext":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(12, 0, DialogueTxt.Instance.happyEndingIanNextNextDialogue, "HappyEndingIanNextNext", 1, false));
                break;
            case "HappyEndingIanNextNext":
                choiceTxt.text = "[ " + DialogueTxt.Instance.happyEndingIanNextNextDialogue.sentences[98] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowOneChoice(40);
                break;
            case "GetAlbum10":
                StartCoroutine(FadeEnding());
                break;
            case "HappySadEndingIan":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(13, 0, DialogueTxt.Instance.happySadEndingIanNextDialogue, "HappySadEndingIanNext", 1, false));
                break;
            case "HappySadEndingIanNext":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(14, 0, DialogueTxt.Instance.happySadEndingIanNextNextDialogue, "HappySadEndingIanNextNext", 1, false));
                break;
            case "HappySadEndingIanNextNext":
                charterAnimator.runtimeAnimatorController = charterController;
                charterAnimator.SetBool("IsAlpha", true);
                Invoke("DelayGetMaximAlbum12", 1);
                break;
            case "GetAlbum13":
                StartCoroutine(FadeEnding());
                break;
            case "HappyEndingNoa":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(13, 0, DialogueTxt.Instance.happyEndingNoaNextDialogue, "HappyEndingNoaNext", 1, false));
                break;
            case "HappyEndingNoaNext":
                charterAnimator.runtimeAnimatorController = charterController;
                charterAnimator.SetBool("IsAlpha", true);
                Invoke("DelayGetMaximAlbum10", 1);
                break;
            case "GetAlbum11":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(15, 0, DialogueTxt.Instance.getAlbum11NextDialogue, "GetAlbum11Next", 1, false));
                break;
            case "GetAlbum11Next":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(0, 0, DialogueTxt.Instance.getAlbum11NextNextDialogue, "GetAlbum11NextNext", 1, false));
                break;
            case "GetAlbum11NextNext":
                StartCoroutine(FadeEnding());
                break;
            case "HappySadEndingNoa":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(13, 0, DialogueTxt.Instance.happySadEndingNoaNextDialogue, "HappySadEndingNoaNext", 1, false));
                break;
            case "HappySadEndingNoaNext":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(1, 0, DialogueTxt.Instance.happySadEndingNoaNextNextDialogue, "HappySadEndingNoaNextNext", 1, false));
                break;
            case "HappySadEndingNoaNextNext":
                choiceTxt.text = "[ " + DialogueTxt.Instance.happySadEndingNoaNextNextDialogue.sentences[5] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowOneChoice(41);
                break;
            case "GetAlbum14":
                StartCoroutine(FadeEnding());
                break;
            case "HappyEndingAustin":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(15, 0, DialogueTxt.Instance.happyEndingAustinNextDialogue, "HappyEndingAustinNext", 1, false));
                break;
            case "HappyEndingAustinNext":
                choiceTxt.text = "[ " + DialogueTxt.Instance.happyEndingAustinNextDialogue.sentences[42] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowOneChoice(42);
                break;
            case "GetAlbum12":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(0, 0, DialogueTxt.Instance.getAlbum12NextDialogue, "GetAlbum12Next", 1, false));
                break;
            case "GetAlbum12Next":
                StartCoroutine(FadeEnding());
                break;
            case "HappySadEndingAustin":
                charterAnimator.runtimeAnimatorController = charterController;
                charterAnimator.SetBool("IsAlpha", true);
                Invoke("DelayGetMaximAlbum14", 1);
                break;
            case "GetAlbum15":
                StartCoroutine(FadeEnding());
                break;
            case "NormalEndingIan":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(13, 0, DialogueTxt.Instance.normalEndingIanNextDialogue, "NormalEndingIanNext", 1, false));
                break;
            case "NormalEndingIanNext":
                DelayGetMaximAlbum15();
                break;
            case "GetAlbum16":
                StartCoroutine(FadeEnding());
                break;
            case "NormalEndingNoa":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(13, 0, DialogueTxt.Instance.normalEndingNoaNextDialogue, "NormalEndingNoaNext", 1, false));
                break;
            case "NormalEndingNoaNext":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(3, 0, DialogueTxt.Instance.normalEndingNoaNextNextDialogue, "NormalEndingNoaNextNext", 1, false));
                break;
            case "NormalEndingNoaNextNext":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(18, 0, DialogueTxt.Instance.normalEndingNoaNextNextNextDialogue, "NormalEndingNoaNextNextNext", 1, false));
                break;
            case "NormalEndingNoaNextNextNext":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                SettingUI.Instance.StopBgmAudioSource();
                StartCoroutine(FadeRightHome(16, 0, DialogueTxt.Instance.normalEndingNoaNextNextNextNextDialogue, "NormalEndingNoaNextNextNextNext", 1, false));
                break;
            case "NormalEndingNoaNextNextNextNext":
                DelayGetMaximAlbum16();
                break;
            case "GetAlbum17":
                StartCoroutine(FadeEnding());
                break;
            case "NormalEndingAustinDialogue":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(0, 0, DialogueTxt.Instance.normalEndingAustinNextDialogue, "NormalEndingAustinNext", 1, false));
                break;
            case "NormalEndingAustinNext":
                SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
                StartCoroutine(FadeRightHome(15, 0, DialogueTxt.Instance.normalEndingAustinNextNextDialogue, "NormalEndingAustinNextNext", 1, false));
                break;
            case "NormalEndingAustinNextNext":
                DelayGetMaximAlbum17();
                // Debug.Log("데이 1부터 리셋");
                break;
            case "BadEnding":
                DelayGetMaximAlbum18();
                // Debug.Log("데이 1부터 리셋");
                break;
        }
    }

    public void SettingFadeInfoEvent()
    {
        switch (_event2Case)
        {
            case "Event2Ignore":
                StartCoroutine(FadeInfoEvent(0, 8, 4, 0));
                break;
            case "Event2Right":
                StartCoroutine(FadeInfoEvent(5, 6, 7, 5));
                break;
            case "Event2Rebut":
                StartCoroutine(FadeInfoEvent(5, 6, 1, 10));
                break;
            case "Event2HitCheek":
                StartCoroutine(FadeInfoEvent(5, 6, 2, 10));
                break;
            case "Event2WineSpray":
                StartCoroutine(FadeInfoEvent(5, 6, 3, 10));
                break;
            case "Event2Cry":
                StartCoroutine(FadeInfoEvent(0, 8, 6, 10));
                break;
        }
    }

    public void SettingEvent3Next()
    {
        switch (ChoiceManager.Instance.event3WhoNum)
        {
            case 1:
                if (ChoiceManager.Instance.isAddIanHeart.Equals(true))
                {
                    StartCoroutine(FadeInfoEvent(8, 0, 1, 15));
                }
                else
                {
                    StartCoroutine(FadeInfoEvent(8, 0, 9, 10));
                }
                break;
            case 2:
                if (ChoiceManager.Instance.isAddIanHeart.Equals(true))
                {
                    StartCoroutine(FadeInfoEvent(8, 0, 2, 15));
                }
                else
                {
                    StartCoroutine(FadeInfoEvent(8, 0, 10, 10));
                }
                break;
            case 3:
                if (ChoiceManager.Instance.isAddIanHeart.Equals(true))
                {
                    StartCoroutine(FadeInfoEvent(8, 0, 3, 15));
                }
                else
                {
                    StartCoroutine(FadeInfoEvent(8, 0, 11, 10));
                }
                break;
        }
    }

    private void DelayChoiceEndingCharacter()
    {
        StartCoroutine(ChoiceEndingCharacter());
    }

    private IEnumerator ChoiceEndingCharacter()
    {
        endingCharacterImage[0].color = new Color(1, 1, 1, 0);
        endingCharacterImage[1].color = new Color(1, 1, 1, 0);
        endingCharacterImage[2].color = new Color(1, 1, 1, 0);
        endingCharacterBackImage.color = new Color(1, 1, 1, 0);
        
        _isChoiceEndingCharacter = true;
        
        SettingUI.Instance.SettingSfxSound(illustrationAudio);

        choiceEndingUIGo.SetActive(true);

        _time = 0f;
        
        Color alpha = endingCharacterImage[0].color;
        
        while (alpha.a < 1f)
        {
            _time += Time.deltaTime / _currentFadeTime;
            
            alpha.a = Mathf.Lerp(0, 1, _time);
            
            endingCharacterImage[0].color = alpha;
            endingCharacterImage[1].color = alpha;
            endingCharacterImage[2].color = alpha;
            endingCharacterBackImage.color = alpha;
            
            yield return null;
        }
        _time = 0f;
        
        yield return _yieldAnimDelay;

        _isChoiceEndingCharacter = false;
    }
    
    

    private void DelayGetMaximAlbum2()
    {
        SettingRotationMaxim(1080, 1920, 0);
        StartCoroutine(GetMaximAlbum(2, false));
    }
    
    private void DelayGetMaximAlbum3()
    {
        SettingRotationMaxim(1080, 1920, 0);
        StartCoroutine(GetMaximAlbum(3, false));
    }
    
    private void DelayGetMaximAlbum4()
    {
        SettingRotationMaxim(1080, 1920, 0);
        StartCoroutine(GetMaximAlbum(4, false));
    }
    
    private void DelayGetMaximAlbum5()
    {
        SettingRotationMaxim(1080, 1920, 0);
        StartCoroutine(GetMaximAlbum(5, false));
    }
    
    private void DelayGetMaximAlbum6()
    {
        SettingRotationMaxim(1080, 1920, 0);
        StartCoroutine(GetMaximAlbum(6, false));
    }
    
    private void DelayGetMaximAlbum7()
    {
        SettingRotationMaxim(1080, 1920, 0);
        StartCoroutine(GetMaximAlbum(7, false));
    }
    
    public void DelayGetMaximAlbum9()
    {
        SettingRotationMaxim(1920, 1080, -90);
        StartCoroutine(GetMaximAlbum(9, false));
    }
    
    public void DelayGetMaximAlbum10()
    {
        SettingRotationMaxim(1080, 1920, 0);
        StartCoroutine(GetMaximAlbum(10, false));
    }
    
    public void DelayGetMaximAlbum11()
    {
        SettingRotationMaxim(1080, 1920, 0);
        StartCoroutine(GetMaximAlbum(11, false));
    }
    
    public void DelayGetMaximAlbum12()
    {
        SettingRotationMaxim(1080, 1920, 0);
        StartCoroutine(GetMaximAlbum(12, false));
    }
    
    public void DelayGetMaximAlbum13()
    {
        SettingRotationMaxim(1080, 1920, 0);
        StartCoroutine(GetMaximAlbum(13, true));
    }
    
    public void DelayGetMaximAlbum14()
    {
        SettingRotationMaxim(1080, 1920, 0);
        StartCoroutine(GetMaximAlbum(14, false));
    }
    
    public void DelayGetMaximAlbum15()
    {
        SettingRotationMaxim(1080, 1920, 0);
        StartCoroutine(GetMaximAlbum(15, false));
    }
    
    public void DelayGetMaximAlbum16()
    {
        SettingRotationMaxim(1080, 1920, 0);
        StartCoroutine(GetMaximAlbum(16, false));
    }
    
    public void DelayGetMaximAlbum17()
    {
        SettingRotationMaxim(1080, 1920, 0);
        StartCoroutine(GetMaximAlbum(17, false));
    }
    
    public void DelayGetMaximAlbum18()
    {
        SettingRotationMaxim(1080, 1920, 0);
        StartCoroutine(GetMaximAlbum(18, false));
    }

    public void SettingRotationMaxim(int sizeX, int sizeY, int rotZ)
    {
        if (rotZ == -90)
        {
            getMaximImageCancelImage.rectTransform.localPosition = new Vector3(-885, 465, 0);
        }
        else
        {
            getMaximImageCancelImage.rectTransform.localPosition = new Vector3(465, 885, 0);
        }
     
        getMaximImage.rectTransform.sizeDelta = new Vector2(sizeX, sizeY);
        getMaximImage.rectTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, rotZ));
    }

    private IEnumerator GetMaximAlbum(int num, bool doorSound)
    {
        getMaximImage.color = new Color(1, 1, 1, 0);
        getMaximImageCancelImage.color = new Color(1, 1, 1, 0);
        
        _isCancelIllustration = true;

        if (doorSound.Equals(true))
        {
            SettingUI.Instance.SettingSfxSound(doorAudio);
        }
        else
        {
            SettingUI.Instance.SettingSfxSound(illustrationAudio);
        }
        
        
        getMaximImage.sprite = LobbyManager.Instance.illustration[num];
        
        getMaximImage.gameObject.SetActive(true);
        LobbyManager.Instance.ClearAlbum(num);

        _time = 0f;
        
        Color alpha = getMaximImage.color;
        
        while (alpha.a < 1f)
        {
            _time += Time.deltaTime / _currentFadeTime;
            
            alpha.a = Mathf.Lerp(0, 1, _time);
            
            getMaximImage.color = alpha;
            getMaximImageCancelImage.color = alpha;
            
            yield return null;
        }
        _time = 0f;
        
        yield return _yieldAnimDelay;

        _isCancelIllustration = false;
    }

    public void HideGetMaximAlbum()
    {
        if (_isCancelIllustration.Equals(false))
        {
            SettingUI.Instance.SettingSfxSound(clickAudio);
        
            getMaximImage.gameObject.SetActive(false);
        
            switch (_situationCase)
            {
                case "Event2Rebut":
                    LobbyManager.Instance.GetAlbum(DialogueTxt.Instance.getAlbum1Dialogue, "GetAlbum1");
                    break;
                case "Event2HitCheek":
                    LobbyManager.Instance.GetAlbum(DialogueTxt.Instance.getAlbum2Dialogue, "GetAlbum2");
                    break;
                case "Event2WineSpray":
                    LobbyManager.Instance.GetAlbum(DialogueTxt.Instance.getAlbum3Dialogue, "GetAlbum3");
                    break;
                case "Event3IanNext":
                    LobbyManager.Instance.GetAlbum(DialogueTxt.Instance.getAlbum4Dialogue, "GetAlbum4");
                    break;
                case "Event3NoaSelect":
                    LobbyManager.Instance.GetAlbum(DialogueTxt.Instance.getAlbum5Dialogue, "GetAlbum5");
                    break;
                case "Event3AustinSelect":
                    LobbyManager.Instance.GetAlbum(DialogueTxt.Instance.getAlbum6Dialogue, "GetAlbum6");
                    break;
                case "Event4IanSelect":
                    LobbyManager.Instance.GetAlbum(DialogueTxt.Instance.getAlbum7Dialogue, "GetAlbum7");
                    break;
                case "Event4NoaOkay":
                    LobbyManager.Instance.GetAlbum(DialogueTxt.Instance.getAlbum8Dialogue, "GetAlbum8");
                    break;
                case "Event4AustinNext":
                    LobbyManager.Instance.GetAlbum(DialogueTxt.Instance.getAlbum9Dialogue, "GetAlbum9");
                    break;
                case "HappyEndingIanNextNext":
                    LobbyManager.Instance.GetAlbum(DialogueTxt.Instance.getAlbum10Dialogue, "GetAlbum10");
                    break;
                case "HappySadEndingIanNextNext":
                    LobbyManager.Instance.GetAlbum(DialogueTxt.Instance.getAlbum13Dialogue, "GetAlbum13");
                    break;
                case "HappyEndingNoaNext":
                    LobbyManager.Instance.GetAlbum(DialogueTxt.Instance.getAlbum11Dialogue, "GetAlbum11");
                    break;
                case "HappySadEndingNoaNextNext":
                    LobbyManager.Instance.SettingBackImage(16);
                    LobbyManager.Instance.GetAlbum(DialogueTxt.Instance.getAlbum14Dialogue, "GetAlbum14");
                    break;
                case "HappyEndingAustinNext":
                    LobbyManager.Instance.GetAlbum(DialogueTxt.Instance.getAlbum12Dialogue, "GetAlbum12");
                    break;
                case "HappySadEndingAustin":
                    LobbyManager.Instance.GetAlbum(DialogueTxt.Instance.getAlbum15Dialogue, "GetAlbum15");
                    break;
                case "NormalEndingIanNext":
                    LobbyManager.Instance.GetAlbum(DialogueTxt.Instance.getAlbum16Dialogue, "GetAlbum16");
                    break;
                case "NormalEndingNoaNextNextNextNext":
                    LobbyManager.Instance.GetAlbum(DialogueTxt.Instance.getAlbum17Dialogue, "GetAlbum17");
                    break;
                case "NormalEndingAustinNextNext":
                    StartCoroutine(FadeEnding());
                    break;
                case "BadEnding":
                    StartCoroutine(FadeEnding());
                    break;
            }
        }
    }

    private void SettingEventCase(string event2Case)
    {
        _event2Case = event2Case;
        SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
        StartCoroutine(FadeImageAlpha());
    }

    private void CheckIsAddIanHeart()
    {
        if (ChoiceManager.Instance.isAddIanHeart.Equals(false))
        {
            StartCoroutine(FadeInfo(4));
        }
        else
        {
            StartCoroutine(FadeInfo(1));
        }
    }

    private void CheckIsAddNoaHeart()
    {
        if (ChoiceManager.Instance.isAddIanHeart.Equals(false))
        {
            StartCoroutine(FadeInfo(4));
        }
        else
        {
            StartCoroutine(FadeInfo(2));
        }
    }
    
    private void CheckIsAddAustinHeart()
    {
        if (ChoiceManager.Instance.isAddIanHeart.Equals(false))
        {
            StartCoroutine(FadeInfo(4));
        }
        else
        {
            StartCoroutine(FadeInfo(3));
        }
    }

    private void ShowSHopUIDelay()
    {
        dialogueWindow.gameObject.SetActive(false);
        shopUI.SetActive(true);
        LobbyManager.Instance.lobbyNextBtnGo.SetActive(false);
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

    private bool _isPlayAnim;

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
                    _isPlayAnim = false;
                    
                    switch (situationCase)
                    {
                        case "Tutorial":
                            _isPlayAnim = true;
                            
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
                            _isPlayAnim = true;
                            
                            if (count == 1)
                            {
                                if (_isBuyDialogueEnd.Equals(true))
                                {
                                    yield return _yieldCharterChangeDelay;
                                    charterImage.sprite = _listCharters[count];
                                    _isBuyDialogueEnd = false;
                                }
                                else
                                {
                                    charterAnimator.SetBool("IsAlpha", true); 
                                    yield return _yieldCharterChangeDelay;
                                    ChangeWindowImage();
                                }
                            }
                            else
                            {
                                charterAnimator.SetBool("IsAlpha", true);
                                yield return _yieldCharterChangeDelay;
                                ChangeWindowImage();
                            }
                            break;
                        case "FirstNoa":
                            _isPlayAnim = true;
                            
                            if (count == 36)
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
                        case "FirstAustin":
                            _isPlayAnim = true;
                            
                            if (count == 18)
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
                        case "TownIan4":
                            _isPlayAnim = true;
                            
                            if (count == 5)
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
                        case "TownNoa3":
                            _isPlayAnim = true;
                            
                            if (count == 6)
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
                        case "TownAustin2":
                            _isPlayAnim = true;
                            
                            if (count == 4)
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
                        case "RestaurantNoa1":
                            _isPlayAnim = true;
                            
                            if (count == 19)
                            {
                                yield return _yieldCharterChangeDelay;
                                dialogueWindow.sprite = _listDialogueWindows[count];
                                charterImage.sprite = _listCharters[count];
                                SettingUI.Instance.SettingSfxSound(Exclamation3Audio);
                            }
                            else
                            {
                                charterAnimator.SetBool("IsAlpha", true);
                                yield return _yieldCharterChangeDelay;
                                ChangeWindowImage();
                            }
                            break;
                        case "RestaurantNoa2":
                            _isPlayAnim = true;
                            
                            if (count == 2)
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
                        case "RestaurantNoa3":
                            _isPlayAnim = true;
                            
                            if (count == 13)
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
                        case "ParkIan4":
                            _isPlayAnim = true;
                            
                            if (count == 24)
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
                        case "ParkNoa2":
                            _isPlayAnim = true;
                            
                            if (count == 16)
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
                        case "BeachIan1":
                            _isPlayAnim = true;
                            
                            if (count == 14)
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
                        case "BeachNoa2Select":
                            _isPlayAnim = true;
                            
                            if (count == 10)
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
                        case "GalleryIan1":
                            _isPlayAnim = true;
                            
                            if (count == 3)
                            {
                                yield return _yieldCharterChangeDelay;
                                dialogueWindow.sprite = _listDialogueWindows[count];
                                charterImage.sprite = _listCharters[count];
                                SettingUI.Instance.SettingSfxSound(questionAudio);
                            }
                            else
                            {
                                charterAnimator.SetBool("IsAlpha", true);
                                yield return _yieldCharterChangeDelay;
                                ChangeWindowImage();
                            }
                            break;
                        case "HomeIan1Talk":
                            _isPlayAnim = true;
                            
                            if (count == 8)
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
                        case "Event2Next":
                            _isPlayAnim = true;
                            
                            if (count == 16 || count == 17 || count == 24)
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
                        case "Event2Ignore":
                            _isPlayAnim = true;
                            
                            if (count == 1)
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
                        case "Event2Right":
                            _isPlayAnim = true;
                            
                            if (count == 1)
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
                        case "Event2Rebut":
                            _isPlayAnim = true;
                            
                            if (count == 1 || count == 15)
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
                        case "Event2WineSpray":
                            _isPlayAnim = true;
                            
                            if (count == 1)
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
                        case "GetAlbum3":
                            _isPlayAnim = true;
                            
                            if (count == 14)
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
                        case "Event3Ian":
                            _isPlayAnim = true;
                            
                            if (count == 8)
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
                        case "GetAlbum4":
                            _isPlayAnim = true;
                            
                            if (count == 3 || count == 4)
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
                        case "GetAlbum4Next":
                            _isPlayAnim = true;
                            
                            if (count == 19 || count == 21 || count == 38 || count == 63)
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
                        case "Even3IanWaitNext":
                            _isPlayAnim = true;
                            
                            if (count == 3)
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
                        case "Event3NoaNext":
                            _isPlayAnim = true;
                            
                            if (count == 43)
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
                        case "Event3NoaStayNext":
                            _isPlayAnim = true;
                            
                            if (count == 2)
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
                        case "Event4IanSelect":
                            _isPlayAnim = true;
                            
                            if (count == 65 || count == 70 || count == 71)
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
                        case "GetAlbum7":
                            _isPlayAnim = true;
                            
                            if (count == 8)
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
                        case "Event4Noa":
                            _isPlayAnim = true;
                            
                            if (count == 23 || count == 31 || count == 36 || count == 95 || count == 105)
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
                        case "Event4NoaOkay":
                            _isPlayAnim = true;
                            
                            if (count == 3)
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
                        case "Event4NoaSelect":
                            _isPlayAnim = true;
                            
                            if (count == 17)
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
                        case "Event4NoaGood":
                            _isPlayAnim = true;
                            
                            if (count == 3)
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
                        case "Event4AustinNext":
                            _isPlayAnim = true;
                            
                            if (count == 9)
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
                        case "GetAlbum9":
                            _isPlayAnim = true;

                            if (count == 31)
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
                        case "Event4AustinJoke":
                            _isPlayAnim = true;
                            
                            if (count == 2)
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
                        case "Event4AustinThink":
                            _isPlayAnim = true;
                            
                            if (count == 2)
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
                        case "HappyEndingIan":
                            _isPlayAnim = true;
                            
                            if (count == 6 || count == 7)
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
                        case "HappyEndingIanNextNext":
                            _isPlayAnim = true;
                            
                            if (count == 16 || count == 17)
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
                        case "HappyEndingNoa":
                            _isPlayAnim = true;
                            
                            if (count == 8)
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
                        case "HappyEndingNoaNext":
                            _isPlayAnim = true;
                            
                            if (count == 35)
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
                        case "HappySadEndingNoaNext":
                            _isPlayAnim = true;
                            
                            if (count == 12)
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
                        case "HappyEndingAustin":
                            _isPlayAnim = true;
                            
                            if (count == 7 || count == 8)
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
                    }
                   
                    if (_isPlayAnim.Equals(false))
                    {
                        charterAnimator.SetBool("IsAlpha", true); 
                        yield return _yieldCharterChangeDelay;
                        ChangeWindowImage();
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
                        case "Event2WineSpray":
                            switch (count)
                            {
                                case 18:
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
                else if (_listCharters[count].name.Contains("IAN").Equals(true))
                {
                    charterName.text = "이안 칼릭스";
                }
                else if (_listCharters[count].name.Contains("NOA_Dark").Equals(true) || _listCharters[count].name.Contains("ASUTIN_Dark").Equals(true))
                {
                    charterName.text = "???";
                }
                else if (_listCharters[count].name.Contains("NOA").Equals(true))
                {
                    charterName.text = "노아 셀베스틴";
                }
                else if (_listCharters[count].name.Contains("ASUTIN").Equals(true))
                {
                    charterName.text = "아스틴";
                }
                else
                {
                    charterName.text = "";
                }

                // string 
                switch (situationCase)
                {
                    case "CallPeddler":
                        if (_listCharters[count].name.Contains("Dealer").Equals(true))
                        {
                            charterName.text = "행상인";
                        }
                        break;
                    case "BuyPotion":
                        if (_listCharters[count].name.Contains("Dealer").Equals(true))
                        {
                            charterName.text = "행상인";
                        }
                        break;
                    case "BuyChoco":
                        if (_listCharters[count].name.Contains("Dealer").Equals(true))
                        {
                            charterName.text = "행상인";
                        }
                        break;
                    case "CancelShowUI":
                        if (_listCharters[count].name.Contains("Dealer").Equals(true))
                        {
                            charterName.text = "행상인";
                        }
                        break;
                    case "FirstIan":
                        if (_listCharters[count].name.Contains("Aide").Equals(true))
                        {
                            charterName.text = "보좌관";
                        }
                        break;
                    case "TownNoa1":
                        if (_listCharters[count].name.Contains("Man1").Equals(true))
                        {
                            charterName.text = "덩치 큰 남자";
                        }
                        break;  
                    case "TownNoa2Next":
                        if (_listCharters[count].name.Contains("Clerk").Equals(true))
                        {
                            charterName.text = "점원";
                        }
                        break;
                    case "TownNoa3":
                        if (_listCharters[count].name.Contains("HorseMan").Equals(true))
                        {
                            charterName.text = "마부";
                        }
                        break;
                    case "ParkIan2":
                        if (_listCharters[count].name.Contains("Child1").Equals(true))
                        {
                            charterName.text = "꼬마아이";
                        }
                        break;
                    case "ParkNoa2":
                        if (_listCharters[count].name.Contains("Man4").Equals(true))
                        {
                            charterName.text = "치한";
                        }
                        break;
                    case "ParkAustin3":
                        if (_listCharters[count].name.Contains("Child2").Equals(true))
                        {
                            charterName.text = "아이";
                        }
                        break;
                    case "GalleryIan1":
                        if (_listCharters[count].name.Contains("Aide").Equals(true))
                        {
                            charterName.text = "보좌관";
                        }
                        break;
                    case "GalleryAustin1":
                        if (_listCharters[count].name.Contains("Man5").Equals(true))
                        {
                            charterName.text = "신관";
                        }
                        break;
                    case "HomeAustin2":
                        if (_listCharters[count].name.Contains("Man2").Equals(true))
                        {
                            charterName.text = "귀족 남자";
                        }
                        else if (_listCharters[count].name.Contains("Child2").Equals(true))
                        {
                            charterName.text = "아이";
                        }
                        break;
                    case "HomeAustin2ThrowStone":
                        if (_listCharters[count].name.Contains("Child2").Equals(true))
                        {
                            charterName.text = "아이";
                        }
                        break;
                    case "Event2":
                        if (_listCharters[count].name.Contains("Man3").Equals(true))
                        {
                            charterName.text = "시종";
                        }
                        break;
                    case "Event2Next":
                        if (_listCharters[count].name.Contains("Olivia").Equals(true))
                        {
                            charterName.text = "올리비아";
                        }
                        else if (_listCharters[count].name.Contains("Penelope").Equals(true))
                        {
                            charterName.text = "페넬로페";
                        }
                        break;
                    case "Event2Ignore":
                        if (_listCharters[count].name.Contains("Olivia").Equals(true))
                        {
                            charterName.text = "올리비아";
                        }
                        else if (_listCharters[count].name.Contains("Penelope").Equals(true))
                        {
                            charterName.text = "페넬로페";
                        }
                        break;
                    case "Event2Right":
                        if (_listCharters[count].name.Contains("Penelope").Equals(true))
                        {
                            charterName.text = "페넬로페";
                        }
                        break;
                    case "Event2Rebut":
                        if (_listCharters[count].name.Contains("Penelope").Equals(true))
                        {
                            charterName.text = "페넬로페";
                        }
                        break;
                    case "Event2HitCheek":
                        if (_listCharters[count].name.Contains("Penelope").Equals(true))
                        {
                            charterName.text = "페넬로페";
                        }
                        break;
                    case "Event2WineSpray":
                        if (_listCharters[count].name.Contains("Penelope").Equals(true))
                        {
                            charterName.text = "페넬로페";
                        }
                        break;
                    case "GetAlbum3":
                        if (_listCharters[count].name.Contains("Olivia").Equals(true))
                        {
                            charterName.text = "올리비아";
                        }
                        break;
                    case "Event2Cry":
                        if (_listCharters[count].name.Contains("Penelope").Equals(true))
                        {
                            charterName.text = "페넬로페";
                        }
                        break;
                    case "GetAlbum4Next":
                        switch (_listCharters[count].name)
                        {
                            case "Man3":
                                charterName.text = "시종";
                                break;
                            case "Olivia":
                                charterName.text = "올리비아";
                                break;
                            case "Logan":
                                charterName.text = "로건";
                                break;
                            case "Woman1":
                                charterName.text = "유디트";
                                break;
                        }
                        break;
                    case "Even3IanDrink":
                        if (_listCharters[count].name.Contains("Olivia").Equals(true))
                        {
                            charterName.text = "올리비아";
                        }
                        break;
                    case "Even3IanWait":
                        if (_listCharters[count].name.Contains("Logan").Equals(true))
                        {
                            charterName.text = "로건";
                        }
                        break;
                    case "Event3NoaNext":
                        switch (_listCharters[count].name)
                        {
                            case "Man3":
                                charterName.text = "시종";
                                break;
                            case "Olivia":
                                charterName.text = "올리비아";
                                break;
                            case "Logan":
                                charterName.text = "로건";
                                break;
                        }
                        break;
                    case "Event3NoaStay":
                        if (_listCharters[count].name.Contains("Olivia").Equals(true))
                        {
                            charterName.text = "올리비아";
                        }
                        break;
                    case "Event3NoaAvoid":
                        if (_listCharters[count].name.Contains("Olivia").Equals(true))
                        {
                            charterName.text = "올리비아";
                        }
                        else if (_listCharters[count].name.Contains("Logan").Equals(true))
                        {
                            charterName.text = "로건";
                        }
                        break;
                    case "Event3AustinParty":
                        if (_listCharters[count].name.Contains("Man3").Equals(true))
                        {
                            charterName.text = "시종";
                        }
                        break;
                    case "HappySadEndingNoaNextNext":
                        if (_listCharters[count].name.Contains("Man3").Equals(true))
                        {
                            charterName.text = "시종";
                        }
                        break;
                    case "HappySadEndingAustin":
                        if (_listCharters[count].name.Contains("Child2").Equals(true))
                        {
                            charterName.text = "어린아이";
                        }
                        break;
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
                                _randomCultivation = UnityEngine.Random.Range(0, 12);

                                switch (_randomCultivation)
                                {
                                    case 0:
                                        _listSentences[3] = "오늘은 사교계 인물들을 외우며 하루를 보냈다.";
                                        break;
                                    case 1:
                                        _listSentences[3] = "오늘은 집사와 함께 황실 예법을 공부하며 시간을 보냈다.";
                                        break;
                                    case 2:
                                        _listSentences[3] = "집사가 돌아간 뒤 수도에서 유명하다고 소문이 난 연극들을 밤 새 찾아보았다.";
                                        break;
                                    case 3:
                                        _listSentences[3] = "이후 피아노 실력을 기르기 위해 연습을 하다보니 하루가 지나있었다.";
                                        break;
                                    case 4:
                                        _listSentences[3] = "이후 해가 질 때까지 도서관에서 다양한 책을 읽으며 시간을 보냈다.";
                                        break;
                                    case 5:
                                        _listSentences[3] = "이후 발이 저릴 때까지 춤을 연습하고 나니 하루가 지나있었다.";
                                        break;
                                    case 6:
                                        _listSentences[3] = "이후 요즘 사교계에서 유행중인 노래와 작곡에 대해 공부하며 하루를 보냈다.";
                                        break;
                                    case 7:
                                        _listSentences[3] = "최근 사교계에서 유행하는 화풍에 대하여 공부하며 하루를 보냈다.";
                                        break;
                                    case 8:
                                        _listSentences[3] = "이후 살롱 마담에게 카탈로그를 부탁해 최신 유행하는 드레스를 구경하며 안목을 길렀다.";
                                        break;
                                    case 9:
                                        _listSentences[3] = "사교계 행사에 대비하여 예의 있게 욕하는 방법을 배우며 하루를 보냈다.";
                                        break;
                                    case 10:
                                        _listSentences[3] = "오늘은 집사와 함께 다도 예절을 익히며 시간을 보냈다.";
                                        break;
                                    case 11:
                                        _listSentences[3] = "오늘은 성공적인 백작가 운영을 위해 귀족들의 사업 수단을 분석하며 시간을 보냈다.";
                                        break;
                                }
                            }
                            break;
                        case "BuyPotion":
                            if (count == 4)
                            {
                                charterName.text = "";
                            }
                            break;
                        case "FirstIan":
                            switch (count)
                            {
                                case 4:
                                    Handheld.Vibrate();
                                    SettingUI.Instance.SettingSfxSound(hitAudio);
                                    break;
                                case 5:
                                    charterName.text = "";
                                    break;
                                case 8:
                                    charterName.text = "";
                                    SettingUI.Instance.SettingSfxSound(questionAudio);
                                    break;
                                case 12:
                                    charterName.text = "???";
                                    SettingUI.Instance.SettingSfxSound(sparkleAudio);
                                    break;
                                case 13:
                                    charterName.text = "";
                                    SettingUI.Instance.SettingSfxSound(sparkle5Audio);
                                    break;
                                case 21:
                                    charterName.text = "???";
                                    break;
                                case 23:
                                    SettingUI.Instance.SettingSfxSound(questionAudio);
                                    break;
                                case 25:
                                    charterName.text = "???";
                                    break;
                                case 28:
                                    charterName.text = "";
                                    break;
                                case 35:
                                    charterName.text = "";
                                    SettingUI.Instance.SettingSfxSound(find1Audio);
                                    break;
                                case 38:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "FirstNoa":
                            switch (count)
                            {
                                case 2:
                                    charterName.text = "";
                                    break;
                                case 4:
                                    SettingUI.Instance.SettingSfxSound(sparkle0Audio);
                                    charterName.text = "???";
                                    break;
                                case 7:
                                    charterName.text = "";
                                    break;
                                case 9:
                                    SettingUI.Instance.SettingSfxSound(sparkleAudio);
                                    charterName.text = "???";
                                    break;
                                case 10:
                                    SettingUI.Instance.SettingSfxSound(wonder1Audio);
                                    charterName.text = "";
                                    break;
                                case 14:
                                    SettingUI.Instance.SettingSfxSound(sparkle2Audio);
                                    break;
                                case 18:
                                    SettingUI.Instance.SettingSfxSound(find2Audio);
                                    break;
                                case 21:
                                    charterName.text = "";
                                    SettingUI.Instance.SettingSfxSound(surpriseAudio);
                                    break;
                                case 23:
                                    SettingUI.Instance.SettingSfxSound(sharpnessAudio);
                                    charterName.text = "";
                                    break;
                                case 31:
                                    SettingUI.Instance.SettingSfxSound(find1Audio);
                                    break;
                                case 35:
                                    charterName.text = "";
                                    break;
                                case 41:
                                    SettingUI.Instance.SettingSfxSound(steps2Audio);
                                    break;
                            }
                            break;
                        case "FirstAustin":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(dropAudio);
                                    break;
                                case 2:
                                    SettingUI.Instance.SettingSfxSound(sparkle0Audio);
                                    break;
                                case 5:
                                    charterName.text = "";
                                    break;
                                case 7:
                                    SettingUI.Instance.SettingSfxSound(steps3Audio);
                                    break;
                                case 17:
                                    charterName.text = "";
                                    break;
                                case 22:
                                    SettingUI.Instance.SettingSfxSound(sparkle2Audio);
                                    break;
                                case 24:
                                    SettingUI.Instance.SettingSfxSound(steps2Audio);
                                    break;
                                case 25:
                                    charterName.text = "";
                                    break;
                                case 28:
                                    charterName.text = "";
                                    SettingUI.Instance.SettingSfxSound(know1Audio);
                                    break;
                                case 30:
                                    charterName.text = "";
                                    break;
                            }   
                            break;
                        case "TownIan1":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(personAudio);
                                    break;
                                case 3:
                                    SettingUI.Instance.SettingSfxSound(sparkle2Audio);
                                    break;
                                case 9:
                                    SettingUI.Instance.SettingSfxSound(steps2Audio);
                                    break;
                            }   
                            break;
                        case "TownIan2":
                            switch (count)
                            {
                                case 2:
                                    charterName.text = "";
                                    break;
                                case 4:
                                    SettingUI.Instance.SettingSfxSound(sparkle0Audio);
                                    break;
                                case 5:
                                    SettingUI.Instance.SettingSfxSound(Exclamation2Audio);
                                    break;
                            }   
                            break;
                        case "TownIan2Fun":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(sparkle3Audio);
                                    break;
                            }   
                            break;
                        case "TownIan2Tiresome":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(find1Audio);
                                    break;
                            }   
                            break;
                        case "TownIan2Select":
                            switch (count)
                            {
                                case 5:
                                    charterName.text = "";
                                    SettingUI.Instance.SettingSfxSound(Exclamation3Audio);
                                    break;
                                case 8:
                                    SettingUI.Instance.SettingSfxSound(wonder2Audio);
                                    break;
                                case 10:
                                    SettingUI.Instance.SettingSfxSound(sigh2Audio);
                                    break;
                                case 22:
                                    SettingUI.Instance.SettingSfxSound(snapAudio);
                                    break;
                            }   
                            break;
                        case "TownIan3":
                            switch (count)
                            {
                                case 5:
                                    SettingUI.Instance.SettingSfxSound(breakAudio);
                                    Handheld.Vibrate();
                                    break;
                            }   
                            break;
                        case "TownIan3Ignore":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(Horse_Run2Audio);
                                    break;
                            }   
                            break;
                        case "TownIan4":
                            switch (count)
                            {
                                case 1:
                                    DailyRoutine.Instance.SettingPlaceImage(10);
                                    SettingUI.Instance.SettingSfxLoopSound(rainAudio);
                                    break;
                                case 4:
                                    charterName.text = "";
                                    break;
                                case 5:
                                    SettingUI.Instance.StopSfxLoopSound();
                                    break;
                                case 13:
                                    SettingUI.Instance.SettingSfxSound(rattleAudio);
                                    break;
                            }   
                            break;
                        case "TownNoa1":
                            switch (count)
                            {
                                case 1:
                                    charterName.text = "";
                                    break;
                                case 2:
                                    SettingUI.Instance.SettingSfxSound(HatefeelingAudio);
                                    break;
                                case 11:
                                    SettingUI.Instance.SettingBgmSound(dangerousAudio);
                                    break;
                            }   
                            break;
                        case "TownNoa1Mistake":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(anxiousfeelingAudio);
                                    break;
                            }
                            break;
                        case "TownNoa1Select":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(steps3Audio);
                                    break;
                            }
                            break;
                        case "TownNoa2":
                            switch (count)
                            {
                                case 2:
                                    charterName.text = "";
                                    break;
                            }   
                            break;
                        case "TownNoa2Next":
                            switch (count)
                            {
                                case 7:
                                    SettingUI.Instance.SettingSfxSound(find2Audio);
                                    break;
                                case 15:
                                    SettingUI.Instance.SettingSfxSound(wonder3Audio);
                                    break;
                                case 25:
                                    SettingUI.Instance.SettingSfxSound(absurdAudio);
                                    break;
                            }   
                            break;
                        case "TownNoa3":
                            switch (count)
                            {
                                case 2:
                                    SettingUI.Instance.SettingSfxSound(breakAudio);
                                    break;
                                case 6:
                                    charterName.text = "";
                                    break;
                            }   
                            break;
                        case "TownAustin1":
                            switch (count)
                            {
                                case 4:
                                    SettingUI.Instance.SettingSfxSound(questionAudio);
                                    break;
                                case 12:
                                    SettingUI.Instance.SettingSfxSound(storm2Audio);
                                    break;
                                case 19:
                                    SettingUI.Instance.SettingSfxSound(sparkle3Audio);
                                    break;
                                case 21:
                                    SettingUI.Instance.SettingSfxSound(find2Audio);
                                    break;
                            }   
                            break;
                        case "TownAustin2":
                            switch (count)
                            {
                                case 3:
                                    charterName.text = "";
                                    break;
                                case 7:
                                    SettingUI.Instance.SettingSfxSound(wristAudio);
                                    break;
                            }
                            break;
                        case "TownAustin2FireFestival":
                            switch (count)
                            {
                                case 5:
                                    SettingUI.Instance.SettingSfxSound(steps2Audio);
                                    break;
                                case 6:
                                    SettingUI.Instance.SettingSfxSound(fire2Audio);
                                    break;
                            }
                            break;
                        case "TownAustin3":
                            switch (count)
                            {
                                case 4:
                                    SettingUI.Instance.SettingSfxSound(Exclamation2Audio);
                                    break;
                                case 8:
                                    SettingUI.Instance.SettingSfxSound(rockAudio);
                                    break;
                                case 10: 
                                    SettingUI.Instance.SettingSfxSound(sparkle2Audio);
                                    break;
                            }
                            break;
                        case "TownAustin4":
                            switch (count)
                            {
                                case 1:
                                    charterName.text = "";
                                    break;
                            }   
                            break;
                        case "TownAustin4Next":
                            switch (count)
                            {
                                case 7:
                                    SettingUI.Instance.SettingBgmSound(musicBox2Audio);
                                    break;
                            }   
                            break;
                        case "RestaurantIan1":
                            switch (count)
                            {
                                case 6:
                                    SettingUI.Instance.SettingSfxSound(find2Audio);
                                    break;
                                case 7:
                                    SettingUI.Instance.SettingSfxSound(find1Audio);
                                    break;
                            }   
                            break;
                        case "RestaurantIan1QuestionEat":
                            switch (count)
                            {
                                case 2:
                                    SettingUI.Instance.SettingSfxSound(sparkle0Audio);
                                    break;
                            }   
                            break;
                        case "RestaurantIan2":
                            switch (count)
                            {
                                case 3:
                                    charterName.text = "";
                                    break;
                            }   
                            break;
                        case "RestaurantNoa1":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(personAudio);
                                    break;
                                case 5:
                                    SettingUI.Instance.SettingSfxSound(dressAudio);
                                    break;
                                case 7:
                                    SettingUI.Instance.SettingSfxSound(find1Audio);
                                    break;
                                case 10:
                                    charterName.text = "";
                                    break;
                            }   
                            break;
                        case "RestaurantNoa2":
                            switch (count)
                            {
                                case 1:
                                    charterName.text = "";
                                    break;
                                case 3:
                                    SettingUI.Instance.SettingSfxSound(sparkle2Audio);
                                    break;
                            }   
                            break;
                        case "RestaurantNoa2Good":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(TringAudio);
                                    break;
                            }   
                            break;
                        case "RestaurantNoa2Perfect":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(ExclamationAudio);
                                    break;
                            }   
                            break;
                        case "RestaurantNoa3":
                            switch (count)
                            {
                                case 12:
                                    charterName.text = "";
                                    break;
                                case 15:
                                    charterName.text = "";
                                    break;
                            }   
                            break;
                        case "RestaurantAustin1":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(find1Audio);
                                    break;
                                case 12:
                                    SettingUI.Instance.SettingSfxSound(questionAudio);
                                    break;
                            }   
                            break;
                        case "ParkIan1":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(questionAudio);
                                    break;
                                case 9:
                                    SettingUI.Instance.SettingSfxSound(wonder3Audio);
                                    break;
                            }
                            break;
                        case "ParkIan1Plants":
                            switch (count)
                            {
                                case 7:
                                    SettingUI.Instance.SettingSfxSound(steps2Audio);
                                    break;
                            }
                            break;
                        case "ParkIan1NightSky":
                            switch (count)
                            {
                                case 4:
                                    SettingUI.Instance.SettingSfxSound(Exclamation2Audio);
                                    break;
                            }
                            break;
                        case "ParkIan2":
                            switch (count)
                            {
                                case 8:
                                    SettingUI.Instance.SettingSfxSound(Exclamation2Audio);
                                    break;
                                case 17:
                                    SettingUI.Instance.SettingSfxSound(sparkleAudio);
                                    break;
                            }
                            break;
                        case "ParkIan3":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(footSteps2);
                                    break;
                                case 3:
                                    SettingUI.Instance.SettingSfxSound(horseAudio);
                                    break;
                            }   
                            break;
                        case "ParkIan3Exercise":
                            switch (count)
                            {
                                case 6:
                                    charterName.text = "";
                                    break;
                            }   
                            break;
                        case "ParkIan4":
                            switch (count)
                            {
                                case 1:
                                    charterName.text = "";
                                    break;
                                case 24:
                                    charterName.text = "";
                                    break;
                            }   
                            break;
                        case "ParkNoa1":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(catAudio);
                                    break;
                                case 3:
                                    SettingUI.Instance.SettingSfxSound(sparkle2Audio);
                                    break;
                                case 12:
                                    SettingUI.Instance.SettingSfxSound(wonder2Audio);
                                    break;
                            }   
                            break;
                        case "ParkNoa1Dog":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(find3Audio);
                                    break;
                            }   
                            break;
                        case "ParkNoa1Bird":
                            switch (count)
                            {
                                case 4:
                                    SettingUI.Instance.SettingSfxSound(questionAudio);
                                    break;
                            }   
                            break;
                        case "ParkNoa1Select":
                            switch (count)
                            {
                                case 4:
                                    SettingUI.Instance.SettingSfxSound(catAudio);
                                    break;
                            }   
                            break;
                        case "ParkNoa2":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(treeAudio);
                                    break;
                                case 4:
                                    SettingUI.Instance.SettingSfxSound(questionAudio);
                                    break;
                                case 7:
                                    Handheld.Vibrate();
                                    break;
                                case 10:
                                    SettingUI.Instance.SettingSfxSound(steps4Audio);
                                    break;
                                case 14:
                                    SettingUI.Instance.SettingSfxSound(shockAudio);
                                    break;
                                case 16:
                                    charterName.text = "";
                                    break;
                            }   
                            break;
                        case "ParkAustin1":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(questionAudio);
                                    break;
                                case 6:
                                    SettingUI.Instance.SettingSfxSound(find2Audio);
                                    break;
                            }   
                            break;
                        case "ParkAustin2":
                            switch (count)
                            {
                                case 2:
                                    SettingUI.Instance.SettingSfxSound(wonder1Audio);
                                    break;
                            }   
                            break;
                        case "ParkAustin2Chasing":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(Exclamation3Audio);
                                    break;
                                case 7:
                                    charterName.text = "";
                                    break;
                                case 10:
                                    SettingUI.Instance.SettingSfxSound(questionAudio);
                                    break;
                            }   
                            break;
                        case "BeachIan1":
                            switch (count)
                            {
                                case 2:
                                    SettingUI.Instance.StopSfxLoopSound();
                                    break;
                                case 4:
                                    SettingUI.Instance.SettingSfxSound(sparkle5Audio);
                                    break;
                                case 13:
                                    charterName.text = "";
                                    SettingUI.Instance.SettingSfxSound(wonder3Audio);
                                    break;
                            }
                            break;
                        case "BeachIan2":
                            switch (count)
                            {
                                case 2:
                                    SettingUI.Instance.SettingSfxLoopSound(wave2Audio);
                                    break;
                                case 4:
                                    SettingUI.Instance.StopSfxLoopSound();
                                    break;
                            }
                            break;
                        case "BeachNoa1":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(windAudio);
                                    break;
                                case 3:
                                    SettingUI.Instance.SettingSfxSound(waterAudio);
                                    break;
                                case 12:
                                   DailyRoutine.Instance.SettingPlaceImage(18);
                                   SettingUI.Instance.SettingSfxLoopSound(rainAudio);
                                   break;
                               case 14:
                                   SettingUI.Instance.StopSfxLoopSound();
                                   break;
                                case 15:
                                    SettingUI.Instance.SettingSfxSound(embarrassmentAudio);
                                    break;
                            }
                            break;
                        case "BeachNoa2Select":
                            switch (count)
                            {
                                case 10:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "BeachAustin1":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(wave2Audio);
                                    break;
                                case 3:
                                    SettingUI.Instance.SettingSfxSound(know1Audio);
                                    break;
                                case 15:
                                    SettingUI.Instance.SettingSfxSound(TringAudio);
                                    break;
                                case 16:
                                    Handheld.Vibrate();
                                    SettingUI.Instance.SettingSfxLoopSound(wave2Audio);
                                    break;
                                case 18:
                                    SettingUI.Instance.StopSfxLoopSound();
                                    break;
                                case 20:
                                    SettingUI.Instance.SettingSfxSound(know1Audio);
                                    break;
                                case 26:
                                    SettingUI.Instance.SettingSfxSound(Exclamation3Audio);
                                    break;
                            }
                            break;
                        case "BeachAustin2":
                            switch (count)
                            {
                                case 19:
                                    charterName.text = "";
                                    break;
                                case 23:
                                    SettingUI.Instance.SettingSfxLoopSound(wave2Audio);
                                    break;
                            }
                            break;
                        case "BeachAustin2Select":
                            switch (count)
                            {
                                case 3:
                                    SettingUI.Instance.SettingSfxSound(ppyong4Audio);
                                    break;
                            }
                            break;
                        case "GalleryIan1":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(find1Audio);
                                    break;
                                case 14:
                                    SettingUI.Instance.SettingSfxSound(sweatAudio);
                                    break;
                            }
                            break;
                        case "GalleryNoa1":
                            switch (count)
                            {
                                case 2:
                                    SettingUI.Instance.SettingSfxSound(sparkle0Audio);
                                    break;
                                case 9:
                                    SettingUI.Instance.SettingSfxSound(wonder3Audio);
                                    break;
                            }
                            break;
                        case "GalleryAustin1":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(stepsAudio);
                                    break;
                                case 4:
                                    SettingUI.Instance.SettingSfxSound(PatchingAudio);
                                    break;
                                case 8:
                                    charterName.text = "";
                                    break;
                                case 11:
                                    SettingUI.Instance.SettingSfxSound(sparkle0Audio);
                                    break;
                            }
                            break;
                        case "GalleryAustin1Select":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(dressAudio);
                                    break;
                                case 9:
                                    SettingUI.Instance.SettingSfxSound(steps3Audio);
                                    break;
                                case 11:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "HomeIan1":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(find1Audio);
                                    break;
                            }
                            break;
                        case "HomeIan1Talk":
                            switch (count)
                            {
                                case 2:
                                    SettingUI.Instance.SettingSfxSound(ExclamationAudio);
                                    break;
                                case 8:
                                    SettingUI.Instance.SettingSfxSound(embarrassmentAudio);
                                    charterName.text = "";
                                    break;
                                case 11:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "HomeIan1Curiosity":
                            switch (count)
                            {
                                case 3:
                                    SettingUI.Instance.SettingSfxSound(pongAudio);
                                    charterName.text = "";
                                    break;
                                case 9:
                                    SettingUI.Instance.SettingSfxSound(steps2Audio);
                                    break;
                            }
                            break;
                        case "HomeNoa1":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(ppyong2Audio);
                                    break;
                            }
                            break;
                        case "HomeNoa1Next":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(footSteps);
                                    break;
                            }
                            break;
                        case "HomeNoa1Cooperation":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(sharpeyesAudio);
                                    break;
                                case 3:
                                    SettingUI.Instance.SettingSfxSound(HatefeelingAudio);
                                    break;
                            }
                            break;
                        case "HomeNoa1Force":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(sharpeyesAudio);
                                    break;
                                case 7:
                                    SettingUI.Instance.SettingSfxSound(HatefeelingAudio);
                                    break;
                                case 9:
                                    SettingUI.Instance.SettingSfxSound(sigh2Audio);
                                    break;
                            }
                            break;
                        case "HomeAustin1":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(personAudio);
                                    break;
                                case 3:
                                    SettingUI.Instance.SettingSfxSound(chair1Audio);
                                    break;
                                case 4:
                                    charterName.text = "";
                                    break;
                                case 7:
                                    SettingUI.Instance.SettingSfxSound(ppyong1Audio);
                                    break;
                            }
                            break;
                        case "HomeAustin1PrayerTalk":
                            switch (count)
                            {
                                case 4:
                                    SettingUI.Instance.SettingSfxSound(steps2Audio);
                                    break;
                            }
                            break;
                        case "HomeAustin1NoPrayerTalk":
                            switch (count)
                            {
                                case 4:
                                    SettingUI.Instance.SettingSfxSound(steps2Audio);
                                    break;
                            }
                            break;
                        case "HomeAustin2":
                            switch (count)
                            {
                                case 2:
                                    charterName.text = "";
                                    break;
                                case 3:
                                    Handheld.Vibrate();
                                    break;
                                case 4:
                                    SettingUI.Instance.StopSfxLoopSound();
                                    break;
                            }
                            break;
                        case "HomeAustin2ThrowStone":
                            switch (count)
                            {
                                case 4:
                                    SettingUI.Instance.SettingBgmSound(square3Audio);
                                    break;
                                case 10:
                                    SettingUI.Instance.SettingSfxSound(steps2Audio);
                                    break;
                            }
                            break;
                        case "HomeAustin2CallAustin":
                            switch (count)
                            {
                                case 1:
                                    Handheld.Vibrate();
                                    break;
                                case 6:
                                    SettingUI.Instance.SettingSfxSound(breath3Audio);
                                    break;
                                case 8:
                                    SettingUI.Instance.SettingSfxSound(questionAudio);
                                    break;
                                case 11:
                                    SettingUI.Instance.SettingSfxSound(embarrassmentAudio);
                                    break;
                            }
                            break;
                        case "Event1":
                            switch (count)
                            {
                                case 2:
                                    SettingUI.Instance.SettingSfxSound(curtainAudio);
                                    break;
                            }
                            break;
                        case "Event2Next":
                            switch (count)
                            {
                                case 16:
                                    charterName.text = "";
                                    break;
                                case 23:
                                    charterName.text = "";
                                    break;
                                case 28:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Event2Select":
                            switch (count)
                            {
                                case 14:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Event2Rebut":
                            switch (count)
                            {
                                case 5:
                                    charterName.text = "";
                                    break;
                                case 15:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Event2HitCheek":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(cheekAudio);
                                    Handheld.Vibrate();
                                    break;
                            }
                            break;
                        case "Event2WineSpray":
                            switch (count)
                            {
                                case 12:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "GetAlbum3":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(magicAudio);
                                    break;
                                case 13:
                                    charterName.text = "";
                                    break;
                                case 17:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Event3Ian":
                            switch (count)
                            {
                                case 8:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "GetAlbum4":
                            switch (count)
                            {
                                case 3:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "GetAlbum4Next":
                            switch (count)
                            {
                                case 4:
                                    charterName.text = "";
                                    break;
                                case 19:
                                    charterName.text = "";
                                    break;
                                case 26:
                                    charterName.text = "";
                                    break;
                                case 38:
                                    charterName.text = "";
                                    break;
                                case 48:
                                    charterName.text = "???";
                                    break;
                                case 51:
                                    charterName.text = "???";
                                    break;
                                case 53:
                                    charterName.text = "???";
                                    break;
                                case 55:
                                    charterName.text = "";
                                    break;
                                case 63:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Even3IanDrink":
                            switch (count)
                            {
                                case 2:
                                    charterName.text = "";
                                    SettingUI.Instance.SettingSfxSound(endingGlass);
                                    Handheld.Vibrate();
                                    break;
                            }
                            break;
                        case "Even3IanWaitNext":
                            switch (count)
                            {
                                case 1:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Event3Noa":
                            switch (count)
                            {
                                case 5:
                                    Handheld.Vibrate();
                                    break;
                            }
                            break;
                        case "Event3NoaNext":
                            switch (count)
                            {
                                case 27:
                                    charterName.text = "";
                                    break;
                                case 37:
                                    charterName.text = "";
                                    break;
                                case 41:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Event3NoaStay":
                            switch (count)
                            {
                                case 5:
                                    SettingUI.Instance.SettingSfxSound(footSteps2);
                                    break;
                            }
                            break;
                        case "Event3NoaStayNext":
                            switch (count)
                            {
                                case 2:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Event3NoaAvoid":
                            switch (count)
                            {
                                case 1:
                                    Handheld.Vibrate();
                                    break;
                                case 6:
                                    SettingUI.Instance.SettingSfxSound(footSteps3);
                                    break;
                            }
                            break;
                        case "Event3AustinPartyNext":
                            switch (count)
                            {
                                case 19:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Event3AustinSelect":
                            switch (count)
                            {
                                case 5:
                                    Handheld.Vibrate();
                                    break;
                            }
                            break;
                        case "GetAlbum6":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(magicAudio);
                                    break;
                                case 3:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Event4Ian":
                            switch (count)
                            {
                                case 3:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Event4IanNext":
                            switch (count)
                            {
                                case 6:
                                    charterName.text = "";
                                    break;
                                case 12:
                                    charterName.text = "";
                                    break;
                                case 17:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        
                        case "Event4IanSelect":
                            switch (count)
                            {
                                case 10:
                                    charterName.text = "";
                                    break;
                                case 25:
                                    charterName.text = "";
                                    break;
                                case 59:
                                    charterName.text = "";
                                    break;
                                case 65:
                                    charterName.text = "";
                                    break;
                                case 69:
                                    charterName.text = "";
                                    break;
                                case 71:
                                    charterName.text = "";
                                    break;
                                case 75:
                                    charterName.text = "";
                                    break;
                                case 77:
                                    SettingUI.Instance.SettingSfxSound(heartBeat3Audio);
                                    break;
                                case 89:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "GetAlbum7":
                            switch (count)
                            {
                                case 7:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Event4Noa":
                            switch (count)
                            {
                                case 6:
                                    charterName.text = "";
                                    break;
                                case 10:
                                    charterName.text = "";
                                    break;
                                case 13:
                                    SettingUI.Instance.SettingSfxSound(curtainAudio);
                                    break;
                                case 17:
                                    SettingUI.Instance.SettingSfxSound(doorAudio);
                                    break;
                                case 24:
                                    charterName.text = "";
                                    break;
                                case 31:
                                    charterName.text = "";
                                    break;
                                case 34:
                                    Handheld.Vibrate();
                                    break;
                                case 36:
                                    charterName.text = "";
                                    break;
                                case 47:
                                    charterName.text = "";
                                    break;
                                case 69:
                                    charterName.text = "";
                                    break;
                                case 74:
                                    charterName.text = "";
                                    break;
                                case 95:
                                    charterName.text = "";
                                    break;
                                case 105:
                                    charterName.text = "";
                                    break;
                                case 142:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Event4NoaOkay":
                            switch (count)
                            {
                                case 1:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Event4NoaSelect":
                            switch (count)
                            {
                                case 16:
                                    charterName.text = "";
                                    break;
                                case 18:
                                    SettingUI.Instance.SettingSfxSound(cureAudio);
                                    break;
                            }
                            break;
                        case "Event4NoaGood":
                            switch (count)
                            {
                                case 1:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Event4Austin":
                            switch (count)
                            {
                                case 5:
                                    SettingUI.Instance.SettingSfxSound(littleBirdAudio);
                                    break;
                                case 6:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Event4AustinNext":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(summerNightBugAudio);
                                    break;
                                case 2:
                                    charterName.text = "";
                                    break;
                                case 9:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "GetAlbum9":
                            switch (count)
                            {
                                case 31:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Event4AustinJoke":
                            switch (count)
                            {
                                case 1:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Event4AustinSelect":
                            switch (count)
                            {
                                case 4:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Event4AustinThink":
                            switch (count)
                            {
                                case 2:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "Event4Dream":
                            switch (count)
                            {
                                case 5:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "HappyEndingIan":
                            switch (count)
                            {
                                case 6:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "HappyEndingIanNext":
                            switch (count)
                            {
                                case 22:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "HappyEndingIanNextNext":
                            switch (count)
                            {
                                case 6:
                                    charterName.text = "";
                                    break;
                                case 16:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "HappySadEndingIan":
                            switch (count)
                            {
                                case 21:
                                    SettingUI.Instance.SettingSfxSound(dropAudio);
                                    break;
                            }
                            break;
                        case "HappyEndingNoa":
                            switch (count)
                            {
                                case 7:
                                    charterName.text = "";
                                    break;
                                case 9:
                                    SettingUI.Instance.SettingSfxSound(doorAudio);
                                    break;
                                case 10:
                                    SettingUI.Instance.SettingSfxSound(footSteps);
                                    break;
                            }
                            break;
                        case "HappyEndingNoaNext":
                            switch (count)
                            {
                                case 3:
                                    SettingUI.Instance.SettingSfxSound(nockAudio);
                                    break;
                                case 35:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "GetAlbum11":
                            switch (count)
                            {
                                case 29:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "HappySadEndingNoaNext":
                            switch (count)
                            {
                                case 7:
                                    charterName.text = "";
                                    break;
                                case 11:
                                    charterName.text = "";
                                    break;
                                case 22:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "HappyEndingAustin":
                            switch (count)
                            {
                                case 7:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "HappyEndingAustinNext":
                            switch (count)
                            {
                                case 8:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "HappySadEndingAustin":
                            switch (count)
                            {
                                case 11:
                                    Handheld.Vibrate();
                                    break;
                            }
                            break;
                        case "NormalEndingNoa":
                            switch (count)
                            {
                                case 12:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "NormalEndingNoaNextNext":
                            switch (count)
                            {
                                case 10:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "NormalEndingNoaNextNextNextNext":
                            switch (count)
                            {
                                case 1:
                                    Handheld.Vibrate();
                                    break;
                            }
                            break;
                        case "NormalEndingAustinDialogue":
                            switch (count)
                            {
                                case 21:
                                    charterName.text = "";
                                    break;
                                case 23:
                                    charterName.text = "";
                                    break;
                                case 54:
                                    charterName.text = "";
                                    break;
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
                            case "FirstIan":
                                if (count != 26)
                                {
                                    yield return _yieldCharterChangeDelay;
                                    charterImage.sprite = _listCharters[count];
                                }
                                else
                                {
                                    SettingUI.Instance.SettingSfxSound(sparkle2Audio);
                                    charterName.text = "이안 칼릭스";
                                }
                                break;
                            case "FirstNoa":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "TownIan2":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "TownIan2Fun":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "TownIan2Select":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                if (count == 17)
                                {
                                    SettingUI.Instance.SettingSfxSound(questionAudio);
                                }
                                break;
                            case "TownIan4":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "TownNoa4Select":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "TownAustin1":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "TownAustin4Next":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "TownAustin4OutStore":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "RestaurantIan2":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "RestaurantNoa3Next":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "RestaurantAustin1":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                if (count == 4)
                                {
                                    SettingUI.Instance.SettingSfxSound(TringAudio);
                                }
                                break;
                            case "ParkIan1":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "ParkIan1Plants":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "ParkIan3":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "ParkIan3Exercise":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "ParkIan3Walk":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "ParkIan4":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "ParkNoa1Select":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "ParkAustin1":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "ParkAustin2Chasing":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "BeachIan1":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "BeachIan2":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "BeachNoa1":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "BeachAustin2":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "BeachAustin2OpenEye":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "GalleryIan1":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "GalleryNoa1":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "GalleryNoa2":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "GalleryAustin2":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "HomeIan1Talk":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "HomeIan1Curiosity":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "HomeNoa1Cooperation":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "HomeAustin1PrayerTalk":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "HomeAustin1NoPrayerTalk":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Event1":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                if (count == 6)
                                {
                                    SettingUI.Instance.SettingSfxSound(questionAudio);
                                }
                                break;
                            case "Event2":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Event2WineSpray":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Event2Select":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Event2Cry":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Event3Ian":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Event3IanNext":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "GetAlbum4Next":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Even3IanWait":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Event3Noa":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "GetAlbum5":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Event3AustinNext":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Event3AustinPartyNext":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Event3AustinBelieve":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Event3AustinWind":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Event3AustinSelect":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "GetAlbum6":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Event4IanNext":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Event4IanSelect":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Event4IanBright":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "GetAlbum7":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Event4Noa":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Event4AustinNext":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "GetAlbum9":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Event4AustinThink":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "Event4AustinSelect":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "HappyEndingIanNextNext":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "HappySadEndingIan":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "HappyEndingNoaNext":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "GetAlbum11Next":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "HappySadEndingNoa":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "HappySadEndingNoaNext":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "GetAlbum14":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "HappyEndingAustinNext":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "GetAlbum12":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "HappySadEndingAustin":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "NormalEndingIan":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "NormalEndingIanNext":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "NormalEndingNoaNext":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "NormalEndingAustinDialogue":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
                                break;
                            case "NormalEndingAustinNext":
                                yield return _yieldCharterChangeDelay;
                                charterImage.sprite = _listCharters[count];
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

            switch (situationCase)
            {
                case "TownAustin2":
                    SettingUI.Instance.SettingSfxSound(fireAudio);
                    break;
                case "ParkAustin2":
                    SettingUI.Instance.SettingSfxSound(littleBirdAudio);
                    break;
                case "BeachIan1":
                    SettingUI.Instance.SettingSfxLoopSound(wave2Audio);
                    break;
                case "HomeAustin2":
                    SettingUI.Instance.SettingSfxLoopSound(peopleAudio);
                    break;
                case "HomeAustin2ThrowStone":
                    Handheld.Vibrate();
                    SettingUI.Instance.SettingSfxSound(coinAudio);
                    break;
                case "Event2":
                    dialogueWindow.sprite = DialogueTxt.Instance.event2Dialogue.dialogueWindows[0];
                    SettingTxtBox();
                    break;
            }
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

    public void SettingTxtBox()
    {
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
            
            // 오디오 호출
            SettingUI.Instance.SettingSfxSound(arrowUIAudio);
            
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
                textDelay = 0.015f;
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
    
    private IEnumerator FadeImageAlpha()
    {
        fadeImage.transform.localPosition = new Vector3(540, 0, 0);
        fadeImage.color = new Color(1, 1, 1, 0);
        
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
        
        LobbyManager.Instance.SettingBackImage(2);
        yield return _yieldViewDelay;
        
        while (alpha.a > 0)
        {
            _time += Time.deltaTime / _currentFadeTime;
            
            alpha.a = Mathf.Lerp(1, 0, _time);
            
            fadeImage.color = alpha;
            
            yield return null;
        }
        
        SettingUI.Instance.SettingBgmSound(tutorialBgm);
        LobbyManager.Instance.Event2Select();
        
        //
        fadeImage.gameObject.SetActive(false);

        yield return null;
    }

    private IEnumerator FadeRightFlow()
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.transform.localPosition = new Vector3(540, 0, 0);
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
    
    private IEnumerator FadeRightTown(int placeNum, int placeBgmNum, Dialogue dialogue, string situationCaseName, int countNum, bool changeAudio)
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.transform.localPosition = new Vector3(540, 0, 0);
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

        DailyRoutine.Instance.SettingPlaceImage(placeNum);
        DailyRoutine.Instance.SettingSituationCaseDialogue(placeBgmNum, dialogue,
            situationCaseName, countNum, changeAudio);

        while (fadeImage.rectTransform.localPosition.x > -1550f)
        {
            _time += Time.deltaTime * 0.1f;

            fadeImage.rectTransform.localPosition = 
                Vector3.Lerp(fadeImage.rectTransform.localPosition, _fadeImageMovePos, _time);

            // openingUIGo.SetActive(false);

            // ChangeSettingImage();
            
            // tutorialUIGo.SetActive(true);

            yield return null;
        }

        if (changeAudio.Equals(true))
        {
            DailyRoutine.Instance.SettingPlaceBgmSound();
        }
        
        // SettingUI.Instance.SettingBgmSound(DailyRoutine.Instance.placeBgmClips[7]);
        DailyRoutine.Instance.SettingPlaceDialogue();
        
        // 다이얼 로그 호출
        
        fadeImage.gameObject.SetActive(false);

        // ShowTutorial(0);
        
        // while (alpha.a > 0)
        // {
        //     _time += Time.deltaTime / _currentFadeTime;
        //     
        //     alpha.a = Mathf.Lerp(0, 1, _time);
        //     
        //     fadeImage.color = alpha;
        //     
        //     yield return null;
        // }
        
        yield return null;
    }
    
    private IEnumerator FadeImage()
    {
        for (int i = 0; i < fadeBlurImage.Length; i++)
        {
            fadeBlurImage[i].color = new Color(1, 1, 1, 0);
            
            fadeBlurImage[i].transform.localPosition = new Vector3(0, 0, 0);
            
            fadeBlurImage[i].gameObject.SetActive(true);
        }

        _time = 0f;
        
        Color alpha = fadeBlurImage[0].color;
        
        while (alpha.a < 1f)
        {
            _time += Time.deltaTime / _currentFadeTime;
            
            alpha.a = Mathf.Lerp(0, 1, _time);
            
            fadeBlurImage[0].color = alpha;
            fadeBlurImage[1].color = alpha;
             
            yield return null;
        }
        _time = 0f;
        
        whiteFadeImage.color = new Color(1, 1, 1, 1);
        whiteFadeImage.gameObject.SetActive(true);

        yield return _yieldAnimDelay;
        
        SettingUI.Instance.SettingSfxSound(sceneChangeAudio);

        while (fadeBlurImage[0].rectTransform.localPosition.x > -1040f)
        {
            _time += Time.deltaTime * 0.1f;

            fadeBlurImage[0].rectTransform.localPosition = 
                Vector3.Lerp(fadeBlurImage[0].rectTransform.localPosition, new Vector3(-1050, 0, 0), _time);
            
            fadeBlurImage[1].rectTransform.localPosition = 
                Vector3.Lerp(fadeBlurImage[1].rectTransform.localPosition, new Vector3(1050, 0, 0), _time);

            yield return null;
        }

        // 코루틴 호출
        StartCoroutine(WhiteFadeImage());

        yield return null;
    }
    
    private IEnumerator WhiteFadeImage()
    {
        LobbyManager.Instance.SettingBackImage(1);
        
        LobbyManager.Instance.SettingBaseBackImage(DialogueTxt.Instance.event2NextDialogue);
        
        _time = 0f;
        
        Color alpha = whiteFadeImage.color;

        while (alpha.a > 0)
        {
            _time += Time.deltaTime / _currentFadeTime;
            
            alpha.a = Mathf.Lerp(1, 0, _time);
            
            whiteFadeImage.color = alpha;

            yield return null;
        }

        SettingUI.Instance.SettingBgmSound(debut1Audio);
        LobbyManager.Instance.Event2Next();
        SettingTxtBox();
        
        whiteFadeImage.gameObject.SetActive(false);

        yield return null;
    }

    private IEnumerator FadeInfo(int num)
    {
        SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
        
        infoImage.color = new Color(1, 1, 1, 0);
        fadeImage.color = new Color(1, 1, 1, 0);

        infoImage.sprite = infoSprite[num];
        
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

        AddDate();
        SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
        StartFadeData();

        // 이벤트 아님
        if (LobbyManager.Instance.date % 7 != 0)
        {
            LobbyManager.Instance.ResetLobbyUI();
        }
        
        switch (num)
        {
            case 0:
                CheckNowHeart100(0, addNowHeart[_randomCultivation]);
                LobbyManager.Instance.coin += addCoin[_randomCultivation];
                LobbyManager.Instance.SettingCoin();
                break;
            case 1:
                CheckNowHeart100(1, 5);
                break;
            case 2:
                CheckNowHeart100(2, 5);
                break;
            case 3:
                CheckNowHeart100(3, 5);
                break;
        }

        // 이벤트 실행
        if (LobbyManager.Instance.date % 7 == 0)
        {
            LobbyManager.Instance.ResetLobby(1);
        }
        // 이벤트 실행 아님
        else
        {
            LobbyManager.Instance.ResetLobby(0);
        }

        yield return null;
    }
    
    private IEnumerator FadeInfoEvent(int reputationNum, int plusPlayerHeart, int nowHeartNum, int addHeart)
    {
        SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
        
        infoImage.color = new Color(1, 1, 1, 0);
        reputationImage.color = new Color(1, 1, 1, 0);
        fadeImage.color = new Color(1, 1, 1, 0);

        infoImage.sprite = infoSprite[reputationNum];

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

        AddDate();
        SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
        StartCoroutine(FadeReputation(nowHeartNum, addHeart));

        if (LobbyManager.Instance.date - 29 != 0)
        {
            LobbyManager.Instance.ResetLobbyUI();
        }
        
        switch (reputationNum)
        {
            case 0:
                CheckNowHeart100(0, plusPlayerHeart);
                break;
            case 5:
                CheckNowHeartZero(0, plusPlayerHeart);
                break;
        }
        
        LobbyManager.Instance.ResetLobby(0);

        yield return null;
    }

    public void SettingEnding()
    {
        choiceEndingUIGo.SetActive(false);
        
        switch (endingWhoNum)
        {
            // 평판 54보다 작음
            case 0:
                // 랜덤 실행
                if (LobbyManager.Instance.nowHeart[1] >= 45 || LobbyManager.Instance.nowHeart[2] >= 45 ||
                    LobbyManager.Instance.nowHeart[3] >= 45)
                {
                    if (LobbyManager.Instance.nowHeart[1] > LobbyManager.Instance.nowHeart[2])
                    {
                        if (LobbyManager.Instance.nowHeart[1] > LobbyManager.Instance.nowHeart[3])
                        {
                            LobbyManager.Instance.SettingBackImage(0);
                            _endongNum = 3;
                        }
                        else if (LobbyManager.Instance.nowHeart[1] == LobbyManager.Instance.nowHeart[3])
                        {
                            int ran = UnityEngine.Random.Range(0, 2);

                            if (ran == 0)
                            {
                                LobbyManager.Instance.SettingBackImage(0);
                                _endongNum = 3;
                            }
                            else if (ran == 1)
                            {
                                LobbyManager.Instance.SettingBackImage(19);
                                _endongNum = 9;
                            }
                        }
                        else if (LobbyManager.Instance.nowHeart[1] < LobbyManager.Instance.nowHeart[3])
                        {
                            LobbyManager.Instance.SettingBackImage(19);
                            _endongNum = 9;
                        }
                    }
                    else if (LobbyManager.Instance.nowHeart[1] < LobbyManager.Instance.nowHeart[2])
                    {
                        if (LobbyManager.Instance.nowHeart[2] > LobbyManager.Instance.nowHeart[3])
                        {
                            LobbyManager.Instance.SettingBackImage(0);
                            _endongNum = 6;
                        }
                        else if (LobbyManager.Instance.nowHeart[2] == LobbyManager.Instance.nowHeart[3])
                        {
                            int ran = UnityEngine.Random.Range(0, 2);

                            if (ran == 0)
                            {
                                LobbyManager.Instance.SettingBackImage(0);
                                _endongNum = 6;
                            }
                            else if (ran == 1)
                            {
                                LobbyManager.Instance.SettingBackImage(19);
                                _endongNum = 9;
                            }
                        }
                        else if (LobbyManager.Instance.nowHeart[2] < LobbyManager.Instance.nowHeart[3])
                        {
                            LobbyManager.Instance.SettingBackImage(19);
                            _endongNum = 9;
                        }
                    }
                    else if (LobbyManager.Instance.nowHeart[1] == LobbyManager.Instance.nowHeart[2])
                    {
                        if (LobbyManager.Instance.nowHeart[2] == LobbyManager.Instance.nowHeart[3])
                        {
                            int ran = UnityEngine.Random.Range(0, 3);

                            if (ran == 0)
                            {
                                LobbyManager.Instance.SettingBackImage(0);
                                _endongNum = 3;
                            }
                            else if (ran == 1)
                            {
                                LobbyManager.Instance.SettingBackImage(0);
                                _endongNum = 6;
                            }
                            else if (ran == 2)
                            {
                                LobbyManager.Instance.SettingBackImage(19);
                                _endongNum = 9;
                            }
                        }
                        else if (LobbyManager.Instance.nowHeart[2] < LobbyManager.Instance.nowHeart[3])
                        {
                            LobbyManager.Instance.SettingBackImage(19);
                            _endongNum = 9;
                        }
                        else if (LobbyManager.Instance.nowHeart[2] > LobbyManager.Instance.nowHeart[3])
                        {
                            int ran = UnityEngine.Random.Range(0, 2);

                            if (ran == 0)
                            {
                                LobbyManager.Instance.SettingBackImage(0);
                                _endongNum = 3;
                            }
                            else if (ran == 1)
                            {
                                LobbyManager.Instance.SettingBackImage(0);
                                _endongNum = 6;
                            }
                        }
                    }
                }
                else
                {
                    LobbyManager.Instance.SettingBackImage(0);
                    _endongNum = 10;
                }
                break;
            case 1:
                if (LobbyManager.Instance.nowHeart[1] >= 45)
                {
                    LobbyManager.Instance.SettingBackImage(10);
                    _endongNum = 1;
                }
                else
                {
                    LobbyManager.Instance.SettingBackImage(0);
                    _endongNum = 2;
                }
                break;
            case 2:
                if (LobbyManager.Instance.nowHeart[2] >= 45)
                {
                    LobbyManager.Instance.SettingBackImage(0);
                    _endongNum = 4;
                }
                else
                {
                    LobbyManager.Instance.SettingBackImage(0);
                    _endongNum = 5;
                }
                break;
            case 3:
                if (LobbyManager.Instance.nowHeart[3] >= 45)
                {
                    LobbyManager.Instance.SettingBackImage(0);
                    _endongNum = 7;
                }
                else
                {
                    LobbyManager.Instance.SettingBackImage(17);
                    _endongNum = 8;
                }
                break;
        }
    }

    private void CheckNowHeartZero(int nowHeartNum, int minusNUm)
    {
        LobbyManager.Instance.nowHeart[nowHeartNum] -= minusNUm;

        if (LobbyManager.Instance.nowHeart[nowHeartNum] < 0)
        {
            LobbyManager.Instance.nowHeart[nowHeartNum] = 0;
        }
    }
    
    private void CheckNowHeart100(int nowHeartNum, int minusNUm)
    {
        LobbyManager.Instance.nowHeart[nowHeartNum] += minusNUm;

        if (LobbyManager.Instance.nowHeart[nowHeartNum] > 100)
        {
            LobbyManager.Instance.nowHeart[nowHeartNum] = 100;
        }
    }
    
    private IEnumerator FadeReputation(int nowHeartNum, int addHeart)
    {
        reputationImage.sprite = infoSprite[nowHeartNum];
        
        reputationImage.gameObject.SetActive(true);

        _time = 0f;
        
        Color alpha = reputationImage.color;
        
        while (alpha.a < 1f)
        {
            _time += Time.deltaTime / _currentFadeTime;
            
            alpha.a = Mathf.Lerp(0, 1, _time);
            
            reputationImage.color = alpha;
            
            yield return null;
        }
        _time = 0f;
        
        yield return _yieldAnimDelay;
        
        SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
        StartFadeData();
        
        switch (nowHeartNum)
        {
            case 1:
                CheckNowHeart100(1, addHeart);
                break;
            case 2:
                CheckNowHeart100(2, addHeart);
                break;
            case 3:
                CheckNowHeart100(3, addHeart);
                break;
            case 6:
                CheckNowHeart100(1, addHeart);
                CheckNowHeart100(2, addHeart);
                CheckNowHeart100(3, addHeart);
                break;
            case 7:
                CheckNowHeartZero(1, addHeart);
                CheckNowHeartZero(2, addHeart);
                CheckNowHeartZero(3, addHeart);
                break;
            case 9:
                CheckNowHeartZero(1, addHeart);
                break;
            case 10:
                CheckNowHeartZero(2, addHeart);
                break;
            case 11:
                CheckNowHeartZero(3, addHeart);
                break;
        }
        
        SaveData();
        
        
        if (LobbyManager.Instance.date - 29 == 0)
        {
            SettingEnding();
        }
        
        yield return null;
    }
    
    private IEnumerator FadeDate(GameObject go)
    {
        dataImage.gameObject.SetActive(true);

        if (LobbyManager.Instance.date - 29 == 0)
        {
            SettingEnding();
            
            switch (_endongNum)
            {
                case 1:
                    LobbyManager.Instance.ResetLobby(1);
                    // LobbyManager.Instance.ShowLobbyTxtBoxLineGo();
                    SettingUI.Instance.SettingBgmSound(ian1Audio);
                    LobbyManager.Instance.SettingBaseBackImage(DialogueTxt.Instance.happyEndingIanDialogue);
                    break;
                case 2:
                    LobbyManager.Instance.ResetLobby(1);
                    SettingUI.Instance.SettingBgmSound(ian2Audio);
                    LobbyManager.Instance.SettingBaseBackImage(DialogueTxt.Instance.happySadEndingIanDialogue);
                    break;
                case 3:
                    LobbyManager.Instance.ResetLobby(1);
                    SettingUI.Instance.SettingBgmSound(ian3Audio);
                    LobbyManager.Instance.SettingBaseBackImage(DialogueTxt.Instance.normalEndingIanDialogue);
                    break;
                case 4:
                    LobbyManager.Instance.ResetLobby(1);
                    SettingUI.Instance.SettingBgmSound(noa1Audio);
                    LobbyManager.Instance.SettingBaseBackImage(DialogueTxt.Instance.happyEndingNoaDialogue);
                    break;
                case 5:
                    LobbyManager.Instance.ResetLobby(1);
                    SettingUI.Instance.SettingBgmSound(noa2Audio);
                    LobbyManager.Instance.SettingBaseBackImage(DialogueTxt.Instance.happySadEndingNoaDialogue);
                    break;
                case 6:
                    LobbyManager.Instance.ResetLobby(1);
                    SettingUI.Instance.SettingBgmSound(noa3Audio);
                    LobbyManager.Instance.SettingBaseBackImage(DialogueTxt.Instance.normalEndingNoaDialogue);
                    break;
                case 7:
                    LobbyManager.Instance.ResetLobby(1);
                    SettingUI.Instance.SettingBgmSound(austin1Audio);
                    LobbyManager.Instance.SettingBaseBackImage(DialogueTxt.Instance.happyEndingAustinDialogue);
                    break;
                case 8:
                    LobbyManager.Instance.ResetLobby(1);
                    SettingUI.Instance.SettingBgmSound(austin2Audio);
                    LobbyManager.Instance.SettingBaseBackImage(DialogueTxt.Instance.happySadEndingAustinDialogue);
                    break;
                case 9:
                    LobbyManager.Instance.ResetLobby(1);
                    SettingUI.Instance.SettingBgmSound(austin3Audio);
                    LobbyManager.Instance.SettingBaseBackImage(DialogueTxt.Instance.normalEndingAustinDialogue);
                    break;
                case 10:
                    LobbyManager.Instance.ResetLobby(1);
                    SettingUI.Instance.SettingBgmSound(valetAudio);
                    LobbyManager.Instance.SettingBaseBackImage(DialogueTxt.Instance.badEndingDialogue);
                    break;
            }
            
            LobbyManager.Instance.HideLobbyUI();
        }
        else if (LobbyManager.Instance.date - 28 == 0)
        {
            switch (ChoiceManager.Instance.event4WhoNum)
            {
                // 꽃
                case 1:
                    if (LobbyManager.Instance.nowHeart[1] >= 35)
                    {
                        // 이벤트4 이안 실행
                        SettingUI.Instance.SettingBgmSound(ianAudio);
                        LobbyManager.Instance.SettingBackImage(2);
                        event4WhoNum = 1;
                    }
                    else
                    {
                        if (LobbyManager.Instance.nowHeart[2] == LobbyManager.Instance.nowHeart[3])
                        {
                            int r = UnityEngine.Random.Range(0, 2);

                            if (r == 0)
                            {
                                // 이벤트4 노아 실행
                                SettingUI.Instance.SettingBgmSound(noaAudio);
                                LobbyManager.Instance.SettingBackImage(2);
                                event4WhoNum = 2;
                            }
                            else if (r == 1)
                            {
                                // 이벤트4 아스틴 실행
                                SettingUI.Instance.SettingBgmSound(austinAudio);
                                LobbyManager.Instance.SettingBackImage(2);
                                event4WhoNum = 3;
                            }
                        }
                        else
                        {
                            if (LobbyManager.Instance.nowHeart[2] > LobbyManager.Instance.nowHeart[3])
                            {
                                // 이벤트4 노아 실행
                                SettingUI.Instance.SettingBgmSound(noaAudio);
                                LobbyManager.Instance.SettingBackImage(2);
                                event4WhoNum = 2;
                            }
                            else
                            {
                                // 이벤트4 아스틴 실행
                                SettingUI.Instance.SettingBgmSound(austinAudio);
                                LobbyManager.Instance.SettingBackImage(2);
                                event4WhoNum = 3;
                            }
                        }
                    }
                    break; 
                case 2:
                    if (LobbyManager.Instance.nowHeart[2] >= 35)
                    {
                        // 이벤트4 노아 실행
                        SettingUI.Instance.SettingBgmSound(noaAudio);
                        LobbyManager.Instance.SettingBackImage(2);
                        event4WhoNum = 2;
                    }
                    else
                    {
                        if (LobbyManager.Instance.nowHeart[1] == LobbyManager.Instance.nowHeart[3])
                        {
                            int r = UnityEngine.Random.Range(0, 2);

                            if (r == 0)
                            {
                                // 이벤트4 이안 실행
                                SettingUI.Instance.SettingBgmSound(ianAudio);
                                LobbyManager.Instance.SettingBackImage(2);
                                event4WhoNum = 1;
                            }
                            else if (r == 1)
                            {
                                // 이벤트4 아스틴 실행
                                SettingUI.Instance.SettingBgmSound(austinAudio);
                                LobbyManager.Instance.SettingBackImage(2);
                                event4WhoNum = 3;
                            }
                        }
                        else
                        {
                            if (LobbyManager.Instance.nowHeart[1] > LobbyManager.Instance.nowHeart[3])
                            {
                                // 이벤트4 이안 실행
                                SettingUI.Instance.SettingBgmSound(ianAudio);
                                LobbyManager.Instance.SettingBackImage(2);
                                event4WhoNum = 1;
                            }
                            else
                            {
                                // 이벤트4 아스틴 실행
                                SettingUI.Instance.SettingBgmSound(austinAudio);
                                LobbyManager.Instance.SettingBackImage(2);
                                event4WhoNum = 3;
                            }
                        }
                    }
                    break;
                case 3:
                    if (LobbyManager.Instance.nowHeart[3] >= 35)
                    {
                        // 이벤트4 아스틴 실행
                        SettingUI.Instance.SettingBgmSound(austinAudio);
                        LobbyManager.Instance.SettingBackImage(2);
                        event4WhoNum = 3;
                    }
                    else
                    {
                        if (LobbyManager.Instance.nowHeart[1] == LobbyManager.Instance.nowHeart[2])
                        {
                            int r = UnityEngine.Random.Range(0, 2);

                            if (r == 0)
                            {
                                // 이벤트4 이안 실행
                                SettingUI.Instance.SettingBgmSound(ianAudio);
                                LobbyManager.Instance.SettingBackImage(2);
                                event4WhoNum = 1;
                            }
                            else if (r == 1)
                            {
                                // 이벤트4 노아 실행
                                SettingUI.Instance.SettingBgmSound(noaAudio);
                                LobbyManager.Instance.SettingBackImage(2);
                                event4WhoNum = 2;
                            }
                        }
                        else
                        {
                            if (LobbyManager.Instance.nowHeart[1] > LobbyManager.Instance.nowHeart[2])
                            {
                                // 이벤트4 이안 실행
                                SettingUI.Instance.SettingBgmSound(ianAudio);
                                LobbyManager.Instance.SettingBackImage(2);
                                event4WhoNum = 1;
                            }
                            else
                            {
                                // 이벤트4 노아 실행
                                SettingUI.Instance.SettingBgmSound(noaAudio);
                                LobbyManager.Instance.SettingBackImage(2);
                                event4WhoNum = 2;
                            }
                        }
                    }
                    break;
            }
        } 
        else if (LobbyManager.Instance.date - 21 == 0)
        {
            switch (ChoiceManager.Instance.event3WhoNum)
            {
                // 이안 
                case 1:
                    SettingUI.Instance.SettingBgmSound(party1Audio);
                    LobbyManager.Instance.SettingBackImage(0);
                    break;
                // 노아
                case 2:
                    SettingUI.Instance.SettingBgmSound(park1Audio);
                    LobbyManager.Instance.SettingBackImage(0);
                    break;
                // 아스틴
                case 3:
                    SettingUI.Instance.SettingBgmSound(sweatTeaAudio);
                    LobbyManager.Instance.SettingBackImage(0);
                    break;
            }
        }
        // 이벤트 2실행
        else if (LobbyManager.Instance.date - 14 == 0)
        {
            SettingUI.Instance.SettingBgmSound(readyAudio);
            LobbyManager.Instance.SettingBackImage(0);
        }
        // 이벤트 1실행
        else
        {
            SettingUI.Instance.SettingBgmSound(tutorialBgm);
            LobbyManager.Instance.SettingBackImage(0);
        }
        
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
            placeUIGo.SetActive(false);
            
            lobbyUIGo.SetActive(true);
            infoImage.gameObject.SetActive(false);
            reputationImage.gameObject.SetActive(false);

            yield return null;
        }
        
        WorldManager.Instance.ResetTxtBox();
        
        // 이벤트 1실행
        if (LobbyManager.Instance.date - 7 == 0)
        {
            LobbyManager.Instance.Event1();
        }
        // 이벤트 2실행
        else if (LobbyManager.Instance.date - 14 == 0)
        {
            LobbyManager.Instance.Event2();
        }
        // 이벤트 3실행
        else if (LobbyManager.Instance.date - 21 == 0)
        {
            switch (ChoiceManager.Instance.event3WhoNum)
            {
                // 이안 
                case 1:
                    // 이벤트 호출
                    LobbyManager.Instance.Event3Ian();
                    break;
                // 노아
                case 2:
                    // 이벤트 호출
                    LobbyManager.Instance.Event3Noa();
                    break;
                // 아스틴 
                case 3:
                    // 이벤트 호출
                    LobbyManager.Instance.Event3Austin();
                    break;
            }
        }
        // 이벤트 4실행
        else if (LobbyManager.Instance.date - 28 == 0)
        {
            switch (event4WhoNum)
            {
                case 1:
                    LobbyManager.Instance.Event4Ian();
                    break;
                case 2:
                    LobbyManager.Instance.Event4Noa();
                    break;
                case 3:
                    LobbyManager.Instance.Event4Austin();
                    break;
            }
        }
        else if (LobbyManager.Instance.date - 29 == 0)
        {
            switch (_endongNum)
            {
                case 1:
                    LobbyManager.Instance.HappyEndingIan();
                    break;
                case 2:
                    LobbyManager.Instance.HappySadEndingIan();
                    break;
                case 3:
                    LobbyManager.Instance.NormalEndingIan();
                    break;
                case 4:
                    LobbyManager.Instance.HappyEndingNoa();
                    break;
                case 5:
                    LobbyManager.Instance.HappySadEndingNoa();
                    break;
                case 6:
                    LobbyManager.Instance.NormalEndingNoa();
                    break;
                case 7:
                    LobbyManager.Instance.HappyEndingAustin();
                    break;
                case 8:
                    LobbyManager.Instance.HappySadEndingAustin();
                    break;
                case 9:
                    LobbyManager.Instance.NormalEndingAustinDialogue();
                    break;
                case 10:
                    LobbyManager.Instance.BadEnding();
                    break;
            }
            
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

    private void SaveData()
    {
        // 이안 첫만남 저장
        if (DailyRoutine.Instance.isFirst[0].Equals(true))
        {
            PlayerPrefs.SetInt("IanFirst", 1);
        }
        
        if (DailyRoutine.Instance.isFirst[1].Equals(true))
        {
            PlayerPrefs.SetInt("NoaFirst", 1);
        }
        
        if (DailyRoutine.Instance.isFirst[2].Equals(true))
        {
            PlayerPrefs.SetInt("AustinFirst", 1);
        }

        // 이안 평판 확인 저장
        if (LobbyManager.Instance.isShowHeart[1].Equals(true))
        {
            PlayerPrefs.SetInt("IanShowHeart", 1);
        }
        
        if (LobbyManager.Instance.isShowHeart[2].Equals(true))
        {
            PlayerPrefs.SetInt("NoaShowHeart", 1);
        }
        
        if (LobbyManager.Instance.isShowHeart[3].Equals(true))
        {
            PlayerPrefs.SetInt("AustinShowHeart", 1);
        }

        for (int i = 0; i < LobbyManager.Instance.isAlbum.Length; i++)
        {
            if (LobbyManager.Instance.isAlbum[i].Equals(true))
            {
                // 0 ~ 18;
                PlayerPrefs.SetInt(i.ToString(), 1);
            }
        }
        
        PlayerPrefs.SetFloat("PlayerHeart", LobbyManager.Instance.nowHeart[0]);
        PlayerPrefs.SetFloat("IanHeart", LobbyManager.Instance.nowHeart[1]);
        PlayerPrefs.SetFloat("NoaHeart", LobbyManager.Instance.nowHeart[2]);
        PlayerPrefs.SetFloat("AustinHeart", LobbyManager.Instance.nowHeart[3]);
        
        LobbyManager.Instance.isBuy = false;
        PlayerPrefs.SetInt("Date", LobbyManager.Instance.date);
        PlayerPrefs.SetInt("Coin", LobbyManager.Instance.coin);
        PlayerPrefs.SetInt("Event3", ChoiceManager.Instance.event3WhoNum);
        PlayerPrefs.SetInt("Event4", ChoiceManager.Instance.event4WhoNum);
        PlayerPrefs.SetInt("Ending", endingWhoNum);
        PlayerPrefs.Save();
    }

    public void OkName()
    {
        PlayerPrefs.SetFloat("PlayerHeart", 0);
        PlayerPrefs.SetFloat("IanHeart", 0);
        PlayerPrefs.SetFloat("NoaHeart", 0);
        PlayerPrefs.SetFloat("AustinHeart", 0);
        
        PlayerPrefs.SetInt("Opening", 1);
        PlayerPrefs.SetString("PlayerName", nameTxt.text);
        PlayerPrefs.SetInt("Date", 1);
        PlayerPrefs.SetInt("Coin", 0);
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
    
    private IEnumerator FadeRightHome(int placeNum, int placeBgmNum, Dialogue dialogue, string situationCaseName, int countNum, bool changeAudio)
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.transform.localPosition = new Vector3(540, 0, 0);
        fadeImage.color = new Color(1, 1, 1, 0);
        
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

        LobbyManager.Instance.SettingBackImage(placeNum);
        LobbyManager.Instance.SettingSituationCaseDialogue(placeBgmNum, dialogue, situationCaseName, countNum, changeAudio);

        while (fadeImage.rectTransform.localPosition.x > -1550f)
        {
            _time += Time.deltaTime * 0.1f;

            fadeImage.rectTransform.localPosition = 
                Vector3.Lerp(fadeImage.rectTransform.localPosition, _fadeImageMovePos, _time);

            yield return null;
        }

        if (changeAudio.Equals(true))
        {
            LobbyManager.Instance.SettingLobbyBgmSound();
        }
        
        LobbyManager.Instance.SettingLobbyDialogue();

        fadeImage.gameObject.SetActive(false);

        yield return null;
    }
    
    private IEnumerator FadeDream(int placeNum)
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.transform.localPosition = new Vector3(540, 0, 0);
        fadeImage.color = new Color(1, 1, 1, 0);

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
       
        LobbyManager.Instance.SettingBackImage(placeNum);
        
        yield return _yieldViewDelay;
        
        while (alpha.a > 0)
        {
            _time += Time.deltaTime / _currentFadeTime;
            
            alpha.a = Mathf.Lerp(1, 0, _time);
            
            fadeImage.color = alpha;
            
            yield return null;
        }
        
        LobbyManager.Instance.Event3Next();

        fadeImage.gameObject.SetActive(false);

        yield return null;
    }

    [SerializeField] private Sprite endingImage;
    private IEnumerator FadeEnding()
    {
        fadeImage.sprite = endingImage;
        fadeImage.gameObject.SetActive(true);
        fadeImage.transform.localPosition = new Vector3(540, 0, 0);
        fadeImage.color = new Color(1, 1, 1, 0);
        endingTxtGo.SetActive(true);

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

        PlayerPrefs.DeleteKey("IanFirst");
        PlayerPrefs.DeleteKey("NoaFirst");
        PlayerPrefs.DeleteKey("AustinFirst");
        PlayerPrefs.DeleteKey("IanShowHeart");
        PlayerPrefs.DeleteKey("NoaShowHeart");
        PlayerPrefs.DeleteKey("AustinShowHeart");
        PlayerPrefs.SetFloat("PlayerHeart", 0);
        PlayerPrefs.SetFloat("IanHeart", 0);
        PlayerPrefs.SetFloat("NoaHeart", 0);
        PlayerPrefs.SetFloat("AustinHeart", 0);
        
        for (int i = 0; i < LobbyManager.Instance.isAlbum.Length; i++)
        {
            if (LobbyManager.Instance.isAlbum[i].Equals(true))
            {
                // 0 ~ 18;
                PlayerPrefs.SetInt(i.ToString(), 1);
            }
        }
        
        LobbyManager.Instance.isBuy = false;
        PlayerPrefs.SetInt("Date", 1);
        PlayerPrefs.SetInt("Coin", 0);
        PlayerPrefs.SetInt("Event3", 0);
        PlayerPrefs.SetInt("Event4", 0);
        PlayerPrefs.SetInt("Ending", 0);
        PlayerPrefs.Save();
        
        for (int i = 0; i < endingTxt.Length; i++)
        {
            endingTxts.text += endingTxt[i];

            if (i % 7 == 1)
            {
                typeSound.Play();
            }
            
            yield return new WaitForSeconds(textDelay);
        }
        
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainScene");

        yield return null;
    }
}

