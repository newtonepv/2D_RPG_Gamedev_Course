using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Laser : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsuleCollider;
    FadeSprite fadeSprite;
    float range;
    [SerializeField] float laserGrowTime = 2f;

    Action die;
    public void SetRange(float range)
    {
        this.range = range;
        StartCoroutine(increaseLaserLength());
    }
    IEnumerator increaseLaserLength()
    {
        float elapsedTime = 0f;
        while (spriteRenderer.size.x < range)
        {
            elapsedTime += Time.deltaTime;
            float linearT = elapsedTime / laserGrowTime;

            spriteRenderer.size = new Vector2(Mathf.Lerp(1, range, linearT), 1);
            capsuleCollider.size = new Vector2(Mathf.Lerp(0.8840485f, range, linearT), capsuleCollider.size.y);
            capsuleCollider.offset = new Vector2(Mathf.Lerp(0.4875151f, range, linearT/2), capsuleCollider.offset.y);
            yield return null;
        }
        StartCoroutine(fadeSprite.FadeRoutine(die));
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        fadeSprite = GetComponent<FadeSprite>();
        die = Die;

    }
    void Start()
    {
        FaceMouse();
    }

    void Update()
    {

    }
    void FaceMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = mousePos - transform.position;
        transform.right = direction;
    }
}
