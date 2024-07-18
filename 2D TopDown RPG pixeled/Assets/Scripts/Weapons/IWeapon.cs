using System;

interface IWeapon
{
    public void Attack();
    public bool HasStarted();

    public WeaponInfoSO GetWeaponInfo();
}