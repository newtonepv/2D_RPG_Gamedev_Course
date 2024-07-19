using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{
    bool hasStarted = false;
    [SerializeField] WeaponInfoSO weaponInfo;
    [SerializeField] GameObject arrow;
    [SerializeField] Transform arrowSpawnPoint;
    Animator animator;
    public WeaponInfoSO GetWeaponInfo()
    {
        return weaponInfo;
    }
    public bool HasStarted()
    {
        return hasStarted;
    }
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        hasStarted = true;
    }
    public void Attack()
    {
        Debug.Log("BowAttack");
        animator.SetTrigger("attack");
        GameObject arrowInstance = Instantiate(arrow, arrowSpawnPoint.position, ActiveWeapon.Instance.transform.rotation);
        arrowInstance.GetComponent<Projectile>().SetRange(weaponInfo.range);
        arrowInstance.GetComponent<DamageDealing>().SetDamage(weaponInfo.damage);
    }
}
