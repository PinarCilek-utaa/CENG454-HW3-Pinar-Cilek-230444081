using UnityEngine;
//abstract class:Objects cannot be derived from this class; it is merely a template for extensions.
public abstract class WeaponDecorator : IWeapon
{
    protected IWeapon wrappedWeapon;//real weapon we wrapped it in
    
    public WeaponDecorator(IWeapon weapon)
    {
        wrappedWeapon=weapon; //the weapon to be wrapped around when the class is created
    }
    public virtual float GetDamage()
    {
        //when we ask it's damage ->it returns the damage of the eweapon inside
        //add virtual so that extensions can override it
        return wrappedWeapon.GetDamage();
    }
    public virtual void Fire()
    {
        wrappedWeapon.Fire();
    }

}
