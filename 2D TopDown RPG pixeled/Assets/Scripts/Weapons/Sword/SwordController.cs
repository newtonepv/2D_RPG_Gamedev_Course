
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

    [SerializeField] WeaponInfoSO weaponInfo;
    public WeaponInfoSO GetWeaponInfo()
    {
        return weaponInfo;
    }


    private void Awake()
    {
        view = GetComponent<SwordView>();
        model = GetComponent<SwordModel>();

        TryGetComponent<DamageDealing>(out damageDealing);

        trailRenderer = GetComponentInChildren<TrailRenderer>();

    }

    bool hasStarted = false;
    public bool HasStarted()
    {
        return hasStarted;
    }
    void Start()
    {
        damageDealing.SetDamage(weaponInfo.damage);

        hasStarted = true;

    }

    void SetDamageDealingAvaliable()
    {
        damageDealing.SetDealingDamageAvaliable(true);
        trailRenderer.emitting = true;
    }
    void SetDamageDealingNotAvaliable()
    {
        damageDealing.SetDealingDamageAvaliable(false);
        trailRenderer.emitting = false;
    }
    void FlipSlashAnimationUp()
    {
    }
    //
    //
    void Update()
    {
        if (hasStarted)
        {
            Vector3 mousepos = Input.mousePosition;
            Vector3 playerPosInScreen = Camera.main.WorldToScreenPoint(PlayerController.Instance.transform.position);

            float angle = Mathf.Atan2(mousepos.y, mousepos.x) * Mathf.Rad2Deg;

            if (mousepos.x < playerPosInScreen.x)
            {
                ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, -180, angle);
            }
            else
            {
                ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, angle);

            }

        }
    }

    public void Attack()
    {
        view.AttackAnim();
        facingLeft = PlayerController.Instance.GetFacingLeft();
    }
    void OnDestroy()
    {
        StopAllCoroutines();
    }
}