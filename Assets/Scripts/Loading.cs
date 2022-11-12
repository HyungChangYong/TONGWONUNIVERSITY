using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class Loading : MonoBehaviour
{
    public static string nextScene;
    [SerializeField] private Image progressBar;
    [SerializeField] private RectTransform loadingImage;

    [SerializeField] private float rotateSpeed;

    [SerializeField] private Image[] backImages;

    [SerializeField] private Sprite[] backImageSprites;

    private readonly WaitForSeconds _yieldViewDelay = new WaitForSeconds(6f);
    private float _time;
    private float _currentFadeTime = 1f;

    private int _randomImageNum;
    
    // private void Update()
    // {
    //     loadingImage.localRotation *= Quaternion.Euler(new Vector3(0, 0, -Time.unscaledDeltaTime * rotateSpeed));
    // }

    private void Start()
    {
        _randomImageNum = UnityEngine.Random.Range(0, 5);
        
        backImages[0].sprite = backImageSprites[_randomImageNum];
        backImages[1].sprite = backImageSprites[_randomImageNum + 1];
   
        Invoke("DelayCoroutine", 0.3f);
    }

    private void DelayCoroutine()
    {
        StartCoroutine(LoadScene());
        StartCoroutine(ChangeImage());
    }

    public static void LoadScenes(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator ChangeImage()
    {
        while (true)
        {
            for (; _randomImageNum < backImageSprites.Length;)
            {
                yield return _yieldViewDelay;
                
                if (_randomImageNum == -1)
                {
                    backImages[0].sprite = backImageSprites[5];
                }
                else
                {
                    backImages[0].sprite = backImageSprites[_randomImageNum];
                }
                backImages[1].sprite = backImageSprites[_randomImageNum + 1];
                backImages[0].color = new Color(1, 1, 1, 1);

                _time = 0f;
        
                Color alpha = backImages[0].color;
        
                while (alpha.a > 0)
                {
                    _time += Time.deltaTime / _currentFadeTime;
            
                    alpha.a = Mathf.Lerp(1, 0, _time);
            
                    backImages[0].color = alpha;
            
                    yield return null;
                }
                _time = 0f;
                
                
                // yield return _yieldViewDelay;
                if (_randomImageNum >= 4)
                {
                    _randomImageNum = -1;
                }
                else
                {
                    _randomImageNum++;
                }
                
            }
        }
        // ReSharper disable once IteratorNeverReturns
    }

    IEnumerator LoadScene()
    {
        // yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        // float timer = 0.0f;
        
        while (!op.isDone)
        {
            yield return null;
            // timer += Time.unscaledDeltaTime;
            loadingImage.localRotation *= Quaternion.Euler(new Vector3(0, 0, -Time.unscaledDeltaTime * rotateSpeed));
            
            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, Time.unscaledDeltaTime);
                // if (progressBar.fillAmount >= op.progress)
                // {
                //     timer = 0f;
                // }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, Time.unscaledDeltaTime);
                if (progressBar.fillAmount >= 0.99f)
                {
                    op.allowSceneActivation = true; 
                }
            }
        }
    }
}
