using UnityEngine;

public class BaseWeapon : IWeapon
{
    public float GetDamage()
    {
        return 10f; 
    }

    public void Fire(Transform firePoint, Transform cameraTransform, ObjectPool pool)
    {
        if (pool == null || firePoint == null) return;
        GameObject bullet = pool.GetObjectFromPool(firePoint.position, firePoint.rotation);
        if (bullet != null)
        {
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.AddForce(cameraTransform.forward * 40f, ForceMode.Impulse);
            }
        }
        //Debug.Log("BASE WEAPON FIRED! DAMAGE: " + GetDamage());
    }
}