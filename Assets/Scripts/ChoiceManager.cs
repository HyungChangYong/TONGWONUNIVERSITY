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
    
    public bool isAddIanHeart;

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
            # region 타운
            // 이안 즐겁다 선택
            case 12:
                isAddIanHeart = false;
                DailyRoutine.Instance.TownIan2Fun();
                break;
            // 이안 귀찮다 선택
            case 13:
                isAddIanHeart = true;
                DailyRoutine.Instance.TownIan2Tiresome();
                break;
            // 이안 아는 척한다
            case 15:
                isAddIanHeart = true;
                DailyRoutine.Instance.TownIan3Hi();
                break;
            // 이안 모르는 척한다
            case 16:
                isAddIanHeart = false;
                DailyRoutine.Instance.TownIan3Ignore();
                break;
            // 노아 실수로 왔다고 한다
            case 18:
                isAddIanHeart = false;
                DailyRoutine.Instance.TownNoa1Mistake();
                break;
            // 노아 가만히 있는다
            case 19:
                isAddIanHeart = true;
                DailyRoutine.Instance.TownNoa1Stand();
                break;
            // 노아 위로하기
            case 21:
                isAddIanHeart = false;
                DailyRoutine.Instance.TownNoa4Cheer();
                break;
            // 노아 질문하기
            case 22:
                isAddIanHeart = true;
                DailyRoutine.Instance.TownNoa4Question();
                break;
            // 아스틴 불꽃놀이 보러 가기
            case 24:
                isAddIanHeart = false;
                DailyRoutine.Instance.TownAustin2FireFestival();
                break;
            // 아스틴 다른 곳 둘러보기
            case 25:
                isAddIanHeart = true;
                DailyRoutine.Instance.TownAustin2Around();
                break;
            #endregion
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
