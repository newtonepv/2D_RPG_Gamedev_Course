using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageDealing : MonoBehaviour
{
    bool shouldDamageSlimes;
    public bool GetShouldDamageSlimes() { return shouldDamageSlimes; }

    float damage;

    float knockBackForce;
    public float GetKnockBackForce()
    {

    return knockBackForce; }

    bool dealingDamageAvaliable = false;

    float knockbackDuration;

    public float GetKockbackDuration()
    {
    return knockbackDuration; }

    public void SetKockbackDuration(float knockbackDuration)
    {
        this.knockbackDuration = knockbackDuration;
    }
    public bool GetDealingDamageAvaliable()
    {
        return dealingDamageAvaliable;
    }
    public void SetDealingDamageAvaliable(bool dealingDamageAvaliable)
    {
        this.dealingDamageAvaliable = dealingDamageAvaliable;

    }

    public void SetKnockBackForce(float knockBackForce)
    {
        this.knockBackForce = knockBackForce;
    }
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
    public void SetShouldDamageSlimes(bool shouldDamageSlimes)
    {
        this.shouldDamageSlimes = shouldDamageSlimes;
    }

 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("pepe");
        if (dealingDamageAvaliable)
        {
        if (shouldDamageSlimes)
        {
            if (collision.gameObject.TryGetComponent<SlimeController>(out SlimeController slimeController))
             {
                    slimeController.StartKnockBack(knockbackDuration, knockBackForce, transform.position, damage);
            }
        }
        }
    }
}
