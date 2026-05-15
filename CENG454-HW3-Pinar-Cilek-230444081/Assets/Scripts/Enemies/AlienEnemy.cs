using UnityEngine;
public class AlienEnemy : MonoBehaviour
{
    private IEnemyStrategy currentStrategy;
    public Transform coreTarget; 
    public float moveSpeed = 3f;
    public float stopDistance = 3f; 
    private void Start()
    {
        currentStrategy = new DirectRushStrategy();
    }
    private void Update()
    {
        if(currentStrategy != null && coreTarget != null)
        {
            float distance = Vector3.Distance(transform.position, coreTarget.position);
            if (distance > stopDistance)
            {
                Vector3 lookPosition = new Vector3(coreTarget.position.x, transform.position.y, coreTarget.position.z);
                transform.LookAt(lookPosition);
                currentStrategy.Move(this.transform, coreTarget, moveSpeed);
            }
            else 
            {
            }
        }
    }
    public void SetStrategy(IEnemyStrategy newStrategy)
    {
        currentStrategy = newStrategy;
    }
}