using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed=20f;
    public float lifeTime=2f;
    private float currentLifeTimer;

    private void OnEnable()
    {
        //to reset the remaining time from the bullet's previous launch:
        currentLifeTimer= lifeTime;
    }
    private void Update()
    {
        //to move forward projectile
        transform.position +=transform.forward*speed*Time.deltaTime;
        //decrease the  current life timer
        currentLifeTimer -=Time.deltaTime;
        //instead of destroying the expired bullet, send it back to the pool
        if (currentLifeTimer <= 0f)
        {
            gameObject.SetActive(false);
        }

    }
}
