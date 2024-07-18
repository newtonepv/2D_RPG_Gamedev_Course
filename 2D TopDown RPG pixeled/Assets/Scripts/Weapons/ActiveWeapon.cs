using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : Singleton<ActiveWeapon>
{
    private MonoBehaviour currentActiveWeapon;

    PlayerInputActions playerInputActions;

    float attackCooldown;

    bool attackButtonDown=false;

    bool attackIsCoolingDown=false;

    public MonoBehaviour GetCurrentActiveWeapon()
    {
        return currentActiveWeapon;
    }
    public void SetCurrentActiveWeapon(MonoBehaviour currentActiveWeapon)
    {
        this.currentActiveWeapon = currentActiveWeapon;
        attackCooldown = (currentActiveWeapon as IWeapon).GetWeaponInfo().cooldown;
    }

    protected override void Awake()
    {
        base.Awake();
        AttackCoolDown();
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

        AttackCoolDown();
    }

    public void ToggleAttackIsCoolingDown(bool attackIsCoolingDown)
    {
        this.attackIsCoolingDown = attackIsCoolingDown;
    }

    void AttackCoolDown()
    {
        attackIsCoolingDown = true;
        StopAllCoroutines();
        StartCoroutine(CoolingDown());
    }
    IEnumerator CoolingDown()
    {
        yield return new WaitForSeconds(attackCooldown);
        attackIsCoolingDown = false;
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
            AttackCoolDown();
            (currentActiveWeapon as IWeapon).Attack();
        }

    }
}
