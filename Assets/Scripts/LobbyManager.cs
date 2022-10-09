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

    [SerializeField] private TextMeshProUGUI coinTxt;
    
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

        reputationUI.SetActive(true);
        settingUI.SetActive(false);
           
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
