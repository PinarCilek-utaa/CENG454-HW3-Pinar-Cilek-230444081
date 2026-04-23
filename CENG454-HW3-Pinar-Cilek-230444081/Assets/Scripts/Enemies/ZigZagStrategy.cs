
using UnityEngine;

public class ZigZagStrategy : IEnemyStrategy
{
    public void Move(Transform enemyTransform,Transform targetTransform,float speed)
    {
        //find the main direction:
        Vector3 direction=(targetTransform.position - enemyTransform.position).normalized;
        //find a right vector at a cross angle  to the main direction:
        Vector3 right=Vector3.Cross(Vector3.up , direction);
        //for the amount of right and left deviation of the sine wave over time:
        Vector3 zigzagOffset=right*Mathf.Sin(Time.time * 5f)*2f;
        //to move forward in a zigzag pattern:
        enemyTransform.position +=(direction*speed + zigzagOffset)*Time.deltaTime;

    }
}
