using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize=20; // max size of projectile at the same 
    private Queue<GameObject> pool=new Queue<GameObject>(); //queue structure where the projectiles will be arranged

    private void Start()
    {
        //when thr game start we fill the queue
        for (int i = 0; i < poolSize; i++)
        {
            //produce new projectile
            GameObject obj=Instantiate(prefab);
            //then hide
            obj.SetActive(false);
            //add to queue
            pool.Enqueue(obj);
        }
    }

    public GameObject GetObjectFromPool(Vector3 position ,Quaternion rotation)
    {
        //the defense will use this function when it wants to fire a projectile
        //check if there are any projectiles in the pool
        if (pool.Count > 0)
        {
            //take the projectile at the top of the queue
            GameObject obj=pool.Dequeue();
            //adjust the bullet's position on the scene relative to the muzzle of the gun:
            obj.transform.position=position;
            obj.transform.rotation=rotation;
            //make the projectile visible:this runs the OnEnable function in the Projectile and it reset the projectile
            obj.SetActive(true);
            //the projectile is sent to the very end of the tail so that it can be reused
            pool.Enqueue(obj);
            return obj;//give projectile to defense
        }
        //if the pool is empty do nothing:
        return null;
    }
}
