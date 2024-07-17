using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 movement;
    PlayerInputActions playerInputActions;
    PlayerView view;
    PlayerModel model;
    private void Awake()
    {
        movement = new Vector2 (0, 0);

        view = GetComponent<PlayerView>();
        model = GetComponent<PlayerModel>();

        playerInputActions = new PlayerInputActions();
    }
    void Start()
    {
        playerInputActions.Combat.Dash.started += _ => HandleDashing();
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
    void HandleDashing()
    {

        if (model.GetCanDash())
        {
            StartCoroutine(DashingCoroutine());
        }
    }

    IEnumerator DashingCoroutine()
    {
        model.SetIsDashing(true);
        model.SetCanDash(false);
        model.SetTrailRendererEmitting(true);
        
        if (movement == new Vector2(0, 0))
        {
            if(model.GetFacingLeft())
            {
                movement = new Vector2(-1, 0);
            }
            else
            {
                movement = new Vector2(1, 0);
            }
        }

        float defoultSpeed = model.GetMoveSpeed();
        model.SetMoveSpeed(model.GetDashingSpeed());

        yield return new WaitForSeconds(model.GetDashingDuration());

        model.SetMoveSpeed(defoultSpeed);
        model.SetIsDashing(false);
        model.SetTrailRendererEmitting(false);

        yield return new WaitForSeconds(model.GetDelayBetweenDashes());

        model.SetCanDash(true);
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
        view.SetMoveX(movement.x);
        view.SetMoveY(movement.y);

        model.MoveTowards(movement);
    }

    private void TurnLeft(bool turnLeft)
    {

        //playerView.TurnSpriteToLeft(turnLeft);
        Vector3 actualRot = model.GetRotation();

        model.SetFacingLeft(turnLeft);
        
        if (turnLeft)
        {
            model.SetRotation(new Vector3(actualRot.x, 180, actualRot.z));
        }
        else
        {
            model.SetRotation(new Vector3(actualRot.x, 0, actualRot.z));
        }
    }

    void GetMovementInput()
    {
        /*if (model.GetIsDashing()==false)
        {*/
            movement = playerInputActions.Player.Move.ReadValue<Vector2>();
        //}
    }
}
