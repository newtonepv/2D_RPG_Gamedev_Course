using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 movement;
    PlayerInputActions playerInputActions;
    PlayerView playerView;
    PlayerModel playerModel;
    private void Awake()
    {

        playerView = GetComponent<PlayerView>();
        playerModel = GetComponent<PlayerModel>();

        playerInputActions = new PlayerInputActions();
    }
    void Start()
    {
        
    }
    private void OnEnable()
    {
        playerInputActions.Enable();
    }
    private void OnDisable()
    {
        playerInputActions.Disable();
    }
    void Update()
    {
        GetMovementInput();

        Debug.Log(movement.ToString());

        Flip_Sprite_Based_On_Mouse_Pos_Relative_To_Player();
    }

    private void Flip_Sprite_Based_On_Mouse_Pos_Relative_To_Player()
    {
        Vector3 screenPlayerPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 screenMousePoint = Input.mousePosition;

        if(screenMousePoint.x < screenPlayerPoint.x)
        {
            TurnSprite(true);
        }
        else{
            TurnSprite(false);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        playerView.SetMoveX(movement.x);
        playerView.SetMoveY(movement.y);

        playerModel.MoveTowards(movement);



    }

    private void TurnSprite(bool x)
    {
        playerView.TurnSpriteToLeft(x);
    }

    void GetMovementInput()
    {
        movement = playerInputActions.Player.Move.ReadValue<Vector2>();
    }
}
