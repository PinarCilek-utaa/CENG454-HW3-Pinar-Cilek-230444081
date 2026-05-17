using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        AlienEnemy hitAlien = collision.gameObject.GetComponent<AlienEnemy>();
        
        if (hitAlien != null)
        {
            Destroy(collision.gameObject);
        }
        gameObject.SetActive(false);
    }
}