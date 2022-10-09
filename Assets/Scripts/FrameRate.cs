using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 현재 프레임을 계산해 UI로 표시해주는 스크립트 추후 삭제 예정
public class FrameRate : MonoBehaviour
{
    private float deltaTime = 0f;
    
    [SerializeField] private Text targetFrameTxt;

    [SerializeField] private Text frameTxt;
    
    [SerializeField] private Text deadTxt;

    public bool isDead = true;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    private void OnGUI()
    {
        float ms = deltaTime * 1000f;
        float fps = 1.0f / deltaTime;
        frameTxt.text = string.Format("{0:0.} FPS ({1:0.0} ms)", fps, ms);
    }

    public void SetFrame()
    {
        if (Equals(Application.targetFrameRate, 60))
        {
            Application.targetFrameRate = 120;
        }
        else if (Equals(Application.targetFrameRate, 120))
        {
            // 무제한 초당 프레임
            Application.targetFrameRate = 300;
        }
        else if (Equals(Application.targetFrameRate, 300))
        {
            Application.targetFrameRate = 60;
        }
        targetFrameTxt.text = "목표 프레임 : " + Application.targetFrameRate;
    }

    public void ReStart()
    {
        SceneManager.LoadScene(0);
    }

    public void OnDead()
    {
        if (isDead == false)
        {
            isDead = true;
            deadTxt.text = "죽음 가능";
        }
        else
        {
            isDead = false;
            deadTxt.text = "죽음 불가능";
        }
    }
}