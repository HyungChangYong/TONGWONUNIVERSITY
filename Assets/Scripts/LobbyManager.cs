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

    [SerializeField] private bool[] isAlbum;

    [SerializeField] private Image[] illustrationImage;

    [SerializeField] private Sprite[] illustrationImageSprite;
    
    [SerializeField] private Sprite[] illustration;
    
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

        if (date % 6 == 0)
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
}
