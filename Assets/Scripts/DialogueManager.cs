using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private float textDelay;

    public TextMeshProUGUI conversation;
    public Image openingCharterImage;
    // public Image dialogueWindow;

    private List<string> _listSentences;
    private List<Sprite> _listCharters;
    private List<Sprite> _listDialogueWindows;

    private int _count; // 대화 진행 상황 카운트

    public Animator drawAnimator;

    public bool isTalk = false;
    private bool _clickActivated = false;

    public AudioSource typeSound;
    public AudioSource enterSound;

    [SerializeField] private GameObject txtBtnImageGo;
    
    [SerializeField] private Image txtBtnImage;
    
    [SerializeField] private bool isTrue;
    
    // 가비지 콜렉터를 생성하지 않기 위한 변수
    private readonly WaitForSeconds _yieldViewDelay = new WaitForSeconds(2f);
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _count = 0;
        conversation.text = "";
        _listSentences = new List<string>();
        _listCharters = new List<Sprite>();
        _listDialogueWindows = new List<Sprite>();
    }

    public void ShowDialogue(Dialogue dialogue, bool isCharter)
    {
        isTalk = true;
        
        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            _listSentences.Add(dialogue.sentences[i]);
            _listCharters.Add(dialogue.charterImages[i]);
            _listDialogueWindows.Add(dialogue.dialogueWindows[i]);
        }

        StartCoroutine(StartDialogueCoroutine(isCharter));
    }

    public void ExitDialogue()
    {
        _count = 0;
        conversation.text = "";
        _listSentences.Clear();
        _listCharters.Clear();
        _listDialogueWindows.Clear();
        isTalk = false;
        
        // 추후 이부분 삭제
        conversation.text = "오프닝이 끝났습니다";
    }

    private IEnumerator StartDialogueCoroutine(bool isCharter)
    {
        if (_count > 0)
        {
            if (_listDialogueWindows[_count] != _listDialogueWindows[_count - 1])
            {
                // 대화창 다를 경우 실행  
            }
            else
            {
                if (_listCharters[_count] != _listCharters[_count - 1])
                {
                    drawAnimator.SetBool("isAlpha", true);
                    yield return new WaitForSeconds(0.5f);
                    openingCharterImage.sprite = _listCharters[_count];
                    drawAnimator.SetBool("isAlpha", false);
                }
                else
                {
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
        else
        {
            if (isCharter.Equals(false))
            {
                openingCharterImage.sprite = _listCharters[_count];
            }
        }

        for (int i = 0; i < _listSentences[_count].Length; i++)
        {
            conversation.text += _listSentences[_count][i]; // 1글자씩 출력
            if (i % 7 == 1)
            {
                typeSound.Play();
            }
            
            yield return new WaitForSeconds(textDelay);
        }

        _clickActivated = true;
        txtBtnImageGo.SetActive(true);
        txtBtnImage.color = new Color(1, 1, 1, 1);
        StartCoroutine(BlinkTxtBtnImage());
    }

    public void NextBtn(bool isCharter)
    {
        if (isTalk.Equals(true) && _clickActivated.Equals(true))
        {
            _clickActivated = false;
            txtBtnImageGo.SetActive(false);
            _count++;
            conversation.text = "";
            enterSound.Play();
                    
            if (_count == _listSentences.Count)
            {
                StopAllCoroutines();
                ExitDialogue();
            }
            else
            {
                StopAllCoroutines();
                StartCoroutine(StartDialogueCoroutine(isCharter));
            }
        }
    }
    
    private IEnumerator BlinkTxtBtnImage()
    {
        while (isTrue.Equals(true))
        {
            // 변수에 몬스터 이미지 컬러 값을 넣음
            Color alpha = txtBtnImage.color;
            
            // 알파 값을 담을 지역 변수
            float npcAlpha = 0f;
            // 알파 이미지를 조절할 시간을 담을 지역 변수
            float npcAlphaTime = 1f;

           

            // 딜레이 타임 0.1f
            yield return _yieldViewDelay;

            // 알파 값이 0보다 큰 동안에 아래 코드 실행
            while (alpha.a > 0f)
            {
                // Debug.Log(1);
                // 실제 시간 / 설정한 딜레이 시간을 계산한 값을 변수에 넣음
                npcAlpha += Time.deltaTime / npcAlphaTime;

                // 알파 값 조절
                alpha.a = Mathf.Lerp(1, 0, npcAlpha);

                // 조절한 알파 값을 이미지의 컬러 값에 넣음
                txtBtnImage.color = alpha;

                yield return null;
            }
            
            // 변수 초기화
            npcAlpha = 0f;
            
            // 알파 값이 255보다 작을 동안에 아래 코드 실행
            while (alpha.a < 1f)
            {
                // 실제 시간 / 설정한 딜레이 시간을 계산한 값을 변수에 넣음
                npcAlpha += Time.deltaTime / npcAlphaTime;

                // 알파 값 조절
                alpha.a = Mathf.Lerp(0, 1, npcAlpha);

                // 조절한 알파 값을 이미지의 컬러 값에 넣음
                txtBtnImage.color = alpha;
                yield return null;
            }
        }
    }
}
