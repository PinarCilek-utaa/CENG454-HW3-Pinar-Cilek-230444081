
using UnityEngine;

public class BaseWeapon : IWeapon
{
    //this is our basse weapon
    public float GetDamage()
    {
        return 10f; // 10 damage per hit
    }
    public void Fire()
    {
        Debug.Log("BASE WEAPON WAS FIRED! DAMAGE:  " + GetDamage());
    }
}
