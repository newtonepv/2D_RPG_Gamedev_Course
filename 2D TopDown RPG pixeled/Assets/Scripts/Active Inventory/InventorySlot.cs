using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] WeaponInfoSO weaponInfo;

    public WeaponInfoSO GetWeaponInfo() {return weaponInfo;}
}
