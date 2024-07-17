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
    DamageDealing damageDealing;

    bool attackingCoroutineIsRunning;

    public bool GetAttackingCoroutineIsRunning()
    {

    return attackingCoroutineIsRunning; }
    private void Awake()
    {
        view = GetComponent<SwordView>();
        model = GetComponent<SwordModel>();

        if (TryGetComponent<DamageDealing>(out damageDealing))
        {
            damageDealing.SetDamage(model.GetDamage());
            damageDealing.SetKnockBackForce(model.GetKnockBackForce());
            damageDealing.SetDealingDamageAvaliable(model.GetDealingDamageAvaliable());
            damageDealing.SetShouldDamageSlimes(model.GetShouldDamageSlimes());
            damageDealing.SetKockbackDuration(model.GetKockbackDuration());
        }


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
        playerInputActions.Combat.Attack.started += _ => StartAttacking();
        playerInputActions.Combat.Attack.canceled += _ => StopAttacking();
    }
    void StartAttacking()
    {
        model.SetAttackButtonDown(true); 
        //Debug.Log(model.GetAttackButtonDown());
    }
    void StopAttacking()
    {
        model.SetAttackButtonDown(false);
        //Debug.Log(model.GetAttackButtonDown());
    }
    void Attack()
    {
        view.AttackAnim();

        Vector3 offset = model.GetOffsetOfSlashAnim();

        facingLeft = playerModel.GetFacingLeft();

        offset.x *= facingLeft ? -1 : 1;

        slashAnimationInstance = Instantiate(slashAnimation, 
                                            slashAnimationSpawner.position+offset,
                                            playerModel.GetQuaternionRotation(),
                                            this.transform.parent
                                            );

    }

    void SetDamageDealingAvaliable()
    {
        model.SetDealingDamageAvaliable(true);
        damageDealing.SetDealingDamageAvaliable(true);
    }
    void SetDamageDealingNotAvaliable()
    {
        model.SetDealingDamageAvaliable(false);
        damageDealing.SetDealingDamageAvaliable(false);
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
        AttackCoroutineHandler();
    }

    private void AttackCoroutineHandler()
    {
        if (model.GetAttackButtonDown())
        {
            if (!attackingCoroutineIsRunning)
            {
                StartCoroutine(AttackingCoroutine());
            }
        }

    }

    IEnumerator AttackingCoroutine()
    {
        attackingCoroutineIsRunning = true;

        Attack();

        yield return new WaitForSeconds(model.GetAttackingDelay());

        attackingCoroutineIsRunning = false;


    }
}