using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{
    public static ChoiceManager Instance;

    [SerializeField] private Image selectCharacterUI;

    [SerializeField] private Sprite[] selectCharacterSprite;
    
    [SerializeField] private AudioClip clickAudio;
    [SerializeField] private AudioClip select2Audio;

    [SerializeField] private GameObject selectCharacterUIGo;
    [SerializeField] private GameObject guideBackImageGo;
    [SerializeField] private GameObject choiceObjectUI;
    [SerializeField] private GameObject[] choiceCountGo;
    [SerializeField] private GameObject[] choiceBackImageGo;
    [SerializeField] private GameObject[] choiceSixBackImageGo;
    
    [SerializeField] private string[] choiceTxtInfo;

    [SerializeField] private TextMeshProUGUI[] choiceTxt;
    [SerializeField] private TextMeshProUGUI[] choiceTxtFive;
    [SerializeField] private TextMeshProUGUI[] choiceTxtSix;
    
    [SerializeField] private int[] choiceTxtNums;
    [SerializeField] private int[] choiceTxtFiveNums;
    [SerializeField] private int[] choiceTxtSixNums;
    
    public int choiceNum;
    
    public bool isAddIanHeart;

    private bool _isFiveChoice;
    private bool _isSixChoice;

    public int event3WhoNum;
    public int event4WhoNum;

    public bool isSelectEvent3;

    private void Awake()
    {
        Instance = this;
    }

    public void HideSelectCharacterUI()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);

        selectCharacterUIGo.SetActive(false);
    }

    public void SelectCharacterUIYes()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);
        
        selectCharacterUIGo.SetActive(false);
        
        CallSituation();

        isSelectEvent3 = false;
    }

    public void SelectChoice(int num)
    {
        SettingUI.Instance.SettingSfxSound(select2Audio);

        if (_isFiveChoice.Equals(false) && _isSixChoice.Equals(false))
        {
            choiceNum = choiceTxtNums[num];

            if (isSelectEvent3.Equals(false))
            {
                CallSituation();
            }
            else
            {
                switch (choiceNum)
                {
                    case 96:
                        event3WhoNum = 1;
                        selectCharacterUI.sprite = selectCharacterSprite[0];
                        selectCharacterUIGo.SetActive(true);
                        break;
                    case 97:
                        event3WhoNum = 2;
                        selectCharacterUI.sprite = selectCharacterSprite[1];
                        selectCharacterUIGo.SetActive(true);
                        break;
                    case 98:
                        event3WhoNum = 3;
                        selectCharacterUI.sprite = selectCharacterSprite[2];
                        selectCharacterUIGo.SetActive(true);
                        break;
                    case 108:
                        event4WhoNum = 1;
                        selectCharacterUI.sprite = selectCharacterSprite[3];
                        selectCharacterUIGo.SetActive(true);
                        break;
                    case 109:
                        event4WhoNum = 2;
                        selectCharacterUI.sprite = selectCharacterSprite[4];
                        selectCharacterUIGo.SetActive(true);
                        break;
                    case 110:
                        event4WhoNum = 3;
                        selectCharacterUI.sprite = selectCharacterSprite[5];
                        selectCharacterUIGo.SetActive(true);
                        break;
                }
            }
        }
        else if (_isFiveChoice.Equals(true))
        {
            choiceNum = choiceTxtFiveNums[num];

            if (num == 4)
            {
                if (LobbyManager.Instance.nowHeart[0] >= 12)
                {
                    LobbyManager.Instance.nowHeart[0] -= 12;
                    
                    CallSituation();
                }
                else
                {
                    guideBackImageGo.SetActive(true);
                }
            }
            else
            {
                CallSituation();
            }
        }
        else if (_isSixChoice.Equals(true))
        {
            choiceNum = choiceTxtSixNums[num];
            
            CallSituation();
        }
    }

    public void HideGuideBackImageGo()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);
        
        guideBackImageGo.SetActive(false);
    }

    private void CallSituation()
    {
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
            #endregion
            #region 미술관
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
            #region 공작가
            // 이안 대화하기 위해서
            case 72:
                isAddIanHeart = true;
                DailyRoutine.Instance.HomeIan1Talk();
                break;
            // 이안 공작저가 궁금해서
            case 73:
                isAddIanHeart = false;
                DailyRoutine.Instance.HomeIan1Curiosity();
                break;
            #endregion
            #region 후작가
            // 노아 협력을 요청드립니다
            case 75:
                isAddIanHeart = true;
                DailyRoutine.Instance.HomeNoa1Cooperation();
                break;
            // 노아 힘이 되어드리고 싶습니다
            case 76:
                isAddIanHeart = false;
                DailyRoutine.Instance.HomeNoa1Force();
                break;
            #endregion
            #region 신전
            // 아스틴 기도 내용을 말한다
            case 78:
                isAddIanHeart = false;
                DailyRoutine.Instance.HomeAustin1PrayerTalk();
                break;
            // 아스틴 기도 내용을 말하지 않는다
            case 79:
                isAddIanHeart = true;
                DailyRoutine.Instance.HomeAustin1NoPrayerTalk();
                break;
            // 아스틴 남성에게 돈을 던진다
            case 81:
                isAddIanHeart = true;
                DailyRoutine.Instance.HomeAustin2ThrowStone();
                break;
            // 아스틴 아스틴을 불러온다
            case 82:
                isAddIanHeart = false;
                DailyRoutine.Instance.HomeAustin2CallAustin();
                break;
            #endregion
            #region 이벤트1
            // 이벤트1 예절
            case 84:
                LobbyManager.Instance.Event1Manner();
                break;
            // 이벤트1 춤
            case 85:
                LobbyManager.Instance.Event1Dance();
                break;
            // 이벤트1 다도
            case 86:
                LobbyManager.Instance.Event1TeaCeremony();
                break;
            // 이벤트1 화술
            case 87:
                LobbyManager.Instance.Event1SpeakArt();
                break;
            // 이벤트1 검술
            case 88:
                LobbyManager.Instance.Event1SwardArt();
                break;
            #endregion
            #region 이벤트2
            // 이벤트2 무시하기
            case 90:
                LobbyManager.Instance.Event2Ignore();
                break;
            // 이벤트2 맞춰주기
            case 91:
                LobbyManager.Instance.Event2Right();
                break;
            // 이벤트2 반박하기
            case 92:
                LobbyManager.Instance.Event2Rebut();
                break;
            // 이벤트2 뺨 때리기
            case 93:
                LobbyManager.Instance.Event2HitCheek();
                break;
            // 이벤트2 와인 뿌리기
            case 94:
                LobbyManager.Instance.Event2WineSpray();
                break;
            // 이벤트2 울기
            case 95:
                LobbyManager.Instance.Event2Cry();
                break;
            // 아벤트2 공작 : 이안 칼릭스
            case 96:
                DialogueManager.Instance.SettingFadeInfoEvent();
                break;
            // 이벤트2 후작 : 노아 셀베스틴
            case 97:
                DialogueManager.Instance.SettingFadeInfoEvent();
                break;
            // 이벤트2 신관 : 아스틴
            case 98:
                DialogueManager.Instance.SettingFadeInfoEvent();
                break;
            #endregion
            #region 이벤트3
            // 이벤트3 우선 한 모금 마시며 공작을 기다린다
            case 99:
                isAddIanHeart = false;
                LobbyManager.Instance.Even3IanDrink();
                break;
            // 이벤트3 예법은 뒤로 한 채 잠깐 기다린다
            case 100:
                isAddIanHeart = true;
                LobbyManager.Instance.Even3IanWait();
                break;
            // 이벤트3 가만히 있는다
            case 102:
                isAddIanHeart = true;
                LobbyManager.Instance.Event3NoaStay();
                break;
            // 이벤트3 몸을 피한다
            case 103:
                isAddIanHeart = false;
                LobbyManager.Instance.Event3NoaAvoid();
                break;
            // 이벤트3 본인을 더 믿어 보는 건 어떨까요
            case 105:
                isAddIanHeart = true;
                LobbyManager.Instance.Event3AustinBelieve();
                break;
            // 이벤트3 잠깐 지나가는 바람일 거라 생각해요
            case 106:
                isAddIanHeart = false;
                LobbyManager.Instance.Event3AustinWind();
                break;
            // 이벤트3 꽃
            case 108:
                DialogueManager.Instance.SettingEvent3Next();
                break;
            // 이벤트3 고양이 
            case 109:
                DialogueManager.Instance.SettingEvent3Next();
                break;
            // 이벤트3 새
            case 110:
                DialogueManager.Instance.SettingEvent3Next();
                break;
            #endregion
            #region 이벤트4
            // 이벤트4 솔직히 털어놓는다
            case 111:
                isAddIanHeart = true;
                LobbyManager.Instance.Event4IanFrankly();
                break;
            // 이벤트4 애써 밝은 척 말한다
            case 112:
                isAddIanHeart = false;
                LobbyManager.Instance.Event4IanBright();
                break;
            // 이벤트4 괜찮다
            case 114:
                isAddIanHeart = true;
                LobbyManager.Instance.Event4NoaOkay();
                break;
            // 이벤트4 잘했다
            case 115:
                isAddIanHeart = false;
                LobbyManager.Instance.Event4NoaGood();
                break;
            // 이벤트4 농담을 던진다
            case 117:
                isAddIanHeart = true;
                LobbyManager.Instance.Event4AustinJoke();
                break;
            // 이벤트4 생각해본다
            case 118:
                isAddIanHeart = false;
                LobbyManager.Instance.Event4AustinThink();
                break;
            #endregion
            #region 엔딩
            // 엔딩 눈을 감는다
            case 120:
                DialogueManager.Instance.DelayGetMaximAlbum9();
                break;
            // 엔딩 문을 연다  
            case 123:
                DialogueManager.Instance.DelayGetMaximAlbum13();
                break;
            // 고개를 끄덕인다
            case 126:
                DialogueManager.Instance.DelayGetMaximAlbum11();
                break;
            #endregion
            
        }
    }
    
    public void ShowOneChoice(int num)
    {
        choiceObjectUI.SetActive(true);
        
        _isFiveChoice = false;
        _isSixChoice = false;
        
        for (int i = 0; i < choiceCountGo.Length; i++)
        {
            choiceCountGo[i].SetActive(false);
        }
        choiceCountGo[4].SetActive(true);
        
        choiceTxtNums[0] = num * 3;

        choiceTxt[5].text = choiceTxtInfo[num * 3];
    }

    public void ShowTwoChoice(int num)
    {
        choiceObjectUI.SetActive(true);
        
        _isFiveChoice = false;
        _isSixChoice = false;
        
        for (int i = 0; i < choiceCountGo.Length; i++)
        {
            choiceCountGo[i].SetActive(false);
        }
        choiceCountGo[0].SetActive(true);
        
        choiceTxtNums[0] = num * 3;
        choiceTxtNums[1] = num * 3 + 1;

        choiceTxt[0].text = choiceTxtInfo[num * 3];
        choiceTxt[1].text = choiceTxtInfo[num * 3 + 1];
    }

    public void ShowThreeChoice(int num)
    {
        choiceObjectUI.SetActive(true);
        
        _isFiveChoice = false;
        _isSixChoice = false;

        for (int i = 0; i < choiceCountGo.Length; i++)
        {
            choiceCountGo[i].SetActive(false);
        }
        choiceCountGo[1].SetActive(true);
        
        choiceTxtNums[2] = num * 3;
        choiceTxtNums[3] = num * 3 + 1;
        choiceTxtNums[4] = num * 3 + 2;
        
        choiceTxt[2].text = choiceTxtInfo[num * 3];
        choiceTxt[3].text = choiceTxtInfo[num * 3 + 1];
        choiceTxt[4].text = choiceTxtInfo[num * 3 + 2];
    }

    public void ShowFiveChoice(int num)
    {
        choiceObjectUI.SetActive(true);
        
        _isFiveChoice = true;
        
        for (int i = 0; i < choiceCountGo.Length; i++)
        {
            choiceCountGo[i].SetActive(false);
        }
        choiceCountGo[2].SetActive(true);
        
        choiceBackImageGo[0].SetActive(true);
        choiceBackImageGo[1].SetActive(false);

        for (int i = 0; i < choiceTxtFiveNums.Length; i++)
        {
            choiceTxtFiveNums[i] = num * 3 + i; 
            choiceTxtFive[i].text = choiceTxtInfo[num * 3 + i];
        }
    }
    
    public void ShowSixChoice(int num)
    {
        choiceObjectUI.SetActive(true);
        
        _isSixChoice = true;
        
        for (int i = 0; i < choiceCountGo.Length; i++)
        {
            choiceCountGo[i].SetActive(false);
        }
        choiceCountGo[3].SetActive(true);
        
        choiceSixBackImageGo[0].SetActive(true);
        choiceSixBackImageGo[1].SetActive(false);
        
        for (int i = 0; i < choiceTxtSixNums.Length; i++)
        {
            choiceTxtSixNums[i] = num * 3 + i; 
            choiceTxtSix[i].text = choiceTxtInfo[num * 3 + i];
        }
    }

    public void ClickNextBtn()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);

        if (_isFiveChoice.Equals(true))
        {
            choiceBackImageGo[1].SetActive(true);
            choiceBackImageGo[0].SetActive(false);
        }
        else if (_isSixChoice.Equals(true))
        {
            choiceSixBackImageGo[1].SetActive(true);
            choiceSixBackImageGo[0].SetActive(false);
        }
    }

    public void ClickBackBtn()
    {
        SettingUI.Instance.SettingSfxSound(clickAudio);

        if (_isFiveChoice.Equals(true))
        {
            choiceBackImageGo[0].SetActive(true);
            choiceBackImageGo[1].SetActive(false);
        }
        else if (_isSixChoice.Equals(true))
        {
            choiceSixBackImageGo[0].SetActive(true);
            choiceSixBackImageGo[1].SetActive(false);
        }
    }
}
