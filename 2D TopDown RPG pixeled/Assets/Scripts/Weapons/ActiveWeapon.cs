using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : Singleton<ActiveWeapon>
{
    public MonoBehaviour currentActiveWeapon;

    PlayerInputActions playerInputActions;

    bool attackButtonDown=false;

    bool attackIsCoolingDown=false;

    protected override void Awake()
    {
        base.Awake();
        playerInputActions = new PlayerInputActions();
    }
    private void OnEnable()
    {
        playerInputActions.Enable();
    }
    void Start()
    {
        playerInputActions.Combat.Attack.started += _ => StartAttacking();
        playerInputActions.Combat.Attack.canceled += _ => StopAttacking();
    }

    public void ToggleAttackIsCoolingDown(bool attackIsCoolingDown)
    {
        this.attackIsCoolingDown = attackIsCoolingDown;
    }

    void StartAttacking()
    {
        attackButtonDown = true;
    }
    void StopAttacking()
    {
        attackButtonDown = false;
    }
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        if (!attackIsCoolingDown && attackButtonDown && (currentActiveWeapon as IWeapon).HasStarted())
        {
            attackIsCoolingDown=true;
            (currentActiveWeapon as IWeapon).Attack();
        }

    }
}
