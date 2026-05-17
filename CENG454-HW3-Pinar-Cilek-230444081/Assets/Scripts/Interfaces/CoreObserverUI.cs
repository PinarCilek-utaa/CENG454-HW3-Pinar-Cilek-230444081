using UnityEngine;

public class CoreObserverUI : MonoBehaviour
{
    public EnergyCore coreToObserve;

    private void OnEnable()
    {
        if (coreToObserve != null)
        {
            coreToObserve.OnHealthChanged += UpdateHealthUI;
            coreToObserve.OnCoreDestroyed += HandleGameOver;
        }
    }

    private void OnDisable()
    {
        if (coreToObserve != null)
        {
            coreToObserve.OnHealthChanged -= UpdateHealthUI;
            coreToObserve.OnCoreDestroyed -= HandleGameOver;
        }
    }

    private void UpdateHealthUI(float healthPercentage)
    {
        float currentHealthVisual = healthPercentage * 100f;
        Debug.Log($"<color=orange>ATTENTION! The core is damaged! HEALTH: %{currentHealthVisual}</color>");
    }

    private void HandleGameOver()
    {
        Debug.Log($"<color=red>MISSION FAILED! Core Destroyed!</color>");
    }
}