using UnityEngine;

public interface IEnemyStrategy
{
    void Move(Transform enemyTransform, Transform targetTransform, float speed);
}
