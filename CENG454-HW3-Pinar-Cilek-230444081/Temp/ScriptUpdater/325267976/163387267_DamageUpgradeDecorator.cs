using UnityEngine;

public class DamageUpgradeDecorator : WeaponDecorator
{
    public DamageUpgradeDecorator(IWeapon weapon) : base(weapon){}

    public override float GetDamage()
    {
        return base.GetDamage() + 5f;
    }
        
    public override void Fire(Transform firePoint, Transform cameraTransform, ObjectPool pool)
    {
        base.Fire(firePoint, cameraTransform, pool); 
        Vector3 offsetPosition = firePoint.position + firePoint.right * 0.4f; 
        
        GameObject bullet2 = pool.GetObjectFromPool(offsetPosition, firePoint.rotation);
        if (bullet2 != null)
        {
            Rigidbody rb = bullet2.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.AddForce(cameraTransform.forward * 40f, ForceMode.Impulse);
            }
        }

        Debug.Log("<color=cyan>DOUBLE BULLET FIRED! NEW DAMAGE:" + GetDamage() + "</color>");
    }
}