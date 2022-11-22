using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

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


    [SerializeField] private RectTransform targetRectTr;
    [SerializeField] private Camera cam;
    [SerializeField] private RectTransform menuUITr;

    private Vector2 _screenPoint;

    private void Update()
    {
        if (Input.GetMouseButton(0) && _spawnsTime >= defaultTime)
        {
            Creat();
            _spawnsTime = 0;
        }
        
        _spawnsTime += Time.unscaledTime;
    }
}
