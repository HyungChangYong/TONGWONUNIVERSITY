using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;

    [SerializeField] private string[] homeName;

    [SerializeField] private GameObject worldUIGo;

    [SerializeField] private GameObject[] homeLockGo;
    [SerializeField] private GameObject[] homeGo;

    [SerializeField] private TextMeshProUGUI worldConversation;
    [SerializeField] private TextMeshProUGUI worldCharterName;
    [SerializeField] private Image worldCharterImage;
    [SerializeField] private Image worldWindow;
    [SerializeField] private Animator worldCharterAnimator;
    [SerializeField] private Animator worldTxtBtnAnimator;
    [SerializeField] private GameObject worldTxtBtnImageGo;
    [SerializeField] private GameObject worldTxtBoxLineGo;
    [SerializeField] private Image worldTxtBtnImage;
    
    [SerializeField] private GameObject worldNextBtnGo;

    private string _situationCaseName;
    
    public int selectPlaceNum;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowHome(int num)
    {
        homeLockGo[num].SetActive(false);
        homeGo[num].SetActive(true);
    }

    public void ShowWorldUI()
    {
        if (LobbyManager.Instance.nowHeart[1] >= 25)
        {
            Instance.ShowHome(0);
        }
        else if (LobbyManager.Instance.nowHeart[2] >= 25)
        {
            Instance.ShowHome(1);
        }
        else if (LobbyManager.Instance.nowHeart[3] >= 25)
        {
            Instance.ShowHome(2);
        }
        
        worldUIGo.SetActive(true);
    }

    public void ClickHome(int num)
    {
        selectPlaceNum = num;
        
        _situationCaseName = "PlaceSelect";
        
        worldCharterName.text = "집사";

        worldNextBtnGo.SetActive(true);
        worldTxtBoxLineGo.SetActive(true);
        
        DialogueTxt.Instance.placeSelectDialogue.sentences[0] = homeName[selectPlaceNum] + "으(로) 이동하시겠습니까?";
        
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.placeSelectDialogue, _situationCaseName, worldConversation, worldCharterName, worldCharterImage, worldWindow, worldCharterAnimator, worldTxtBtnAnimator, worldTxtBtnImageGo, worldTxtBtnImage);
    }

    public void ClickHomeLock()
    {
        _situationCaseName = "HomeLock";
        
        worldCharterName.text = PlayerPrefs.GetString("PlayerName");

        worldNextBtnGo.SetActive(true);
        worldTxtBoxLineGo.SetActive(true);

        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.homeLockDialogue, _situationCaseName, worldConversation, worldCharterName, worldCharterImage, worldWindow, worldCharterAnimator, worldTxtBtnAnimator, worldTxtBtnImageGo, worldTxtBtnImage);
    }

    public void NextWorldBtn()
    {
        DialogueManager.Instance.NextBtn(_situationCaseName);
    }

    public void ResetTxtBox()
    {
        worldNextBtnGo.SetActive(false);
        worldTxtBoxLineGo.SetActive(false);
    }
}
