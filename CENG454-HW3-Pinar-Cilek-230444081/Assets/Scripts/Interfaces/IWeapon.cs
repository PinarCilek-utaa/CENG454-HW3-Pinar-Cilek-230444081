using UnityEngine;

public interface IWeapon
{
    float GetDamage();
    void Fire(Transform firePoint, Transform cameraTransform, ObjectPool pool); 
}