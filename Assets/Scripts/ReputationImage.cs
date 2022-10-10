using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReputationImage : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Scrollbar scrollbar;
    
    private const int SIZE = 4;
    private float[] pos = new float[SIZE];
    private float distance;
    private float curPos;
    private float targetPos;
    private bool isDrag;
    private int targetIndex;

    [SerializeField] private GameObject[] profileSizeUp;

    [SerializeField] private Sprite[] lineTxtImages;
    [SerializeField] private Image lineTxtImage;
    
    [SerializeField] private GameObject[] darkImageBase;
 
    public void ResetImage()
    {
        lineTxtImage.sprite = lineTxtImages[0];
        
        darkImageBase[0].SetActive(false);
        profileSizeUp[0].SetActive(true);
        
        targetIndex = 0;

        for (int i = 1; i < profileSizeUp.Length; i++)
        {
            profileSizeUp[i].SetActive(false);

            if (LobbyManager.Instance.isShowHeart[i].Equals(true))
            {
                darkImageBase[i].SetActive(true);
            }
            else
            {
                darkImageBase[i].SetActive(false);
            }
        }
        
        

        targetPos = 0;
    }
    
    private void Start()
    {
        distance = 1f / (SIZE - 1);
        for (int i = 0; i < SIZE; i++)
        {
            pos[i] = distance * i;
        }
    }

    float SetPos()
    {
        for (int i = 0; i < SIZE; i++)
        {
            if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f)
            {
                targetIndex = i;
                return pos[i];
            }
            
            if (scrollbar.value < 0)
            {
                targetIndex = 0;
                return pos[0];
            }
            
            if (scrollbar.value > 1)
            {
                targetIndex = 3;
                return pos[3];
            }
        }
        return 0;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        curPos = SetPos();
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true;
        profileSizeUp[targetIndex].SetActive(false);

        if (LobbyManager.Instance.isShowHeart[targetIndex].Equals(true))
        {
            darkImageBase[targetIndex].SetActive(true);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;

        targetPos = SetPos();

        if (curPos.Equals(targetPos))
        {
            if (eventData.delta.x > 18 && curPos - distance >= 0)
            {
                --targetIndex;
                targetPos = curPos - distance;
            }
            else if (eventData.delta.x < -18 && curPos + distance <= 1.01f)
            {
                ++targetIndex;
                targetPos = curPos + distance;
            }
        }

        if (targetIndex == 0)
        {
            lineTxtImage.sprite = lineTxtImages[0];
        }
        else
        {
            lineTxtImage.sprite = lineTxtImages[1];
        }
    }

    private void Update()
    {
        if (isDrag.Equals(false))
        {
            scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);
            
            profileSizeUp[targetIndex].SetActive(true);
            
            darkImageBase[targetIndex].SetActive(false);
        }
    }
}
