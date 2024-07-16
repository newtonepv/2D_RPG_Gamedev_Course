using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageDealing : MonoBehaviour
{
    [SerializeField] bool shouldDamageSlimes;
    [SerializeField] float damage;
    [SerializeField] bool dealingDamageAvaliable = false;

    public bool GetDealingDamageAvaliable()
    {
        return dealingDamageAvaliable;
    }

    public void SetDealingDamageAvaliable(bool dealingDamageAvaliable)
    {
        this.dealingDamageAvaliable= dealingDamageAvaliable;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dealingDamageAvaliable)
        {
            if (shouldDamageSlimes)
            {
                if (collision.TryGetComponent<SlimeController>(out SlimeController slimeController))
                {
                    slimeController.TakeDamage(damage);
                }
            }
        }
    }
}
