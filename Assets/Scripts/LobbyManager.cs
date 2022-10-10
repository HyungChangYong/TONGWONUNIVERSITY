using System;
using System.Collections;
using System.Collections.Generic;
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
    
    [SerializeField] private RectTransform profileSizeUpPlayerInfoTxt;
    [SerializeField] private RectTransform profileBasePlayerInfoTxt;

    [SerializeField] private ReputationImage reputationImage;

    [SerializeField] private TextMeshProUGUI coinTxt;
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
    [SerializeField] private GameObject lobbyNextBtnGo;
    [SerializeField] private GameObject reputationUI;
    [SerializeField] private GameObject settingUI;
    [SerializeField] private GameObject albumUI;

    private bool _isValetCall;

    private string _situationCaseName;

    public bool[] isAlbum;

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

    public void SettingDate()
    {
        dateTxt.text = "DAY" + date;
    }
    
    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        coinTxt.text = coin.ToString();
    }

    public void ValetCall()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);

        if (_isValetCall.Equals(false))
        {
            _situationCaseName = "ValetCall";
            
            lobbyTxtBoxLineGo.SetActive(true);
            lobbyNextBtnGo.SetActive(true);
            
            lobbyCharterName.text = "집사";

            DialogueManager.Instance.count = 1;
            
            DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.valetCallDialogue, "ValetCall", lobbyConversation, lobbyCharterName, lobbyCharterImage, lobbyWindow, lobbyCharterAnimator, lobbyTxtBtnAnimator, lobbyTxtBtnImageGo, lobbyTxtBtnImage);

            _isValetCall = true;
        }
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

    // public void NextLobbyBtn()
    // {
    //     DialogueManager.Instance.NextBtn(_situationCaseName);
    // }
}
