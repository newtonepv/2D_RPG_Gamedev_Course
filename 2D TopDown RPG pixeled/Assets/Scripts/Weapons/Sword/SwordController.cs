
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour, IWeapon
{
    SwordView view;
    SwordModel model;

    bool facingLeft;

    Transform slashAnimationSpawner;
    [SerializeField] GameObject slashAnimation;

    GameObject slashAnimationInstance;
    DamageDealing damageDealing;


    private void Awake()
    {
        view = GetComponent<SwordView>();
        model = GetComponent<SwordModel>();

        TryGetComponent<DamageDealing>(out damageDealing);


    }

    bool hasStarted = false;
    public bool HasStarted()
    {
        return hasStarted;
    }
    void Start()
    {
        slashAnimationSpawner = ActiveWeapon.Instance.GetSlashAnimationSpawner();
        hasStarted = true;
    }

    //called in the animator
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
        if(slashAnimationInstance.TryGetComponent<SlashAnimationModel>(out SlashAnimationModel slashAnimationModel))
        {
            slashAnimationModel.SetXRotation(180f);
        }
    }
    //
    //
    void Update()
    {
    }

    public void Attack()
    {
        if (slashAnimationSpawner)
        {
            view.AttackAnim();
            Vector3 offset = model.GetOffsetOfSlashAnim();
            facingLeft = PlayerController.Instance.GetFacingLeft();
            offset.x *= facingLeft ? -1 : 1;

            slashAnimationInstance = Instantiate(slashAnimation,
                                                slashAnimationSpawner.position + offset,
                                                PlayerController.Instance.GetQuaternionRotation(),
                                                this.transform.parent
                                                );
            StartCoroutine(AttackingCoroutine());
        }
        
    }

    IEnumerator AttackingCoroutine()
    {


        yield return new WaitForSeconds(model.GetAttackingDelay());
        ActiveWeapon.Instance.ToggleAttackIsCoolingDown(false);

    }
    void OnDestroy()
    {
        StopAllCoroutines();
    }
}