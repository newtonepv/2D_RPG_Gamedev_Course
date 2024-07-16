using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    SwordView view;
    SwordModel model;
    PlayerModel playerModel;

    bool facingLeft;

    [SerializeField] Transform slashAnimationSpawner;
    [SerializeField] GameObject slashAnimation;

    PlayerInputActions playerInputActions;
    GameObject slashAnimationInstance;
    private void Awake()
    {
        view = GetComponent<SwordView>();
        model = GetComponent<SwordModel>();
        playerModel = GetComponentInParent<PlayerModel>();

        playerInputActions = new PlayerInputActions();
    }
    private void OnEnable()
    {
        playerInputActions.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Disable();
    }

    void Start()
    {
        playerInputActions.Combat.Attack.started += _ => Attack();
    }
    void Attack()
    {
        view.Attack();

        Vector3 offset = model.GetOffsetOfSlashAnim();

        facingLeft = playerModel.GetFacingLeft();

        offset.x *= facingLeft ? -1 : 1;



        slashAnimationInstance = Instantiate(slashAnimation, 
                                            slashAnimationSpawner.position+offset,
                                            playerModel.GetQuaternionRotation(),
                                            this.transform.parent
                                            );


    }
    void FlipSlashAnimationUp()
    {
        if(slashAnimationInstance.TryGetComponent<SlashAnimationModel>(out SlashAnimationModel slashAnimationModel))
        {
            slashAnimationModel.SetXRotation(180f);
        }
    }
    void Update()
    {
        
    }
}