using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Loop Settings")]
    public float timeLimit = 180f; 
    public EnergyCore coreToProtect;
    public GameObject spawnerManager; 
    public GameObject playerObject; 

    [Header("UI Panels")]
    public GameObject winScreen;
    public GameObject loseScreen;

    private bool isGameOver = false;

    private void OnEnable()
    {
        if (coreToProtect != null)
            coreToProtect.OnCoreDestroyed += TriggerLoseCondition;
    }

    private void OnDisable()
    {
        if (coreToProtect != null)
            coreToProtect.OnCoreDestroyed -= TriggerLoseCondition;
    }

    private void Update()
    {
        if (isGameOver) return;

        timeLimit -= Time.deltaTime;

        if (timeLimit <= 0)
        {
            TriggerWinCondition();
        }
    }

    private void TriggerWinCondition()
    {
        if (isGameOver) return;
        isGameOver = true;
        
        if (winScreen != null) winScreen.SetActive(true);
        EndGameOperations();
    }

    private void TriggerLoseCondition()
    {
        if (isGameOver) return;
        isGameOver = true;
        
        if (loseScreen != null) loseScreen.SetActive(true);
        EndGameOperations();
    }

    private void EndGameOperations()
    {
        if (spawnerManager != null) spawnerManager.SetActive(false); 
        
        if (playerObject != null)
        {
            PlayerController pc = playerObject.GetComponent<PlayerController>();
            if (pc != null) pc.enabled = false;
        }
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f; 
    }
}