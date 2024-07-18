using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{
    bool hasStarted = false;
    [SerializeField] GameObject arrow;
    [SerializeField] Transform arrowSpawnPoint;
    [SerializeField] WeaponInfoSO weaponInfo;
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
        Debug.Log("BowAttack");
    }
}
