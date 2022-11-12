using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLoading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Loading.LoadScenes("MainScene");
    }
}
