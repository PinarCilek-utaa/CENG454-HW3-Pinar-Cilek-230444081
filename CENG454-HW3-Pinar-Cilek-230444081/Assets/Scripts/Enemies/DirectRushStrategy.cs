
using UnityEngine;

public class DirectRushStrategy : IEnemyStrategy
{
    public void Move(Transform enemyTransform,Transform targetTransform, float speed)
    {
        //for find direction to reach target and move in that direction
        Vector3 direction=(targetTransform.position - enemyTransform.position).normalized;
        enemyTransform.position +=direction * speed * Time.deltaTime;
    } 
}
