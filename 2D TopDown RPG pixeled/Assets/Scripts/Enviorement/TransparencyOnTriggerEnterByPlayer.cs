using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TransparencyOnTriggerEnterByPlayer : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Tilemap tilemapRenderer;

    [Range(0, 1)]
    [SerializeField] float transparencyAmount = 0.8f;
    [SerializeField] float fadeTime = 0.4f;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tilemapRenderer = GetComponent<Tilemap>();
    }
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerModel>())
        {

            if (tilemapRenderer)
            {
                StartCoroutine(FadeRoutine(tilemapRenderer, fadeTime, tilemapRenderer.color.a, transparencyAmount));
            }
            else if (spriteRenderer)
            {
                StartCoroutine(FadeRoutine(spriteRenderer, fadeTime, spriteRenderer.color.a, transparencyAmount));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerModel>())
        {
            if (tilemapRenderer)
            {
                StartCoroutine(FadeRoutine(tilemapRenderer, fadeTime, tilemapRenderer.color.a, 1));
            }
            else if (spriteRenderer)
            {
                StartCoroutine(FadeRoutine(spriteRenderer, fadeTime, spriteRenderer.color.a, 1));
            }
        }
    }

    IEnumerator FadeRoutine(SpriteRenderer spriteRenderer, float fadeTime, float starting, float targetTransparency)
    {

        float elapsedTime = 0;
        float newAlpha = 0;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            newAlpha = Mathf.Lerp(starting, targetTransparency, elapsedTime / fadeTime);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newAlpha);
            yield return null;
        }
    }
    IEnumerator FadeRoutine(Tilemap tilemapRenderer, float fadeTime, float starting, float targetTransparency)
    {
        float elapsedTime = 0;
        float newAlpha = 0;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            newAlpha = Mathf.Lerp(starting, targetTransparency, elapsedTime / fadeTime);
            tilemapRenderer.color = new Color(tilemapRenderer.color.r, tilemapRenderer.color.g, tilemapRenderer.color.b, newAlpha);
            yield return null;
        }
    }
    /*private void OnDestroy()
    {
        StopAllCoroutines();
    }*/
}
