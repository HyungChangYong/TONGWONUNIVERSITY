using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

    [SerializeField] private Image whiteFadeImage;
    [SerializeField] private Image fadeImage;
    [SerializeField] private Image dataImage;
    [SerializeField] private Image infoImage;
    [SerializeField] private Image reputationImage;
    [SerializeField] private Image settingImage;
    [SerializeField] private Image[] fadeBlurImage;

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

    private bool _isBuyDialogueEnd;

    public GameObject shopUI;

    [SerializeField] private GameObject placeUIGo;
    
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
                StartCoroutine(FadeInfoEvent(0, 1, 5));
                break;
            case "Event1Dance":
                StartCoroutine(FadeInfoEvent(0, 2, 5));
                break;
            case "Event1TeaCeremony":
                StartCoroutine(FadeInfoEvent(0, 3, 5));
                break;
            case "Event1SpeakArt":
                StartCoroutine(FadeInfoEvent(0, 4, 5));
                break;
            case "Event1SwardArt":
                StartCoroutine(FadeInfoEvent(5, 6, 5));
                break;
            case "Event2":
                StartCoroutine(FadeImage());
                break;
            case "Event2Next":
                choiceTxt.text = "[ " + DialogueTxt.Instance.event2NextDialogue.sentences[28] + " ]";
                dialogueWindow.gameObject.SetActive(false);
                
                ChoiceManager.Instance.ShowSixChoice(30);
                break;
        }
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

    private void SettingWhiteBox()
    {
        conversation.font = blackOutline;
        txtBtnImage.sprite = blackNextBtn;
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
                                    break;
                                case 5:
                                    charterName.text = "";
                                    break;
                                case 8:
                                    charterName.text = "";
                                    break;
                                case 12:
                                    charterName.text = "???";
                                    break;
                                case 13:
                                    charterName.text = "";
                                    break;
                                case 21:
                                    charterName.text = "???";
                                    break;
                                case 25:
                                    charterName.text = "???";
                                    break;
                                case 28:
                                    charterName.text = "";
                                    break;
                                case 35:
                                    charterName.text = "";
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
                                    charterName.text = "???";
                                    break;
                                case 7:
                                    charterName.text = "";
                                    break;
                                case 9:
                                    charterName.text = "???";
                                    break;
                                case 10:
                                    charterName.text = "";
                                    break;
                                case 21:
                                    charterName.text = "";
                                    SettingUI.Instance.SettingSfxSound(surpriseAudio);
                                    break;
                                case 23:
                                    charterName.text = "";
                                    break;
                                case 35:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "FirstAustin":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingSfxSound(dropAudio);
                                    break;
                                case 5:
                                    charterName.text = "";
                                    break;
                                case 17:
                                    charterName.text = "";
                                    break;
                                case 25:
                                    charterName.text = "";
                                    break;
                                case 28:
                                    charterName.text = "";
                                    break;
                                case 30:
                                    charterName.text = "";
                                    break;
                            }   
                            break;
                        case "TownIan2":
                            switch (count)
                            {
                                case 2:
                                    charterName.text = "";
                                    break;
                            }   
                            break;
                        case "TownIan2Select":
                            switch (count)
                            {
                                case 5:
                                    charterName.text = "";
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
                                case 11:
                                    SettingUI.Instance.SettingBgmSound(dangerousAudio);
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
                                case 9:
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
                        case "ParkIan3":
                            switch (count)
                            {
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
                                case 6:
                                    Handheld.Vibrate();
                                    break;
                                case 15:
                                    charterName.text = "";
                                    break;
                            }   
                            break;
                        case "ParkAustin2Chasing":
                            switch (count)
                            {
                                case 7:
                                    charterName.text = "";
                                    break;
                            }   
                            break;
                        case "BeachIan1":
                            switch (count)
                            {
                                case 2:
                                    SettingUI.Instance.StopSfxLoopSound();
                                    break;
                                case 13:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "BeachNoa1":
                            switch (count)
                            {
                               case 11:
                                   DailyRoutine.Instance.SettingPlaceImage(18);
                                   SettingUI.Instance.SettingSfxLoopSound(rainAudio);
                                   break;
                               case 13:
                                   SettingUI.Instance.StopSfxLoopSound();
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
                                case 16:
                                    Handheld.Vibrate();
                                    SettingUI.Instance.SettingSfxLoopSound(wave2Audio);
                                    break;
                                case 18:
                                    SettingUI.Instance.StopSfxLoopSound();
                                    break;
                            }
                            break;
                        case "BeachAustin2":
                            switch (count)
                            {
                                case 19:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "GalleryAustin1":
                            switch (count)
                            {
                                case 7:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "GalleryAustin1Select":
                            switch (count)
                            {
                                case 10:
                                    charterName.text = "";
                                    break;
                            }
                            break;
                        case "HomeIan1Talk":
                            switch (count)
                            {
                                case 8:
                                    charterName.text = "";
                                    break;
                                case 11:
                                    charterName.text = "";
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
                        case "HomeAustin1":
                            switch (count)
                            {
                                case 3:
                                    charterName.text = "";
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
                            }
                            break;
                        case "HomeAustin2CallAustin":
                            switch (count)
                            {
                                case 1:
                                    SettingUI.Instance.SettingBgmSound(square3Audio);
                                    Handheld.Vibrate();
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
                                break;
                            case "Event2":
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

        // 이벤트 실행
        if (LobbyManager.Instance.date % 7 != 0)
        {
            LobbyManager.Instance.ResetLobbyUI();
        }

        switch (num)
        {
            case 0:
                LobbyManager.Instance.nowHeart[0] += addNowHeart[_randomCultivation];
                LobbyManager.Instance.coin += addCoin[_randomCultivation];
                LobbyManager.Instance.SettingCoin();
                break;
            case 1:
                LobbyManager.Instance.nowHeart[1] += 5;
                break;
            case 2:
                LobbyManager.Instance.nowHeart[2] += 5;
                break;
            case 3:
                LobbyManager.Instance.nowHeart[3] += 5;
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
    
    private IEnumerator FadeInfoEvent(int reputationNum, int nowHeartNum, int addHeart)
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
        
        LobbyManager.Instance.ResetLobbyUI();

        switch (reputationNum)
        {
            case 0:
                LobbyManager.Instance.nowHeart[0] += 20;
                break;
        }

        LobbyManager.Instance.ResetLobby(0);

        yield return null;
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
                LobbyManager.Instance.nowHeart[1] += addHeart;
                break;
            case 2:
                LobbyManager.Instance.nowHeart[2] += addHeart;
                break;
            case 3:
                LobbyManager.Instance.nowHeart[3] += addHeart;
                break;
            case 6:
                LobbyManager.Instance.nowHeart[1] += addHeart;
                LobbyManager.Instance.nowHeart[2] += addHeart;
                LobbyManager.Instance.nowHeart[3] += addHeart;
                break;
        }
        
        SaveData();
        
        yield return null;
    }
    
    private IEnumerator FadeDate(GameObject go)
    {
        dataImage.gameObject.SetActive(true);
        
        // 이벤트 2실행
        if (LobbyManager.Instance.date - 14 == 0)
        {
            SettingUI.Instance.SettingBgmSound(readyAudio);
            LobbyManager.Instance.SettingBackImage(0);
        }
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
        else if (LobbyManager.Instance.date - 14 == 0)
        {
            LobbyManager.Instance.Event2();
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
        
        PlayerPrefs.SetFloat("PlayerHeart", LobbyManager.Instance.nowHeart[0]);
        PlayerPrefs.SetFloat("IanHeart", LobbyManager.Instance.nowHeart[1]);
        PlayerPrefs.SetFloat("NoaHeart", LobbyManager.Instance.nowHeart[2]);
        PlayerPrefs.SetFloat("AustinHeart", LobbyManager.Instance.nowHeart[3]);
        
        LobbyManager.Instance.isBuy = false;
        PlayerPrefs.SetInt("Date", LobbyManager.Instance.date);
        PlayerPrefs.SetInt("Coin", LobbyManager.Instance.coin);
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
}
