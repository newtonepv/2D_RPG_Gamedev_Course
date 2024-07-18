using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon")]
public class WeaponInfoSO : ScriptableObject
{
    public GameObject weeaponPrefab;
    public float cooldown;
}
