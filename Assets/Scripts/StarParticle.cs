using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class StarParticle : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;
    [SerializeField] private float sizeSpeed;
    [SerializeField] private float colorSpeed;
    [SerializeField] private Color[] colors;
    
    [SerializeField] private Image shinImage;
    
    private Vector2 _direction;
    
    // Start is called before the first frame update
    void Start()
    {
        _direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        float size = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(size, size);
        shinImage.color = colors[Random.Range(0, colors.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * moveSpeed);
        transform.localScale = Vector2.Lerp(transform.localScale, Vector2.zero, Time.deltaTime * sizeSpeed);

        Color color = shinImage.color;
        color.a = Mathf.Lerp(shinImage.color.a, 0, Time.deltaTime * colorSpeed);
        shinImage.color = color;

        if (shinImage.color.a <= 0.01f)
        {
            gameObject.SetActive(false);
        }
    }
}
