using UnityEngine;

public abstract class WeaponDecorator : IWeapon
{
    protected IWeapon wrappedWeapon;
    
    public WeaponDecorator(IWeapon weapon)
    {
        wrappedWeapon = weapon; 
    }
    
    public virtual float GetDamage()
    {
        return wrappedWeapon.GetDamage();
    }
    
    public virtual void Fire(Transform firePoint, Transform cameraTransform, ObjectPool pool)
    {
        wrappedWeapon.Fire(firePoint, cameraTransform, pool);
    }
}