using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    public static ChoiceManager Instance;
    
    [SerializeField] private AudioClip clickAudio;
    
    [SerializeField] private GameObject choiceObjectUI;
    [SerializeField] private GameObject[] choiceCountGo;
    
    [SerializeField] private string[] choiceTxtInfo;

    [SerializeField] private TextMeshProUGUI[] choiceTxt;
    
    [SerializeField] private int[] choiceTxtNums;
    
    public int choiceNum;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectChoice(int num)
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);
        
        choiceNum = choiceTxtNums[num];
        
        choiceObjectUI.SetActive(false);

        switch (choiceNum)
        {
            // 외출하기
            case 0:
                LobbyManager.Instance.GoingOut();
                break;
            // 교양 쌓기
            case 1:
                LobbyManager.Instance.Cultivation();
                break;
            // 행상인 부르기
            case 2:
                LobbyManager.Instance.CallPeddler();
                break;
            // 물약 구매 후 이안 칼릭스
            case 3:
                LobbyManager.Instance.UsePotion(1);
                break;
            // 물약 구매 후 노아 셀베스틴
            case 4:
                LobbyManager.Instance.UsePotion(2);
                break;
            // 물약 구매 후 아스틴
            case 5:
                LobbyManager.Instance.UsePotion(3);
                break;
            // 초코 구매 후 이안 칼릭스
            case 6:
                LobbyManager.Instance.UseChoco(1);
                break;
            // 초코 구매 후 노아 셀베스틴
            case 7:
                LobbyManager.Instance.UseChoco(2);
                break;
            // 초코 구매 후 아스틴
            case 8:
                LobbyManager.Instance.UseChoco(3);
                break;
            // 이동한다 선택
            case 9:
                DailyRoutine.Instance.StartFadePlace(WorldManager.Instance.selectPlaceNum);
                break;
            // 다시 선택한다 선택
            case 10:
                WorldManager.Instance.ResetTxtBox();
                break;
        }
    }

    public void ShowTwoChoice(int num)
    {
        choiceObjectUI.SetActive(true);
        choiceCountGo[0].SetActive(true);
        choiceCountGo[1].SetActive(false);
        
        choiceTxtNums[0] = num * 3;
        choiceTxtNums[1] = num * 3 + 1;

        choiceTxt[0].text = choiceTxtInfo[num * 3];
        choiceTxt[1].text = choiceTxtInfo[num * 3 + 1];
    }

    public void ShowThreeChoice(int num)
    {
        choiceObjectUI.SetActive(true);
        choiceCountGo[0].SetActive(false);
        choiceCountGo[1].SetActive(true);
        
        choiceTxtNums[2] = num * 3;
        choiceTxtNums[3] = num * 3 + 1;
        choiceTxtNums[4] = num * 3 + 2;
        
        choiceTxt[2].text = choiceTxtInfo[num * 3];
        choiceTxt[3].text = choiceTxtInfo[num * 3 + 1];
        choiceTxt[4].text = choiceTxtInfo[num * 3 + 2];
    }
}
