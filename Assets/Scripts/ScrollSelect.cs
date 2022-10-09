using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollSelect : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerUpHandler
{
    // 리스트 숫자를 매겨 담을 변수
    [SerializeField] private int num;

    // ScrollRect 컴포넌트를 담을 변수
    public ScrollRect scrollView;

    // 드래그 중인지 아닌지 체크할 변수
    private bool _isDrag;

    /// <summary>
    /// 드래그 시작시 호출되는 함수
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        // 변수에 참이라는 값을 넣음 (드래그 중임)
        _isDrag = true;

        // 이벤트 넘겨 주기
        scrollView.OnBeginDrag(eventData);
    }
    
    /// <summary>
    /// 드래그 중일시 호출되는 함수
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        // 이벤트 넘겨 주기
        scrollView.OnDrag(eventData);
    }
    
    /// <summary>
    /// 드래그 종료시 호출되는 함수
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        // 변수에 거짓이라는 값을 넣음 (변수 초기화)
        _isDrag = false;
        
        // 이벤트 넘겨 주기
        scrollView.OnEndDrag(eventData);
    }
    
    /// <summary>
    /// 클릭 시작시 호출되는 함수
    /// </summary>
    /// <param name="data"></param>
    public void OnPointerDown(PointerEventData data)
    {
        
    }
    
    /// <summary>
    /// 클릭 종료시 호출되는 함수
    /// </summary>
    /// <param name="data"></param>
    public void OnPointerUp(PointerEventData data)
    {
       // 변수 값이 거짓이라면 아래 코드 실행 (드래그 중이 아니라면)
        if (_isDrag.Equals(false))
        {
            // 함수 호출
            LobbyManager.Instance.ShowMaximAlbum(num);
        }
    }
}
