using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon
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
        Debug.Log("StaffAttack");
        ActiveWeapon.Instance.ToggleAttackIsCoolingDown(false);

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
}
