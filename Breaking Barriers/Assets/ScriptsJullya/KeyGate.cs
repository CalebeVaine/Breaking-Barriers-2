using UnityEngine;

public class KeyGate : MonoBehaviour
{
    private GameManager2 gameManager;
    private bool isLocked = true;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager2>();
        
        if (gameManager == null)
        {
            Debug.LogError("KeyGate: GameManager2 não encontrado.");
            enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isLocked)
        {
            CheckUnlockCondition();
        }
    }
    
    private void CheckUnlockCondition()
    {
        if (gameManager.documentsCollected >= gameManager.requiredDocuments)
        {
            UnlockGate();
        }
    }

    private void UnlockGate()
    {
        isLocked = false;
        gameObject.SetActive(false); 
    }
}