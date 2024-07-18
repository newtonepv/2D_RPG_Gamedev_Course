using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{
    bool hasStarted = false;
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
        ActiveWeapon.Instance.ToggleAttackIsCoolingDown(false);
    }
}
