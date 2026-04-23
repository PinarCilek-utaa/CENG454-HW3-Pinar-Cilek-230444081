using System; //for  using Action and Event structure
using UnityEngine;


public class EnergyCore : MonoBehaviour,IDamageable
{
    [SerializeField] private float maxHealth=100f;

    private float currentHealth;

    //Observer Pattern : Events

    public event Action<float> OnHealthChanged; // it triggers event when changes on health bar
    public event Action OnCoreDestroyed; //it triggers event witihout taking parameter when the core exploded

    private void Start()
    {
        currentHealth=maxHealth;
    }
    public void TakeDamage(float amount)
    {
        // amount is "the damage that has taken"
        currentHealth -= amount;
        currentHealth= MathF.Max(0,currentHealth); //current health can't decrease above zero

        OnHealthChanged?.Invoke(currentHealth / maxHealth); //?:if its null continue so nobody listen this event
        //invoke : triggers the event (divide current health with max health and send a percentage value)

        if(currentHealth <= 0)
        {
            //İF current health decrease under or equal zero ,send event systems that  listens this ,about the core has destroyed
            OnCoreDestroyed?.Invoke();
        }

    }

}
