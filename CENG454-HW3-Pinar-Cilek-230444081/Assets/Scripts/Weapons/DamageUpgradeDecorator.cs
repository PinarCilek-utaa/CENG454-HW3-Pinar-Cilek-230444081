
using UnityEngine;

public class DamageUpgradeDecorator : WeaponDecorator
{
    //to apply the extension to the weapon: we send the main weapon to the base weapon.
    public DamageUpgradeDecorator(IWeapon weapon) : base(weapon){}
    public override float GetDamage()
    {
        //Add 5 to the main weapon's damage and then return it
        return base.GetDamage() + 5f;
    }
        
    public override void Fire()
    {
        base.Fire(); // fire the main weapon first
        Debug.Log("WEAPON IMPROVED! NEW DAMAGE: " + GetDamage());
    }
}
