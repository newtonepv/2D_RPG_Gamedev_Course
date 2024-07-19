using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSprite : MonoBehaviour
{
    [SerializeField] float fadeTime = 0.4f;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }
    public IEnumerator FadeRoutine(Action Done)
    {
        float elapsedTime = 0;
        float newAlpha = 0;
        float targetTransparency = 0;
        float starting = spriteRenderer.color.a;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            newAlpha = Mathf.Lerp(starting, targetTransparency, elapsedTime / fadeTime);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newAlpha);
            yield return null;
        }
        Done();
    }
    void Update()
    {
        
    }
}
