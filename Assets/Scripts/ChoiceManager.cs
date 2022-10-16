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

        switch (choiceNum)
        {
            // 외출하기
            case 0:
                break;
            // 교양 쌓기
            case 1:
                choiceObjectUI.SetActive(false);

                LobbyManager.Instance.Cultivation();
                break;
            // 행상인 부르기
            case 2:
                choiceObjectUI.SetActive(false);

                LobbyManager.Instance.CallPeddler();
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
