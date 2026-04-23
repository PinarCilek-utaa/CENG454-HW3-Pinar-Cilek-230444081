using UnityEngine;

public class AlienEnemy : MonoBehaviour
{
    private IEnemyStrategy currentStrategy;
    public Transform coreTarget; //the position of Core
    public float moveSpeed=3f;

    private void Start()
    {
        currentStrategy=new DirectRushStrategy();
        //this is initial strategy
    }
    private void Update()
    {
        //for every frame , apply strategy which you are use
        if(currentStrategy !=null && coreTarget != null)
        {
            currentStrategy.Move(this.transform,coreTarget,moveSpeed);
        }
    }
    public void SetStrategy(IEnemyStrategy newStrategy)
    {
        //even if we playing game, we can change enemy strategy at that time with this funciton
        currentStrategy=newStrategy;
    }
}
