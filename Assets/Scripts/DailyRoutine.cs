using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = System.Random;
using TMPro;

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

    [SerializeField] private AudioClip[] placeBgmClips;
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

    // 0 공작가, 1 후작가, 2 신전, 3 공원, 4 번화가, 5 해변, 6 레스토랑, 7 미술관
    private int _placeNum;

    private AudioClip _placeBgm;

    private Sprite _placeUISprite;

    private Dialogue _dialogue;

    private string _situationCaseName;

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
        if (isFirst[0].Equals(false) && isFirst[1].Equals(false) && isFirst[2].Equals(false))
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
                        }
                    }
                    else if (ranCharacter == 1)
                    {
                        if (_secondCharacter.Equals(true))
                        {
                            if (isFirst[i].Equals(false))
                            {
                                _whoCharacterNum = i;
                                isFirst[i] = true;
                            }
                        }

                        _secondCharacter = true;
                    }
                }
            }
            // 첫 만남을 가지지 못한 캐릭터가 3명
            else if (_maxRanFirst == 3)
            {
                // 강제 이안 이벤트 실행
                ranCharacter = 0;
                
                
                
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
        }
    }

    private void SettingBasePlace()
    {
        // 첫 만남 실행 
        if (_isFirst.Equals(true))
        {
            _placeUISprite = placeUISprite[_placeNum];
            placeCharterName.text = "";

            // 이안 
            if (_whoCharacterNum == 0)
            {
                _placeBgm = placeBgmClips[0];

                _dialogue = DialogueTxt.Instance.firstIanDialogue;

                _situationCaseName = "FirstIan";

                placeCharterImage.sprite = DialogueTxt.Instance.firstIanDialogue.charterImages[0];
                placeWindow.sprite = DialogueTxt.Instance.firstIanDialogue.dialogueWindows[0];
            }
            // 노아
            else if (_whoCharacterNum == 1)
            {
                _placeBgm = placeBgmClips[1];
                
                _dialogue = DialogueTxt.Instance.firstNoaDialogue;
                
                _situationCaseName = "FirstNoa";
                
                placeCharterImage.sprite = DialogueTxt.Instance.firstNoaDialogue.charterImages[0];
                placeWindow.sprite = DialogueTxt.Instance.firstNoaDialogue.dialogueWindows[0];
            }
            // 아스틴
            else if (_whoCharacterNum == 2)
            {
                _placeBgm = placeBgmClips[2];
                
                _dialogue = DialogueTxt.Instance.firstAustinDialogue;
                
                _situationCaseName = "FirstAustin";
                
                placeCharterImage.sprite = DialogueTxt.Instance.firstAustinDialogue.charterImages[0];
                placeWindow.sprite = DialogueTxt.Instance.firstAustinDialogue.dialogueWindows[0];
            }
        }
        else
        {
            
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
        
        SettingUI.Instance.SettingBgmSound(_placeBgm);
        
        fadeImage.gameObject.SetActive(false);
        
        DialogueManager.Instance.ShowDialogue(_dialogue, _situationCaseName, placeConversation, placeCharterName, placeCharterImage, placeWindow, placeCharterAnimator, placeTxtBtnAnimator, placeTxtBtnImageGo, placeTxtBtnImage);
        
        DialogueManager.Instance.SettingTxtBox();
        
        yield return null;
    }
    
    public void NextPlaceBtn()
    {
        DialogueManager.Instance.NextBtn(_situationCaseName);
    }
}
