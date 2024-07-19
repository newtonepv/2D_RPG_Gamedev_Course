using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon
{
    bool hasStarted = false;
    [SerializeField] WeaponInfoSO weaponInfo;
    [SerializeField] Transform laserSpawn;
    [SerializeField] GameObject laser;
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public WeaponInfoSO GetWeaponInfo()
    {
        return weaponInfo;
    }
    public bool HasStarted()
    {
        return hasStarted;
    }
    void Start()
    {
        hasStarted = true;
    }
    public void Attack()
    {
        animator.SetTrigger("attacking");

    }
    void Update()
    {
        if (hasStarted)
        {
            Vector3 mousepos = Input.mousePosition;
            Vector3 playerPosInScreen = Camera.main.WorldToScreenPoint(PlayerController.Instance.transform.position);

            float angle = Mathf.Atan2(mousepos.y, mousepos.x)*Mathf.Rad2Deg;

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
    public void CreateRay()
    {
        GameObject laserInstance = Instantiate(laser, laserSpawn.position, Quaternion.identity);
        laserInstance.GetComponent<DamageDealing>().SetDamage(weaponInfo.damage);
        laserInstance.GetComponent<Laser>().SetRange(weaponInfo.range);

    }
}
