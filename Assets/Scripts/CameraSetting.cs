using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 앱 실행 후 어느 화면 비율에서도 똑같은 화면으로 설정해주는 스크립트
public class CameraSetting : MonoBehaviour
{
    [SerializeField] private Camera theCam;
    public void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        
        Rect rect = theCam.rect;
    
        float scaleheight = ((float)Screen.width / Screen.height) / ((float)9 / 16);
        float scalewidth = 1f / scaleheight;
        if (scaleheight < 1)
        {
            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;
        }    
        else 
        {
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }
        theCam.rect =rect;
    }
}
