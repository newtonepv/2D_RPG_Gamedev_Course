using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    SwordView view;
    SwordModel model;

    PlayerInputActions playerInputActions;

    private void Awake()
    {
        view = GetComponent<SwordView>();

        model = GetComponent<SwordModel>();

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
    }
    void Update()
    {
    }
}
