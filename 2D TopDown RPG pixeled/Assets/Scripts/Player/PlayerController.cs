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


        Flip_Player_Based_On_Mouse_Pos_Relative_To_Player();
    }

    private void Flip_Player_Based_On_Mouse_Pos_Relative_To_Player()
    {
        Vector3 screenPlayerPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 screenMousePoint = Input.mousePosition;

        if(screenMousePoint.x < screenPlayerPoint.x)
        {
            TurnLeft(true);
        }
        else{
            TurnLeft(false);
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

    private void TurnLeft(bool turnLeft)
    {

        //playerView.TurnSpriteToLeft(turnLeft);
        Vector3 actualRot = playerModel.GetRotation();

        playerModel.SetFacingLeft(turnLeft);
        
        if (turnLeft)
        {
            playerModel.SetRotation(new Vector3(actualRot.x, 180, actualRot.z));
        }
        else
        {
            playerModel.SetRotation(new Vector3(actualRot.x, 0, actualRot.z));
        }
    }

    void GetMovementInput()
    {
        movement = playerInputActions.Player.Move.ReadValue<Vector2>();
    }
}
