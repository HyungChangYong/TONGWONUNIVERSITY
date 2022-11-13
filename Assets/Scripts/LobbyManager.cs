using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager Instance;

    public int coin;
    public int date;
    // public string date;
    
    private AudioClip _placeBgm;
    [SerializeField] private AudioClip[] placeBgmClips;
    private Dialogue _dialogue;


    [SerializeField] private AudioClip tutorialAudio;
    [SerializeField] private AudioClip party3Audio;
    [SerializeField] private AudioClip fitAudio;
    [SerializeField] private AudioClip debut2Audio;
    [SerializeField] private AudioClip debut3Audio;
    [SerializeField] private AudioClip hittingAudio;
    [SerializeField] private AudioClip wineAudio;
    [SerializeField] private AudioClip dreamAudio;
    
    [SerializeField] private Sprite windowBasic;
    [SerializeField] private Sprite[] playerBasic;
    [SerializeField] private Sprite[] dateSprite;
    [SerializeField] private Sprite[] showBuyPopUpUISprite;
    [SerializeField] private Sprite[] lobbyBackSprite;
    
    [SerializeField] private Image dateImage;
    [SerializeField] private Image showBuyPopUpImage;
    [SerializeField] private Image lobbyBackImage;

    [SerializeField] private RectTransform profileSizeUpPlayerInfoTxt;
    [SerializeField] private RectTransform profileBasePlayerInfoTxt;

    [SerializeField] private ReputationImage reputationImage;

    [SerializeField] private TextMeshProUGUI coinTxt;
    [SerializeField] private TextMeshProUGUI shopCoinTxt;
    [SerializeField] private TextMeshProUGUI profileSizeUpPlayerNameTxt;
    [SerializeField] private TextMeshProUGUI profileBasePlayerNameTxt;
    
    [SerializeField] private AudioClip clickAudio;
    
    [SerializeField] private TextMeshProUGUI lobbyConversation;
    [SerializeField] private TextMeshProUGUI lobbyCharterName;
    [SerializeField] private TextMeshProUGUI dateTxt;
    [SerializeField] private Image lobbyCharterImage;
    [SerializeField] private Image lobbyWindow;
    [SerializeField] private Animator lobbyCharterAnimator;
    [SerializeField] private Animator lobbyTxtBtnAnimator;
    [SerializeField] private GameObject lobbyTxtBtnImageGo;
    [SerializeField] private Image lobbyTxtBtnImage;
    [SerializeField] private GameObject lobbyTxtBoxLineGo;
    
    public GameObject lobbyNextBtnGo;
    [SerializeField] private GameObject reputationUI;
    [SerializeField] private GameObject settingUI;
    [SerializeField] private GameObject albumUI;
    [SerializeField] private GameObject showBuyPopUpUIGo;
    [SerializeField] private GameObject warningUIGo;

    private bool _isValetCall;

    private string _situationCaseName;

    public bool[] isAlbum;

    [SerializeField] private Image[] illustrationImage;

    [SerializeField] private Sprite[] illustrationImageSprite;
    
    public Sprite[] illustration;
    
    [SerializeField] private Image maximImage;
    [SerializeField] private GameObject maximImageGo;

    [SerializeField] private Scrollbar reputationScrollBar;
    [SerializeField] private Scrollbar albumScrollBar;

    [SerializeField] private Image[] heartBarSizeUp;
    [SerializeField] private Image[] heartBarBase;
    
    [SerializeField] private RectTransform[] heartImageSizeUp;
    [SerializeField] private RectTransform[] heartImageBase;

    private readonly Vector3 _startPosSizeUp = new Vector3(-290, 0, 0);
    private readonly Vector3 _endPosSizeUp = new Vector3(280, 0, 0);
    
    private readonly Vector3 _startPosBase = new Vector3(-225, 0, 0);
    private readonly Vector3 _endPosBase = new Vector3(216, 0, 0);
 
    private int _maxHeart = 100;

    public float[] nowHeart;

    public bool[] isShowHeart;

    [SerializeField] private GameObject[] lockImageSizeUp;
    [SerializeField] private GameObject[] lockImageBase;

    [SerializeField] private GameObject[] lobbyUI;

    public bool isBuy;

    private int _whatItem;

    public bool isSaturday;

    public void SettingDate()
    {
        dateTxt.text = "DAY" + date;

        dateImage.sprite = dateSprite[date - 1];
    }
    
    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        SettingCoin();
    }

    public void SettingBackImage(int placeNum)
    {
        lobbyBackImage.sprite = lobbyBackSprite[placeNum];
    }
    
    public void SettingLobbyBgmSound()
    {
        SettingUI.Instance.SettingBgmSound(_placeBgm);
    }
    
    public void SettingLobbyDialogue()
    {
        DialogueManager.Instance.ShowDialogue(_dialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void SettingSituationCaseDialogue(int placeBgmNum, Dialogue dialogue, string situationCaseName, int countNum, bool changeAudio)
    {
        if (changeAudio.Equals(true))
        {
            // 전용 bgm
            _placeBgm = placeBgmClips[placeBgmNum];
        }

        _dialogue = dialogue;
                        
        // 상황
        _situationCaseName = situationCaseName;
                        
        // 대화를 시작할 인덱스
        DialogueManager.Instance.count = countNum;
        
        if (dialogue.charterImages[0].name.Contains("Girl").Equals(true))
        {
            lobbyCharterName.text = PlayerPrefs.GetString("PlayerName");
        }
        else if (dialogue.charterImages[0].name.Contains("Valet").Equals(true))
        {
            lobbyCharterName.text = "집사";
        }
        else
        {
            lobbyCharterName.text = "";
        }
        
        lobbyCharterImage.sprite = dialogue.charterImages[0];
        lobbyWindow.sprite = dialogue.dialogueWindows[0];
    }

    public void SettingCoin()
    {
        if (coin > 1000000)
        {
            coin = 1000000;
        }
        
        if (coin == 0)
        {
            coinTxt.text = "0";
            shopCoinTxt.text = "0";
        }
        else
        {
            coinTxt.text = string.Format("{0:#,###}", coin);
            shopCoinTxt.text = string.Format("{0:#,###}", coin);
        }
    }

    public void ValetCallSound()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);

        if (date - 27 == 0)
        {
            isSaturday = true;
            SaturdayValetCall();
        }
        else if (date - 20 == 0)
        {
            isSaturday = true;
            SaturdayValetCall();
        }
        else if (date - 13 == 0)
        {
            isSaturday = true;
            SaturdayValetCall();
        }
        else if (date - 6 == 0)
        {
            isSaturday = true;
            SaturdayValetCall();
        }
        else
        {
            isSaturday = false;
            ValetCall();
        }
    }

    public void ResetLobbyUI()
    {
        for (int i = 0; i < lobbyUI.Length; i++)
        {
            lobbyUI[i].SetActive(true);
        }
    }

    public void SaturdayValetCall()
    {
        if (_isValetCall.Equals(false))
        {
            _situationCaseName = "SaturdayValetCall";

            for (int i = 0; i < lobbyUI.Length; i++)
            {
                lobbyUI[i].SetActive(false);
            }
            
            lobbyTxtBoxLineGo.SetActive(true);
            lobbyNextBtnGo.SetActive(true);
            
            lobbyCharterName.text = "집사";
            
            // 다른 거 호출 하는 방식으로 변경
            DialogueManager.Instance.count = 1;

            DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.saturdayValetCallDialogue, "SaturdayValetCall", lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);

            _isValetCall = true;
        }
    }

    public void ValetCall()
    {
        if (_isValetCall.Equals(false))
        {
            _situationCaseName = "ValetCall";

            for (int i = 0; i < lobbyUI.Length; i++)
            {
                lobbyUI[i].SetActive(false);
            }
            
            lobbyTxtBoxLineGo.SetActive(true);
            lobbyNextBtnGo.SetActive(true);
            
            // 다른 거 호출 하는 방싟으로 변경
            DialogueManager.Instance.count = 1;

            DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.valetCallDialogue, "ValetCall", lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);

            _isValetCall = true;
        }
    }
    
    public void ResetLobby(int num)
    {
        lobbyTxtBoxLineGo.SetActive(false);
        lobbyNextBtnGo.SetActive(false);
        
        lobbyCharterName.text = "집사";
        lobbyWindow.sprite = windowBasic;

        lobbyCharterImage.sprite = playerBasic[num];
    }

    public void Cultivation()
    {
        // if (lobbyCharterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            _situationCaseName = "Cultivation";
        
            lobbyTxtBoxLineGo.SetActive(true);
        
            DialogueManager.Instance.count = 1;
            DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.cultivationDialogue, "Cultivation", lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
        }
    }

    public void CallPeddler()
    {
        if (isBuy.Equals(false))
        {
            _situationCaseName = "CallPeddler";
        
            lobbyTxtBoxLineGo.SetActive(true);
            
            DialogueManager.Instance.count = 1;

            DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.callPeddlerDialogue, "CallPeddler", lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
        }
        else
        {
            _situationCaseName = "BuyPaddler";
        
            lobbyTxtBoxLineGo.SetActive(true);
            
            DialogueManager.Instance.count = 1;
            
            DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.buyPaddlerDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
        }
    }

    public void ShowBuyPopUp(int num)
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);
        
        _whatItem = num;
        
        showBuyPopUpImage.sprite = showBuyPopUpUISprite[_whatItem];
        
        showBuyPopUpUIGo.SetActive(true);
    }
    
    public void CheckBuyItem()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);
        
        if (_whatItem == 0)
        {
            if (coin < 100000)
            {
                showBuyPopUpUIGo.SetActive(false);
                warningUIGo.SetActive(true);
            }
            else
            {
                // 물약 구매
                isBuy = true;

                coin -= 100000;

                SettingCoin();
                
                BuyItem("BuyPotion", DialogueTxt.Instance.buyPotionDialogue);
            }
        }
        else
        {
            if (coin < 400000)
            {
                showBuyPopUpUIGo.SetActive(false);
                warningUIGo.SetActive(true);
            }
            else
            {
                isBuy = true;
                
                coin -= 400000;
                
                SettingCoin();
                
                BuyItem("BuyChoco", DialogueTxt.Instance.buyChocoDialogue);
            }
        }
    }

    public void OkWarningUIBtn()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);
        
        warningUIGo.SetActive(false);
    }

    public void HideBuyPopUp()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);
        
        showBuyPopUpUIGo.SetActive(false);
    }

    private void BuyItem(string situationCaseName, Dialogue dialogue)
    {
        _situationCaseName = situationCaseName;
        
        DialogueManager.Instance.shopUI.SetActive(false);
        lobbyTxtBoxLineGo.SetActive(true);
        lobbyNextBtnGo.SetActive(true);
        showBuyPopUpUIGo.SetActive(false);
            
        DialogueManager.Instance.count = 1;
            
        DialogueManager.Instance.ShowDialogue(dialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }

    public void CancelShowUI(int num)
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);

        _situationCaseName = "CancelShowUI";
        
        DialogueManager.Instance.shopUI.SetActive(false);
        lobbyTxtBoxLineGo.SetActive(true);
        lobbyNextBtnGo.SetActive(true);
            
        DialogueManager.Instance.count = num;
            
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.cancelShopDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void ShowReputationUI()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);

        SettingHeartBar();

        string playerName = PlayerPrefs.GetString("PlayerName");
        
        profileSizeUpPlayerNameTxt.text = playerName;
        profileBasePlayerNameTxt.text = playerName;
        
        profileSizeUpPlayerInfoTxt.localPosition =
            new Vector3(-152 + 40 * (playerName.Length - 1), -353.5f, 0);
        profileBasePlayerInfoTxt.localPosition = new Vector3(-75 + 30 * (playerName.Length - 1), -274, 0);

        reputationUI.SetActive(true);
        settingUI.SetActive(false);

        reputationImage.ResetImage();
        reputationScrollBar.value = 0;
    }

    private void SettingHeartBar()
    {
        for (int i = 0; i < heartBarSizeUp.Length; i++)
        {
            if (isShowHeart[i].Equals(true))
            {
                lockImageSizeUp[i].SetActive(false);
                lockImageBase[i].SetActive(false);
                
                heartBarSizeUp[i].fillAmount = nowHeart[i] / _maxHeart;
                heartBarBase[i].fillAmount = heartBarSizeUp[i].fillAmount;
            
                heartImageSizeUp[i].localPosition = Vector3.Lerp(_startPosSizeUp, _endPosSizeUp, heartBarSizeUp[i].fillAmount);
                heartImageBase[i].localPosition = Vector3.Lerp(_startPosBase, _endPosBase, heartBarBase[i].fillAmount);
            }
            else
            {
                lockImageSizeUp[i].SetActive(true);
                lockImageBase[i].SetActive(true);
                
                heartBarSizeUp[i].fillAmount = 0;
                heartBarBase[i].fillAmount = 0;

                heartImageSizeUp[i].localPosition = _startPosSizeUp;
                heartImageBase[i].localPosition = _startPosBase;
            }
        }
    }

    public void HideReputationUI()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);
        
        reputationUI.SetActive(false);
        settingUI.SetActive(true);
    }

    public void ShowAlbumUI()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);
        
        albumUI.SetActive(true);
        settingUI.SetActive(false);
        
        albumScrollBar.value = 1;
    }

    public void HideAlbumUI()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);

        albumUI.SetActive(false);
        settingUI.SetActive(true);
    }

    public void ClearAlbum(int num)
    {
        isAlbum[num] = true;

        illustrationImage[num].sprite = illustrationImageSprite[num];
    }

    public void ShowMaximAlbum(int num)
    {
        if (isAlbum[num].Equals(true))
        {
            SettingUI.Instance.SettingSfxSound(clickAudio);
            
            maximImage.sprite = illustration[num];
            maximImageGo.SetActive(true);
        }
    }

    public void HideMaximAlbum()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);
        
        maximImageGo.SetActive(false);
    }

    public void NextLobbyBtn()
    {
        DialogueManager.Instance.NextBtn(_situationCaseName);

        _isValetCall = false;
    }

    public void GoingOut()
    {
        _situationCaseName = "GoingOut";
            
        lobbyTxtBoxLineGo.SetActive(true);
            
        DialogueManager.Instance.count = 1;

        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.goingOutDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }

    public void UsePotion(int num)
    {
        if (isShowHeart[num].Equals(true))
        {
            _situationCaseName = "OverlapUsePotion";
            
            lobbyTxtBoxLineGo.SetActive(true);
            
            DialogueManager.Instance.count = 1;

            DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.overlapUsePotionDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
        }
        // 물약 사용
        else
        {
            isShowHeart[num] = true;
            
            _situationCaseName = "UsePotion";
        
            lobbyTxtBoxLineGo.SetActive(true);
            
            DialogueManager.Instance.count = 1;

            DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.usePotionDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
        }
    }
    
    public void Event1()
    {
        _situationCaseName = "Event1";
        
        lobbyTxtBoxLineGo.SetActive(true);
        lobbyNextBtnGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event1Dialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event1Manner()
    {
        _situationCaseName = "Event1Manner";
        
        lobbyTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event1MannerDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event1Dance()
    {
        _situationCaseName = "Event1Dance";
        
        lobbyTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event1DanceDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event1TeaCeremony()
    {
        _situationCaseName = "Event1TeaCeremony";
        
        lobbyTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event1TeaCeremonyDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event1SpeakArt()
    {
        _situationCaseName = "Event1SpeakArt";
        
        lobbyTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event1SpeakArtDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event1SwardArt()
    {
        _situationCaseName = "Event1SwardArt";
        
        lobbyTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event1SwardArtDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event2()
    {
        _situationCaseName = "Event2";
        
        lobbyTxtBoxLineGo.SetActive(true);
        lobbyNextBtnGo.SetActive(true);
        
        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event2Dialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }

    public void Event2Next()
    {
        _situationCaseName = "Event2Next";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event2NextDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event2Ignore()
    {
        _situationCaseName = "Event2Ignore";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event2IgnoreDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event2Right()
    {
        SettingUI.Instance.SettingBgmSound(fitAudio);
        
        _situationCaseName = "Event2Right";
        
        lobbyTxtBoxLineGo.SetActive(true);
    
        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event2RightDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event2Rebut()
    {
        SettingUI.Instance.SettingBgmSound(debut2Audio);
        
        _situationCaseName = "Event2Rebut";
        
        lobbyTxtBoxLineGo.SetActive(true);
    
        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event2RebutDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }

    public void Event2HitCheek()
    {
        SettingUI.Instance.SettingBgmSound(hittingAudio);
        
        _situationCaseName = "Event2HitCheek";
        
        lobbyTxtBoxLineGo.SetActive(true);
    
        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event2HitCheekDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }

    public void Event2WineSpray()
    {
        SettingUI.Instance.SettingBgmSound(wineAudio);
        
        _situationCaseName = "Event2WineSpray";
        
        lobbyTxtBoxLineGo.SetActive(true);
    
        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event2WineSprayDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }

    public void Event2Cry()
    {
        SettingUI.Instance.SettingBgmSound(debut3Audio);
        
        _situationCaseName = "Event2Cry";
        
        lobbyTxtBoxLineGo.SetActive(true);
    
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event2CryDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event2Select()
    {
        _situationCaseName = "Event2Select";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event2Select, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }

    public void SettingBaseBackImage(Dialogue dialogue)
    {
        if (dialogue.charterImages[0].name.Contains("Girl").Equals(true))
        {
            lobbyCharterName.text = PlayerPrefs.GetString("PlayerName");
        }
        else
        {
            lobbyCharterName.text = "";
        }
        
        lobbyCharterImage.sprite = dialogue.charterImages[0];
        lobbyWindow.sprite = dialogue.dialogueWindows[0];
    }

    public void UseChoco(int num)
    {
        lobbyWindow.sprite = windowBasic;
        
        nowHeart[num] += 10;

        if (nowHeart[num] > 100)
        {
            nowHeart[num] = 100;
        }

        ValetCall();
    }
    
    public void Event3Ian()
    {
        _situationCaseName = "Event3Ian";
        
        lobbyTxtBoxLineGo.SetActive(true);
        lobbyNextBtnGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event3IanDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Even3IanDrink()
    {
        SettingUI.Instance.SettingBgmSound(party3Audio);
        
        _situationCaseName = "Even3IanDrink";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.even3IanDrinkDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Even3IanWait()
    {
        _situationCaseName = "Even3IanWait";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.even3IanWaitDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }

    public void Event3Noa()
    {
        _situationCaseName = "Event3Noa";
        
        lobbyTxtBoxLineGo.SetActive(true);
        lobbyNextBtnGo.SetActive(true);

        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event3NoaDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event3NoaStay()
    {
        _situationCaseName = "Event3NoaStay";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event3NoaStayDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event3NoaAvoid()
    {
        _situationCaseName = "Event3NoaAvoid";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event3NoaAvoidDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event3NoaSelect()
    {
        _situationCaseName = "Event3NoaSelect";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event3NoaSelectDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event3Austin()
    {
        _situationCaseName = "Event3Austin";
        
        lobbyTxtBoxLineGo.SetActive(true);
        lobbyNextBtnGo.SetActive(true);

        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event3AustinDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event3AustinBelieve()
    {
        _situationCaseName = "Event3AustinBelieve";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event3AustinBelieveDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }

    public void Event3AustinWind()
    {
        _situationCaseName = "Event3AustinWind";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event3AustinWindDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event3AustinSelect()
    {
        _situationCaseName = "Event3AustinSelect";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event3AustinSelectDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }

    public void Event3Next()
    {
        SettingUI.Instance.SettingBgmSound(dreamAudio);
        
        _situationCaseName = "Event3Next";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event3NextDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }

    public void GetAlbum(Dialogue dialogue, string situationCaseName)
    {
        if (dialogue.charterImages[0].name.Contains("Girl").Equals(true))
        {
            lobbyCharterName.text = PlayerPrefs.GetString("PlayerName");
        }
        else
        {
            lobbyCharterName.text = "";
        }
        
        lobbyCharterImage.sprite = dialogue.charterImages[0];
        lobbyWindow.sprite = dialogue.dialogueWindows[0];
        
        _situationCaseName = situationCaseName;
        
        lobbyTxtBoxLineGo.SetActive(true);
    
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(dialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }

    public void Event4Ian()
    {
        _situationCaseName = "Event4Ian";
        SettingBaseBackImage(DialogueTxt.Instance.event4IanDialogue);
        
        lobbyTxtBoxLineGo.SetActive(true);
        lobbyNextBtnGo.SetActive(true);

        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event4IanDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event4IanFrankly()
    {
        _situationCaseName = "Event4IanFrankly";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event4IanFranklyDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event4IanBright()
    {
        _situationCaseName = "Event4IanBright";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event4IanBrightDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event4IanSelect()
    {
        _situationCaseName = "Event4IanSelect";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event4IanSelectDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event4Noa()
    {
        _situationCaseName = "Event4Noa";
        SettingBaseBackImage(DialogueTxt.Instance.event4NoaDialogue);
        
        lobbyTxtBoxLineGo.SetActive(true);
        lobbyNextBtnGo.SetActive(true);

        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event4NoaDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event4NoaOkay()
    {
        _situationCaseName = "Event4NoaOkay";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event4NoaOkayDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event4NoaGood()
    {
        _situationCaseName = "Event4NoaGood";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event4NoaGoodDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event4NoaSelect()
    {
        _situationCaseName = "Event4NoaSelect";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event4NoaSelectDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event4Austin()
    {
        _situationCaseName = "Event4Austin";
        SettingBaseBackImage(DialogueTxt.Instance.event4AustinDialogue);
        
        lobbyTxtBoxLineGo.SetActive(true);
        lobbyNextBtnGo.SetActive(true);

        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event4AustinDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    public void Event4AustinJoke()
    {
        _situationCaseName = "Event4AustinJoke";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event4AustinJokeDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }

    public void Event4AustinThink()
    {
        _situationCaseName = "Event4AustinThink";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event4AustinThinkDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
    
    
    public void Event4AustinSelect()
    {
        _situationCaseName = "Event4AustinSelect";
        
        lobbyTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.event4AustinSelectDialogue, _situationCaseName, lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);
    }
}
