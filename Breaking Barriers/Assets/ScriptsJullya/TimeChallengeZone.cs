using UnityEngine;

public class TimeChallengeZone : MonoBehaviour
{
    private GameManager2 gameManager;

    void Start()
    {
       
        gameManager = FindAnyObjectByType<GameManager2>(); 
        
        if (gameManager == null)
        {
            Debug.LogError("TimeChallengeZone: GameManager2 não encontrado!");
            enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
            {
      
                gameManager.SetTimerActive(true); 
                
               
                gameManager.ShowWarningText("ZONA CRONOMETRADA ATIVA"); 
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
            {
             
                gameManager.SetTimerActive(false);
                
                
                gameManager.ShowWarningText(""); 
            }
        }
    }
}