using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    [SerializeField] private StartImage startImage;

    // [SerializeField] private GameObject startPrefab;
    //
    // [SerializeField] private float spawnsTime;
    // [SerializeField] private float defaultTime = 0.05f;
    //
    // [SerializeField] private Transform parentCanvasGo;
     
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            startImage.ShowGameExitUI(false);
        }

        // if (Input.GetMouseButton(0) && spawnsTime >= defaultTime)
        // {
        //     StartCreat();
        //     spawnsTime = 0;
        // }
        // spawnsTime += Time.deltaTime;
    }

    // private void StartCreat()
    // {
    //     Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     mPosition.z = 0;
    //     GameObject startPrefabClone = Instantiate(startPrefab, mPosition, Quaternion.identity);
    //     startPrefabClone.transform.SetParent(parentCanvasGo);
    // }
}
