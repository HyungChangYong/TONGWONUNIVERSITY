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
            #region 레스토랑
            // 이안 레몬 셔벗 잘 드시나봐요?
            case 27:
                isAddIanHeart = false;
                DailyRoutine.Instance.RestaurantIan1EatWell();
                break;
            // 이안 그거 레몬 셔벗 아닌가요?
            case 28:
                isAddIanHeart = true;
                DailyRoutine.Instance.RestaurantIan1QuestionEat();
                break;
            // 노아 생각보다 괜찮아요!
            case 30:
                isAddIanHeart = true;
                DailyRoutine.Instance.RestaurantNoa2Good();
                break;
            // 노아 제 입맛에 딱 맞아요!
            case 31:
                isAddIanHeart = false;
                DailyRoutine.Instance.RestaurantNoa2Perfect();
                break;
            // 아스틴 따라한다
            case 33:
                isAddIanHeart = true;
                DailyRoutine.Instance.RestaurantAustin2Copy();
                break;
            // 아스틴 기다린다
            case 34:
                isAddIanHeart = false;
                DailyRoutine.Instance.RestaurantAustin2Wait();
                break;
            #endregion
            #region 공원
            // 이안 식물은 마음이 편해져요
            case 36:
                isAddIanHeart = true;
                DailyRoutine.Instance.ParkIan1Plants();
                break;
            // 이안 식물도 좋지만 예쁜 밤하늘도 좋아해요
            case 37:
                isAddIanHeart = false;
                DailyRoutine.Instance.ParkIan1NightSky();
                break;
            // 이안 운동을 하고 있었어요
            case 39:
                isAddIanHeart = false;
                DailyRoutine.Instance.ParkIan3Exercise();
                break;
            // 이안 산책을 하고 있었어요
            case 40:
                isAddIanHeart = true;
                DailyRoutine.Instance.ParkIan3Walk();
                break;
            // 이안 꽃을 보러 간다
            case 42:
                isAddIanHeart = true;
                DailyRoutine.Instance.ParkIan5LookFlower();
                break;
            // 이안 공원에서 쉰다
            case 43:
                isAddIanHeart = false;
                DailyRoutine.Instance.ParkIan5Rest();
                break;   
            // 노아 강아지
            case 45:
                isAddIanHeart = false;
                DailyRoutine.Instance.ParkNoa1Dog();
                break;   
            // 노아 새
            case 46:
                isAddIanHeart = true;
                DailyRoutine.Instance.ParkNoa1Bird();
                break;
            // 노아 궁금한 사람
            case 48:
                isAddIanHeart = false;
                DailyRoutine.Instance.ParkNoa3CuriosityPeople();
                break;
            // 노아 바보 같은 사람
            case 49:
                isAddIanHeart = true;
                DailyRoutine.Instance.ParkNoa3StupidPeople();
                break;
            // 아스틴 같이 찾는다
            case 51:
                isAddIanHeart = true;
                DailyRoutine.Instance.ParkAustin2TogetherFind();
                break;
            // 아스틴 어미새를 쫓는다
            case 52:
                isAddIanHeart = false;
                DailyRoutine.Instance.ParkAustin2Chasing();
                break;
            // 아스틴 친구라고 한다
            case 54:
                isAddIanHeart = false;
                DailyRoutine.Instance.ParkAustin3Friend();
                break;
            // 아스틴 대답하지 않는다
            case 55:
                isAddIanHeart = true;
                DailyRoutine.Instance.ParkAustin3Stay();
                break;
            #endregion
            #region 해변
            // 이안 별을 보러 이동한다
            case 57:
                isAddIanHeart = true;
                DailyRoutine.Instance.BeachIan2LookStar();
                break;
            // 이안 별이 잘 보이는 장소로 안내한다
            case 58:
                isAddIanHeart = false;
                DailyRoutine.Instance.BeachIan2GuideStar();
                break;
            // 노아 내일부터 보낸다고 한다
            case 60:
                isAddIanHeart = false;
                DailyRoutine.Instance.BeachNoa2TomorrowSend();
                break;
            // 노아 생각날 때 보낸다고 한다
            case 61:
                isAddIanHeart = true;
                DailyRoutine.Instance.BeachNoa2ThinkSend();
                break;
            // 아스틴 자는 척한다
            case 63:
                isAddIanHeart = false;
                DailyRoutine.Instance.BeachAustin2Sleep();
                break;
            // 아스틴 눈을 뜬다
            case 64:
                isAddIanHeart = true;
                DailyRoutine.Instance.BeachAustin2OpenEye();
                break;
            // 노아 화낸다
            case 66:
                isAddIanHeart = true;
                DailyRoutine.Instance.GalleryNoa2Anger();
                break;
            // 노아 봐준다
            case 67:
                isAddIanHeart = false;
                DailyRoutine.Instance.GalleryNoa2Ignore();
                break;
            // 아스틴 슬쩍 빠져나온다
            case 69:
                isAddIanHeart = true;
                DailyRoutine.Instance.GalleryAustin1ComingOut();
                break;
            // 아스틴 놓아줄 때까지 즐긴다
            case 70:
                isAddIanHeart = false;
                DailyRoutine.Instance.GalleryAustin1Enjoy();
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
