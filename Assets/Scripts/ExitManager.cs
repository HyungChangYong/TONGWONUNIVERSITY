using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    [SerializeField] private StartImage startImage;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            startImage.ShowGameExitUI(false);
        }
    }
}
