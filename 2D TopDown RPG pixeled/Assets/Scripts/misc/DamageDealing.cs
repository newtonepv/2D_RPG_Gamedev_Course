using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageDealing : MonoBehaviour
{
    Vector3 damageSource;


    [SerializeField] bool shouldDamageSlimes;
    public bool GetShouldDamageSlimes() { return shouldDamageSlimes; }
    public void SetShouldDamageSlimes(bool shouldDamageSlimes)
    {
        this.shouldDamageSlimes = shouldDamageSlimes;
    }

    [SerializeField] float damage;
    public float GetDamage() { return damage; }
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    [SerializeField] float knockBackForce;
    public float GetKnockBackForce()
    {

        return knockBackForce;
    }
    public void SetKnockBackForce(float knockBackForce)
    {
        this.knockBackForce = knockBackForce;
    }


    [SerializeField] bool dealingDamageAvaliable = false;
    public bool GetDealingDamageAvaliable()
    {
        return dealingDamageAvaliable;
    }
    public void SetDealingDamageAvaliable(bool dealingDamageAvaliable)
    {
        this.dealingDamageAvaliable = dealingDamageAvaliable;
    }

    [SerializeField] float knockbackDuration;
    public float GetKockbackDuration()
    {
        return knockbackDuration;
    }




    private void Start()
    {
        damageSource = PlayerController.Instance.transform.position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dealingDamageAvaliable)
        {
        if (shouldDamageSlimes)
        {
                if (collision.gameObject.TryGetComponent<SlimeController>(out SlimeController slimeController))
                {
                    if (PlayerController.Instance)
                    {
                        damageSource = PlayerController.Instance.transform.position;
                    }
                    slimeController.StartKnockBack(knockbackDuration, knockBackForce, damageSource, damage);
                }
        }
        }
    }

    public bool GetIsDealingDamage()
    {
        return dealingDamageAvaliable;
    }
}
