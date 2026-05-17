using UnityEngine;

public class AlienEnemy : MonoBehaviour
{
    private IEnemyStrategy currentStrategy;
    public Transform coreTarget; 
    public float moveSpeed = 3f;
    public float stopDistance = 3f; 
    
    [Header("Strategy Settings")]
    public bool useZigZagStrategy = false; 
    public float groundOffset = 0f; 

    private float attackRate = 1f; 
    private float nextAttackTime = 0f;

    private void Start()
    {
        if (useZigZagStrategy)
            currentStrategy = new ZigZagStrategy();
        else
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
                if (Terrain.activeTerrain != null)
                {
                    float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position) + Terrain.activeTerrain.transform.position.y;
                    transform.position = new Vector3(transform.position.x, terrainHeight + groundOffset, transform.position.z);
                }
            }
            else 
            {
                if (Time.time >= nextAttackTime)
                {
                    AttackCore();
                    nextAttackTime = Time.time + attackRate;
                }
            }
        }
    }

    private void AttackCore()
    {
        IDamageable core = coreTarget.GetComponent<IDamageable>();
        if (core != null)
        {
            core.TakeDamage(10f); 
        }
    }
    
    public void SetStrategy(IEnemyStrategy newStrategy)
    {
        currentStrategy = newStrategy;
    }
}