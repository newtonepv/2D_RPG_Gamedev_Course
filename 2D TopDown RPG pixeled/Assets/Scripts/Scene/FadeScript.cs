using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : Singleton<FadeScript>
{
    [SerializeField] Image fadeScreen;
    [SerializeField] float fadeSpeed = 1f;

    private IEnumerator fadeRoutine;

    public void FadeToWhite()
    {
        if (fadeRoutine!=null)
        {
            StopCoroutine(fadeRoutine);
        }
        fadeRoutine = FadeRoutine(0);
        StartCoroutine(fadeRoutine);
    }
    public void FadeToBlack()
    {
        if (fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }
        fadeRoutine = FadeRoutine(1);
        StartCoroutine(fadeRoutine);
    }


    IEnumerator FadeRoutine(float target)
    {
        while (!Mathf.Approximately(fadeScreen.color.a, target))
        {
            float alpha = Mathf.MoveTowards(fadeScreen.color.a, target, fadeSpeed*Time.deltaTime);
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, alpha);
            yield return null;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
