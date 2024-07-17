using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    float moveX;
    float moveY;

    Animator playerAnimator;
    SpriteRenderer playerSpriteRenderer;

    

    public void TurnSpriteToLeft(bool shouldTurnSpriteToLeft)
    {
        playerSpriteRenderer.flipX = shouldTurnSpriteToLeft;
    }

    public void SetMoveY(float moveY)
    { 
    this.moveY = moveY;
    playerAnimator.SetFloat("moveY", moveY);
    }
    public void SetMoveX(float moveX)
    {
    this.moveX = moveX;
    playerAnimator.SetFloat("moveX", moveX);
    }
    public float GetMoveX() { 
    return this.moveX;
    }
    public float GetMoveY()
    {
        return this.moveY;
    }

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
