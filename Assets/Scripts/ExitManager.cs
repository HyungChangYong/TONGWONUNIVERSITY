using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    [SerializeField] private StartImage startImage;
    
    // Update is called once per frame
    void Update()
    {
        // 뒤로 가기 버튼을 눌렀다면 아래 코드 실행
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            startImage.ShowGameExitUI(false);
        }
    }
}
