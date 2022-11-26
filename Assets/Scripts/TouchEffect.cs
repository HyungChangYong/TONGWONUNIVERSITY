using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems; 

public class TouchEffect : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private float _spawnsTime;
    public float defaultTime = 0.05f;
    // public Camera cam;
    //
    // // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetMouseButton(0) && _spawnsTime >= defaultTime)
    //     {
    //         Creat();
    //         _spawnsTime = 0;
    //     }
    //     
    //     // if (Input.touchCount == 1 && _spawnsTime >= defaultTime)
    //     // {
    //     //     Creat();
    //     //     _spawnsTime = 0;
    //     // }
    //
    //     _spawnsTime += Time.unscaledTime;
    // }
    //
    private void Creat()
    {
       
        // Debug.Log(Input.mousePosition);
        
        
        // Vector2 currentPos = Input.mousePosition;
        // Debug.Log(Input.mousePosition);
        
        // Debug.Log(currentPos);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(targetRectTr, Input.mousePosition, cam,
            out _screenPoint);
        // Debug.Log(_screenPoint);
        // Vector3 pos = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 100);
        //
        // // pos.z = -926;
        // menuUITr.transform.localPosition = _screenPoint;
        GameObject go = Instantiate(prefab, _screenPoint, Quaternion.identity);
        go.transform.SetParent(targetRectTr);
        go.transform.localPosition = _screenPoint;
        go.transform.localScale = new Vector3(1, 1, 1);
    }
    
    private void ParticleSystemCreat()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(targetRectTr, Input.mousePosition, cam,
            out _screenPoint);
        // Debug.Log(_screenPoint);
        // Vector3 pos = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 100);
        //
        // // pos.z = -926;
        // menuUITr.transform.localPosition = _screenPoint;
        // GameObject go = Instantiate(prefab, _screenPoint, Quaternion.identity);
        particleSystem.transform.SetParent(targetRectTr);
        particleSystem.transform.localPosition = new Vector3(_screenPoint.x, _screenPoint.y, 0);
        // particleSystem.transform.localScale = new Vector3(100, 100, 100);
        particleSystem.Play();
    }


    [SerializeField] private RectTransform targetRectTr;
    [SerializeField] private Camera cam;
    [SerializeField] private RectTransform menuUITr;
    [SerializeField] private ParticleSystem particleSystem;

    private Vector2 _screenPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //마우스 포인터가 UI위에 있지않으면
            // if (EventSystem.current
            //     .IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                ParticleSystemCreat();
            }
        }
        
        if (Input.GetMouseButton(0) && _spawnsTime >= defaultTime)
        {
            //마우스 포인터가 UI위에 있지않으면
            // if(EventSystem.current
            //    .IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                Creat();
                _spawnsTime = 0;
            }
        }
        // Debug.Log(Time.unscaledDeltaTime);
        _spawnsTime += Time.unscaledDeltaTime;
    }
}
