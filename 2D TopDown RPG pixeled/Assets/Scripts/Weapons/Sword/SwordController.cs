
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour, IWeapon
{
    SwordView view;
    SwordModel model;

    bool facingLeft;


    DamageDealing damageDealing;
    TrailRenderer trailRenderer;


    private void Awake()
    {
        view = GetComponent<SwordView>();
        model = GetComponent<SwordModel>();

        TryGetComponent<DamageDealing>(out damageDealing);

        trailRenderer= GetComponentInChildren<TrailRenderer>();

    }

    bool hasStarted = false;
    public bool HasStarted()
    {
        return hasStarted;
    }
    void Start()
    {
        hasStarted = true;
    }

    void SetDamageDealingAvaliable()
    {
        damageDealing.SetDealingDamageAvaliable(true);
    }
    void SetDamageDealingNotAvaliable()
    {
        damageDealing.SetDealingDamageAvaliable(false);
    }
    void FlipSlashAnimationUp()
    {
    }
    //
    //
    void Update()
    {
    }

    public void Attack()
    {
            view.AttackAnim();
            facingLeft = PlayerController.Instance.GetFacingLeft();
            trailRenderer.emitting = true;


            StartCoroutine(AttackingCoroutine());
        
    }

    IEnumerator AttackingCoroutine()
    {


        yield return new WaitForSeconds(model.GetAttackingDelay());
        ActiveWeapon.Instance.ToggleAttackIsCoolingDown(false);
        trailRenderer.emitting = false;


    }
    void OnDestroy()
    {
        StopAllCoroutines();
    }
}