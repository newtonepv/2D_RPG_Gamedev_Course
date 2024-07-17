using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordModel : MonoBehaviour
{
    [SerializeField] Vector3 offsetOfSlashAnim;

    bool attackButtonDown;
    public void SetAttackButtonDown(bool isAttacking)
    {
        this.attackButtonDown = isAttacking;
    }
    public bool GetAttackButtonDown()
    {
        return this.attackButtonDown;
    }

    [SerializeField]float attackingDelay;

    public float GetAttackingDelay()
    {
        return attackingDelay;
    }
    public void SetAttackingDelay(float attackingDelay)
    {
        this.attackingDelay = attackingDelay;
    }
    
    
    [Header("For Damage Dealing")]
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
    private void Awake()
    {
        
    }

    void Start()
    {

    }

    

    public Vector3 GetOffsetOfSlashAnim(){
        return offsetOfSlashAnim;
    }

    public void SetOffsetOfSlashAnim(Vector3 offsetOfSlashAnim) {
    this.offsetOfSlashAnim = offsetOfSlashAnim;
    }

    

    public Vector3 GetRotation()
    {
        return transform.eulerAngles;
    }

    public void SetRotation(Vector3 rotation)
    {
        transform.rotation = Quaternion.Euler( rotation );

    }



    void Update()
    {
        
    }
}
