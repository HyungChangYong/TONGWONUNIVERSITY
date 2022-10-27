using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = System.Random;
using TMPro;
using Object = UnityEngine.Object;

public class DailyRoutine : MonoBehaviour
{
    public static DailyRoutine Instance;

    [SerializeField] private Image placeUI;
    [SerializeField] private Image fadeImage;
    [SerializeField] private Image placeInfoImage;

    [SerializeField] private Sprite[] placeUISprite;
    [SerializeField] private Sprite[] placeInfoSprite;
 
    [SerializeField] private GameObject worldUIGo;
    [SerializeField] private GameObject placeUIGo;
    
    [SerializeField] private bool[] isFirst;

    // 0 이안 첫만남, 1 노아 첫만남, 2 아스틴 첫만남, 3 아무도 없음, 4 타운 이안 호감도 낮음 1
    public AudioClip[] placeBgmClips;
    [SerializeField] private AudioClip sceneChangeAudio;
    
    
    [SerializeField] private TextMeshProUGUI placeConversation;
    [SerializeField] private TextMeshProUGUI placeCharterName;
    [SerializeField] private Image placeCharterImage;
    [SerializeField] private Image placeWindow;
    [SerializeField] private Animator placeCharterAnimator;
    [SerializeField] private Animator placeTxtBtnAnimator;
    [SerializeField] private GameObject placeTxtBtnImageGo;
    [SerializeField] private GameObject placeTxtBoxLineGo;
    [SerializeField] private Image placeTxtBtnImage;
    
    
    

    private float _time;
    private float _currentFadeTime = 1;
    private readonly WaitForSeconds _yieldViewDelay = new WaitForSeconds(0.1f);
    
    private int _maxRanFirst;

    private bool _secondCharacter;
    private bool _isFirst;

    // 0 이안, 1 노아, 2 아스틴
    private int _whoCharacterNum;

    private int _ranDialogueNum;

    // 0 공작가, 1 후작가, 2 신전, 3 공원, 4 번화가, 5 해변, 6 레스토랑, 7 미술관
    private int _placeNum;
    
    private AudioClip _placeBgm;

    private Sprite _placeUISprite;

    private Dialogue _dialogue;

    private string _situationCaseName;

    private bool _isFriendliness;

    private void Awake()
    {
        Instance = this;
    }

    public void StartFadePlace(int num)
    {
        _placeNum = num;

        placeInfoImage.sprite = placeInfoSprite[num];
        
        // 캐릭터 등장 확률 체크 
        CheckSpawnCharacter();
        
        SettingUI.Instance.SettingSfxSound(sceneChangeAudio);
        
        StartCoroutine(FadePlaceCoroutine());
    }

    private void CheckSpawnCharacter()
    {
        // 특정 캐릭과 첫 만남을 가지지 않았다면
        if (isFirst[0].Equals(false) || isFirst[1].Equals(false) || isFirst[2].Equals(false))
        {
            _isFirst = true;
            
            _maxRanFirst = 0;
            
            for (int i = 0; i < isFirst.Length; i++)
            {
                if (isFirst[i].Equals(false))
                {
                    _maxRanFirst += 1;
                }
            }
            
            int ranCharacter = UnityEngine.Random.Range(0, _maxRanFirst);

            // 첫 만남을 가지지 못한 캐릭터가 1명
            if (_maxRanFirst == 1)
            {
                for (int i = 0; i < isFirst.Length; i++)
                {
                    if (isFirst[i].Equals(false))
                    {
                        _whoCharacterNum = i;
                        isFirst[i] = true;
                    }
                }
            }
            // 첫 만남을 가지지 못한 캐릭터가 2명
            else if (_maxRanFirst == 2)
            {
                for (int i = 0; i < isFirst.Length; i++)
                {
                    if (ranCharacter == 0)
                    {
                        if (isFirst[i].Equals(false))
                        {
                            _whoCharacterNum = i;
                            isFirst[i] = true;
                            break;
                        }
                    }
                    else if (ranCharacter == 1)
                    {
                        if (isFirst[i].Equals(false))
                        {
                            if (_secondCharacter.Equals(true))
                            {
                                _whoCharacterNum = i;
                                isFirst[i] = true;
                            }
                            
                            _secondCharacter = true;
                        }
                    }
                }
            }
            // 첫 만남을 가지지 못한 캐릭터가 3명
            else if (_maxRanFirst == 3)
            {
                _whoCharacterNum = ranCharacter;
                isFirst[ranCharacter] = true;
            }
            
            SettingBasePlace();
            
            _secondCharacter = false;
        }
        // 모든 캐릭터와 첫 만남을 가졌다면
        else
        {
            _isFirst = false;

            SettingBasePlace();
        }
    }

    private void SettingBasePlace()
    {
        _placeUISprite = placeUISprite[_placeNum];
        
        // 첫 만남 실행 
        if (_isFirst.Equals(true))
        {
            // 이안 
            if (_whoCharacterNum == 0)
            {
                SettingSituationCaseDialogue(0, DialogueTxt.Instance.firstIanDialogue, "FirstIan", 0);
            }
            // 노아
            else if (_whoCharacterNum == 1)
            {
                SettingSituationCaseDialogue(1, DialogueTxt.Instance.firstNoaDialogue, "FirstNoa", 0);
            }
            // 아스틴
            else if (_whoCharacterNum == 2)
            {
                SettingSituationCaseDialogue(2, DialogueTxt.Instance.firstAustinDialogue, "FirstAustin", 0);
            }
        }
        // 첫 만남을 모두 가졌다면
        else
        {
            // 토요일 확률 체크
            if (LobbyManager.Instance.isSaturday.Equals(true))
            {
                // 남자 주인공 집일 경우
                if (_placeNum == 0 || _placeNum == 1 || _placeNum == 2)
                {
                    
                }
                // 남자 주인공 집이 아닐 경우
                else
                {
                    SettingSituationCase();
                }
            }
            // 평일 확률 체크
            else
            {
                // 남자 주인공 집일 경우
                if (_placeNum == 0 || _placeNum == 1 || _placeNum == 2)
                {
                    
                }
                // 남자 주인공 집이 아닐 경우
                else
                {
                    int characterAppearanceRate = UnityEngine.Random.Range(1, 101);

                    // 20% 확률로 아무도 없음
                    if (characterAppearanceRate <= 20)
                    {
                        SettingSituationCaseDialogue(3, DialogueTxt.Instance.nobodyElseDialogue, "NobodyElse", 1);
                    }
                    // 80% 확률로 캐릭터 등장
                    else
                    {
                        SettingSituationCase();
                    }
                }
            }
            
        }
    }

    public void SettingSituationCaseDialogue(int placeBgmNum, Dialogue dialogue, string situationCaseName, int countNum)
    {
        // 전용 bgm
        _placeBgm = placeBgmClips[placeBgmNum];
        
        _dialogue = dialogue;
                        
        // 상황
        _situationCaseName = situationCaseName;
                        
        // 대화를 시작할 인덱스
        DialogueManager.Instance.count = countNum;
        
        if (dialogue.charterImages[0].name.Contains("Girl").Equals(true))
        {
            placeCharterName.text = PlayerPrefs.GetString("PlayerName");
        }
        else if (dialogue.charterImages[0].name.Contains("IAN").Equals(true))
        {
            placeCharterName.text = "이안 칼릭스";
        }
        else if (dialogue.charterImages[0].name.Contains("NOA").Equals(true))
        {
            placeCharterName.text = "노아 셀베스틴";
        }
        else if (dialogue.charterImages[0].name.Contains("ASUTIN_Dark").Equals(true))
        {
            placeCharterName.text = "???";
        }
        else if (dialogue.charterImages[0].name.Contains("ASUTIN").Equals(true))
        {
            placeCharterName.text = "아스틴";
        }
        else
        {
            placeCharterName.text = "";
        }
        
        placeCharterImage.sprite = dialogue.charterImages[0];
        placeWindow.sprite = dialogue.dialogueWindows[0];
    }

    private void SettingSituationCase()
    {
        _whoCharacterNum = UnityEngine.Random.Range(0, 3);

        // 특정 캐릭터 호감도 높음
        if (LobbyManager.Instance.nowHeart[_whoCharacterNum + 1] >= 25)
        {
            _isFriendliness = true;
        }
        // 특정 캐릭터 호감도 낮음
        else
        {
            _isFriendliness = false;
        }

        // 장소에 땨른 상황 세팅
        switch (_placeNum)
        {
            #region 공원
            case 3:
                // 호감도 낮음 경우
                if (_isFriendliness.Equals(false))
                {
                    _ranDialogueNum = UnityEngine.Random.Range(0, 2);

                    // 이안 
                    if (_whoCharacterNum == 0)
                    {
                        // 랜덤 첫번째 대사 출력
                        if (_ranDialogueNum == 0)
                        {
                            // parkIan1Dialogue
                            SettingSituationCaseDialogue(20, DialogueTxt.Instance.parkIan1Dialogue, "ParkIan1", 1);
                        }
                        // 랜덤 두번쨰 대사 출력
                        else if (_ranDialogueNum == 1)
                        {
                            SettingSituationCaseDialogue(9, DialogueTxt.Instance.parkIan2Dialogue, "ParkIan2", 0);
                        }
                    }
                    // 노아
                    else if (_whoCharacterNum == 1)
                    {
                        // 랜덤 첫번째 대사 출력
                        if (_ranDialogueNum == 0)
                        {
                            SettingSituationCaseDialogue(9, DialogueTxt.Instance.parkNoa1Dialogue, "ParkNoa1", 0);
                        }
                        // 랜덤 두번쨰 대사 출력
                        else if (_ranDialogueNum == 1)
                        {
                            SettingSituationCaseDialogue(6, DialogueTxt.Instance.parkNoa2Dialogue, "ParkNoa2", 0);
                        }
                    }
                    // 아스틴 
                    else if (_whoCharacterNum == 2)
                    {
                        // 랜덤 첫번째 대사 출력
                        if (_ranDialogueNum == 0)
                        {
                            SettingSituationCaseDialogue(25, DialogueTxt.Instance.parkAustin1Dialogue, "ParkAustin1", 1);
                        }
                        // 랜덤 두번쨰 대사 출력
                        else if (_ranDialogueNum == 1)
                        {
                            SettingSituationCaseDialogue(26, DialogueTxt.Instance.parkAustin2Dialogue, "ParkAustin2", 0);
                        }
                    }
                }
                else
                {
                    // 이안 
                    if (_whoCharacterNum == 0)
                    {
                        _ranDialogueNum = UnityEngine.Random.Range(0, 3);
                        
                        // 랜덤 첫번째 대사 출력
                        if (_ranDialogueNum == 0)
                        {
                            SettingSituationCaseDialogue(21, DialogueTxt.Instance.parkIan3Dialogue, "ParkIan3", 0);
                        }
                        // 랜덤 두번쨰 대사 출력
                        else if (_ranDialogueNum == 1)
                        {
                            _placeUISprite = placeUISprite[15];
                                 
                            SettingSituationCaseDialogue(22, DialogueTxt.Instance.parkIan4Dialogue, "ParkIan4", 0);
                        }
                        // 랜점 세번째 대사 출력
                        else if (_ranDialogueNum == 2)
                        {
                            SettingSituationCaseDialogue(23, DialogueTxt.Instance.parkIan5Dialogue, "ParkIan5", 1);
                        }
                    }
                    // 노아
                    else if (_whoCharacterNum == 1)
                    {
                        SettingSituationCaseDialogue(24, DialogueTxt.Instance.parkNoa3Dialogue, "ParkNoa3", 0);
                    }
                    // 아스틴
                    else if (_whoCharacterNum == 2)
                    {
                        SettingSituationCaseDialogue(22, DialogueTxt.Instance.parkAustin3Dialogue, "ParkAustin3", 0);
                    }
                }
                break;
            #endregion
            # region 번화가
            case 4:
                _ranDialogueNum = UnityEngine.Random.Range(0, 2);
                
                // 호감도 낮음 경우
                if (_isFriendliness.Equals(false))
                {
                    // 이안 
                    if (_whoCharacterNum == 0)
                    {
                        // 랜덤 첫번째 대사 출력
                        if (_ranDialogueNum == 0)
                        {
                            SettingSituationCaseDialogue(4, DialogueTxt.Instance.townIan1Dialogue, "TownIan1", 0);
                        }
                        // 랜덤 두번쨰 대사 출력
                        else if (_ranDialogueNum == 1)
                        {
                            SettingSituationCaseDialogue(5, DialogueTxt.Instance.townIan2Dialogue, "TownIan2", 0);
                        }
                    }
                    // 노아
                    else if (_whoCharacterNum == 1)
                    {
                        // 랜덤 첫번째 대사 출력
                        if (_ranDialogueNum == 0)
                        {
                            _placeUISprite = placeUISprite[11];
                            
                            SettingSituationCaseDialogue(1, DialogueTxt.Instance.townNoa1Dialogue, "TownNoa1", 0);
                        }
                        // 랜덤 두번쨰 대사 출력
                        else if (_ranDialogueNum == 1)
                        {
                            SettingSituationCaseDialogue(8, DialogueTxt.Instance.townNoa2Dialogue, "TownNoa2", 0);
                        }
                    }
                    // 아스틴 
                    else if (_whoCharacterNum == 2)
                    {
                        // 랜덤 첫번째 대사 출력
                        if (_ranDialogueNum == 0)
                        {
                            _placeUISprite = placeUISprite[13];

                            SettingSituationCaseDialogue(10, DialogueTxt.Instance.townAustin1Dialogue, "TownAustin1", 1);
                        }
                        // 랜덤 두번쨰 대사 출력
                        else if (_ranDialogueNum == 1)
                        {
                            SettingSituationCaseDialogue(12, DialogueTxt.Instance.townAustin3Dialogue, "TownAustin3", 0);
                        }
                    }
                }
                // 호감도 높을 경우
                else
                {
                    // 이안 
                    if (_whoCharacterNum == 0)
                    {
                        // 랜덤 첫번째 대사 출력
                        if (_ranDialogueNum == 0)
                        {
                            _placeUISprite = placeUISprite[8];
                            
                            SettingSituationCaseDialogue(5, DialogueTxt.Instance.townIan3Dialogue, "TownIan3", 0);
                        }
                        // 랜덤 두번쨰 대사 출력
                        else if (_ranDialogueNum == 1)
                        {
                            _placeUISprite = placeUISprite[9];
                            
                            SettingSituationCaseDialogue(6, DialogueTxt.Instance.townIan4Dialogue, "TownIan4", 0);
                        }
                    }
                    // 노아
                    else if (_whoCharacterNum == 1)
                    {
                        // 랜덤 첫번째 대사 출력
                        if (_ranDialogueNum == 0)
                        {
                            SettingSituationCaseDialogue(9, DialogueTxt.Instance.townNoa3Dialogue, "TownNoa3", 0);
                        }
                        // 랜덤 두번쨰 대사 출력
                        else if (_ranDialogueNum == 1)
                        {
                            SettingSituationCaseDialogue(6, DialogueTxt.Instance.townNoa4Dialogue, "TownNoa4", 0);
                        }
                    }
                    // 아스틴 
                    else if (_whoCharacterNum == 2)
                    {
                        // 랜덤 첫번째 대사 출력
                        if (_ranDialogueNum == 0)
                        {
                            _placeUISprite = placeUISprite[14];
                            
                            SettingSituationCaseDialogue(11, DialogueTxt.Instance.townAustin2Dialogue, "TownAustin2", 0);
                        }
                        // 랜덤 두번쨰 대사 출력
                        else if (_ranDialogueNum == 1)
                        {
                            SettingSituationCaseDialogue(13, DialogueTxt.Instance.townAustin4Dialogue, "TownAustin4", 0);
                        }
                    }
                }
                break;
            # endregion
            #region 해변
            case 5:
                // 호감도 낮음 경우
                if (_isFriendliness.Equals(false))
                {
                    // 이안 
                    if (_whoCharacterNum == 0)
                    {
                        SettingSituationCaseDialogue(27, DialogueTxt.Instance.beachIan1Dialogue, "BeachIan1", 0);
                    }
                    // 노아
                    else if (_whoCharacterNum == 1)
                    {
                        _placeUISprite = placeUISprite[17];
                        
                        SettingSituationCaseDialogue(6, DialogueTxt.Instance.beachNoa1Dialogue, "BeachNoa1", 0);
                    }
                    // 아스틴 
                    else if (_whoCharacterNum == 2)
                    {
                        SettingSituationCaseDialogue(29, DialogueTxt.Instance.beachAustin1Dialogue, "BeachAustin1", 0);
                    }
                }
                else
                {
                    // 이안 
                    if (_whoCharacterNum == 0)
                    {
                        _placeUISprite = placeUISprite[16];
                        
                        SettingSituationCaseDialogue(28, DialogueTxt.Instance.beachIan2Dialogue, "BeachIan2", 0);
                    }
                    // 노아
                    else if (_whoCharacterNum == 1)
                    {
                        _placeUISprite = placeUISprite[19];
                        
                        SettingSituationCaseDialogue(28, DialogueTxt.Instance.beachNoa2Dialogue, "BeachNoa2", 0);
                    }
                    // 아스틴
                    else if (_whoCharacterNum == 2)
                    {
                        _placeUISprite = placeUISprite[19];
                        
                        SettingSituationCaseDialogue(30, DialogueTxt.Instance.beachAustin2Dialogue, "BeachAustin2", 0);
                    }
                }
                break;
            #endregion
            # region 레스토랑
            case 6:
                // 호감도 낮음 경우
                if (_isFriendliness.Equals(false))
                {
                    // 이안 
                    if (_whoCharacterNum == 0)
                    {
                        SettingSituationCaseDialogue(17, DialogueTxt.Instance.restaurantIan1Dialogue, "RestaurantIan1", 0);
                    }
                    // 노아
                    else if (_whoCharacterNum == 1)
                    { 
                        _ranDialogueNum = UnityEngine.Random.Range(0, 2);
                        
                        // 랜덤 첫번째 대사 출력
                        if (_ranDialogueNum == 0)
                        {
                            SettingSituationCaseDialogue(18, DialogueTxt.Instance.restaurantNoa1Dialogue, "RestaurantNoa1", 0);
                        }
                        // 랜덤 두번쨰 대사 출력
                        else if (_ranDialogueNum == 1)
                        {
                            SettingSituationCaseDialogue(5, DialogueTxt.Instance.restaurantNoa2Dialogue, "RestaurantNoa2", 0);
                        }
                    }
                    // 아스틴 
                    else if (_whoCharacterNum == 2)
                    {
                        SettingSituationCaseDialogue(5, DialogueTxt.Instance.restaurantAustin1Dialogue, "RestaurantAustin1", 0);
                    }
                }
                // 호감도 높을 경우
                else
                {
                    // 이안 
                    if (_whoCharacterNum == 0)
                    {
                        SettingSituationCaseDialogue(16, DialogueTxt.Instance.restaurantIan2Dialogue, "RestaurantIan2", 0);
                    }
                    // 노아
                    else if (_whoCharacterNum == 1)
                    {
                        SettingSituationCaseDialogue(6, DialogueTxt.Instance.restaurantNoa3Dialogue, "RestaurantNoa3", 0);
                    }
                    // 아스틴 
                    else if (_whoCharacterNum == 2)
                    {
                        _placeUISprite = placeUISprite[4];
                        
                        SettingSituationCaseDialogue(19, DialogueTxt.Instance.restaurantAustin2Dialogue, "RestaurantAustin2", 0);
                    }
                }
                break;
            # endregion
            #region 미술관
            case 7:
                // 호감도 낮음 경우
                if (_isFriendliness.Equals(false))
                {
                    // 이안 
                    if (_whoCharacterNum == 0)
                    {
                        SettingSituationCaseDialogue(31, DialogueTxt.Instance.galleryIan1Dialogue, "GalleryIan1", 0);
                    }
                    // 노아
                    else if (_whoCharacterNum == 1)
                    {
                        SettingSituationCaseDialogue(35, DialogueTxt.Instance.galleryNoa1Dialogue, "GalleryNoa1", 0);
                    }
                    // 아스틴 
                    else if (_whoCharacterNum == 2)
                    {
                        _placeUISprite = placeUISprite[20];
                      
                        SettingSituationCaseDialogue(32, DialogueTxt.Instance.galleryAustin1Dialogue, "GalleryAustin1", 0);
                    }
                }
                else
                {
                    // 이안 
                    if (_whoCharacterNum == 0)
                    {
                        SettingSituationCaseDialogue(31, DialogueTxt.Instance.galleryIan1Dialogue, "GalleryIan1", 0);
                    }
                    // 노아
                    else if (_whoCharacterNum == 1)
                    {
                        SettingSituationCaseDialogue(33, DialogueTxt.Instance.galleryNoa2Dialogue, "GalleryNoa2", 1);
                    }
                    // 아스틴
                    else if (_whoCharacterNum == 2)
                    {
                        SettingSituationCaseDialogue(34, DialogueTxt.Instance.galleryAustin2Dialogue, "GalleryAustin2", 0);
                    }
                }
                break;
            #endregion
        }
    }

    private IEnumerator FadePlaceCoroutine()
    {
        fadeImage.gameObject.SetActive(true);
        
        _time = 0f;
        
        Color alpha = fadeImage.color;
        
        while (alpha.a < 1f)
        {
            _time += Time.deltaTime / _currentFadeTime;
            
            alpha.a = Mathf.Lerp(0, 1, _time);
            
            fadeImage.color = alpha;
            
            yield return null;
        }
        _time = 0f;
        
        yield return _yieldViewDelay;
        
        while (alpha.a > 0f)
        {
            _time += Time.deltaTime / _currentFadeTime;
            
            alpha.a = Mathf.Lerp(1, 0, _time);
            
            fadeImage.color = alpha;
            
            worldUIGo.SetActive(false);
            placeUI.sprite = _placeUISprite;
            placeUIGo.SetActive(true);

            yield return null;
        }
        
        SettingPlaceBgmSound();
        
        fadeImage.gameObject.SetActive(false);

        SettingPlaceDialogue();
        
        DialogueManager.Instance.SettingTxtBox();
        
        yield return null;
    }

    public void SettingPlaceBgmSound()
    {
        SettingUI.Instance.SettingBgmSound(_placeBgm);
    }

    public void SettingPlaceDialogue()
    {
        DialogueManager.Instance.ShowDialogue(_dialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }

    public void SettingPlaceImage(int num)
    {
        _placeUISprite = placeUISprite[num];
        placeUI.sprite = _placeUISprite;
    }
    
    public void NextPlaceBtn()
    {
        DialogueManager.Instance.NextBtn(_situationCaseName);
    }

    public void TownIan2Fun()
    {
        _situationCaseName = "TownIan2Fun";
        
        placeTxtBoxLineGo.SetActive(true);
            
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.townIan2FunDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void TownIan2Tiresome()
    {
        _situationCaseName = "TownIan2Tiresome";
        
        placeTxtBoxLineGo.SetActive(true);
            
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.townIan2TiresomeDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void TownIan2Select()
    {
        _situationCaseName = "TownIan2Select";
        
        placeTxtBoxLineGo.SetActive(true);
            
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.townIan2SelectDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }

    public void TownIan3Ignore()
    {
        _situationCaseName = "TownIan3Ignore";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.townIan3IgnoreDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void TownIan3Hi()
    {
        _situationCaseName = "TownIan3Hi";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.townIan3HiDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }

    public void TownNoa1Mistake()
    {
        _situationCaseName = "TownNoa1Mistake";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.townNoa1MistakeDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void TownNoa1Stand()
    {
        _situationCaseName = "TownNoa1Stand";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.townNoa1StandDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void TownNoa1Select()
    {
        _situationCaseName = "TownNoa1Select";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.townNoa1SelectDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void TownNoa4Cheer()
    {
        _situationCaseName = "TownNoa4Cheer";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.townNoa4CheerDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }

    public void TownNoa4Question()
    {
        _situationCaseName = "TownNoa4Question";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.townNoa4QuestionDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }

    public void TownNoa4Select()
    {
        _situationCaseName = "TownNoa4Select";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.townNoa4SelectDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void TownAustin2FireFestival()
    {
        _situationCaseName = "TownAustin2FireFestival";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.townAustin2FireFestivalDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void TownAustin2Around()
    {
        _situationCaseName = "TownAustin2Around";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.townAustin2AroundDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void RestaurantIan1EatWell()
    {
        _situationCaseName = "RestaurantIan1EatWell";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.restaurantIan1EatWellDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void RestaurantIan1QuestionEat()
    {
        _situationCaseName = "RestaurantIan1QuestionEat";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.restaurantIan1QuestionEatDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void RestaurantNoa2Good()
    {
        _situationCaseName = "RestaurantNoa2Good";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.restaurantNoa2GoodDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void RestaurantNoa2Perfect()
    {
        _situationCaseName = "RestaurantNoa2Perfect";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.restaurantNoa2PerfectDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void RestaurantNoa2Select()
    {
        _situationCaseName = "RestaurantNoa2Select";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.restaurantNoa2SelectDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void RestaurantAustin2Copy()
    {
        _situationCaseName = "RestaurantAustin2Copy";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.restaurantAustin2CopyDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void RestaurantAustin2Wait()
    {
        _situationCaseName = "RestaurantAustin2Wait";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.restaurantAustin2WaitDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void RestaurantAustin2Select()
    {
        _situationCaseName = "RestaurantAustin2Select";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.restaurantAustin2SelectDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void ParkIan1Plants()
    {
        _situationCaseName = "ParkIan1Plants";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.parkIan1PlantsDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void ParkIan1NightSky()
    {
        _situationCaseName = "ParkIan1NightSky";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.parkIan1NightSkyDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void ParkIan3Exercise()
    {
        _situationCaseName = "ParkIan3Exercise";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.parkIan3ExerciseDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void ParkIan3Walk()
    {
        _situationCaseName = "ParkIan3Walk";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.parkIan3WalkDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void ParkIan5LookFlower()
    {
        _situationCaseName = "ParkIan5LookFlower";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.parkIan5LookFlowerDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void ParkIan5Rest()
    {
        _situationCaseName = "ParkIan5Rest";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.parkIan5RestDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void ParkNoa1Dog()
    {
        _situationCaseName = "ParkNoa1Dog";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.parkNoa1DogDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void ParkNoa1Bird()
    {
        _situationCaseName = "ParkNoa1Bird";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.parkNoa1BirdDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void ParkNoa1Select()
    {
        _situationCaseName = "ParkNoa1Select";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.parkNoa1SelectDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void ParkNoa3CuriosityPeople()
    {
        _situationCaseName = "ParkNoa3CuriosityPeople";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.parkNoa3CuriosityPeopleDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void ParkNoa3StupidPeople()
    {
        _situationCaseName = "ParkNoa3StupidPeople";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.parkNoa3StupidPeopleDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void ParkNoa3Select()
    {
        _situationCaseName = "ParkNoa3Select";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.parkNoa3SelectDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void ParkAustin2TogetherFind()
    {
        _situationCaseName = "ParkAustin2TogetherFind";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.parkAustin2TogetherFindDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void ParkAustin2Chasing()
    {
        _situationCaseName = "ParkAustin2Chasing";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.parkAustin2ChasingDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void ParkAustin3Friend()
    {
        _situationCaseName = "ParkAustin3Friend";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.parkAustin3FriendDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void ParkAustin3Stay()
    {
        _situationCaseName = "ParkAustin3Stay";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.parkAustin3StayDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void ParkAustin3Select()
    {
        _situationCaseName = "ParkAustin3Select";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.parkAustin3SelectDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void BeachIan2LookStar()
    {
        _situationCaseName = "BeachIan2LookStar";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.beachIan2LookStarDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void BeachIan2GuideStar()
    {
        _situationCaseName = "BeachIan2GuideStar";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.beachIan2GuideStarDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void BeachIan2Select()
    {
        _situationCaseName = "BeachIan2Select";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.beachIan2SelectDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void BeachNoa2TomorrowSend()
    {
        _situationCaseName = "BeachNoa2TomorrowSend";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.beachNoa2TomorrowSendDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void BeachNoa2ThinkSend()
    {
        _situationCaseName = "BeachNoa2ThinkSend";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.beachNoa2ThinkSendDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }

    public void BeachNoa2Select()
    {
        _situationCaseName = "BeachNoa2Select";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.beachNoa2SelectDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void BeachAustin2Sleep()
    {
        _situationCaseName = "BeachAustin2Sleep";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.beachAustin2SleepDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
   
    public void BeachAustin2OpenEye()
    {
        _situationCaseName = "BeachAustin2OpenEye";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.beachAustin2OpenEyeDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void BeachAustin2Select()
    {
        _situationCaseName = "BeachAustin2Select";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.beachAustin2SelectDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void GalleryNoa2Anger()
    {
        _situationCaseName = "GalleryNoa2Anger";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.galleryNoa2AngerDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void GalleryNoa2Ignore()
    {
        _situationCaseName = "GalleryNoa2Ignore";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.galleryNoa2IgnoreDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }

    public void GalleryNoa2Select()
    {
        _situationCaseName = "GalleryNoa2Select";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.galleryNoa2SelectDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void GalleryAustin1ComingOut()
    {
        _situationCaseName = "GalleryAustin1ComingOut";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.galleryAustin1ComingOutDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
    
    public void GalleryAustin1Enjoy()
    {
        _situationCaseName = "GalleryAustin1Enjoy";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 1;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.galleryAustin1EnjoyDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }

    public void GalleryAustin1Select()
    {
        _situationCaseName = "GalleryAustin1Select";
        
        placeTxtBoxLineGo.SetActive(true);
        
        DialogueManager.Instance.count = 0;
        DialogueManager.Instance.ShowDialogue(DialogueTxt.Instance.galleryAustin1SelectDialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
    }
}
