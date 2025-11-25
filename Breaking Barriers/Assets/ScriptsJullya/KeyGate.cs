using UnityEngine;

public class KeyGate : MonoBehaviour
{

    [SerializeField] private int requiredKeys = 1;

  
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            if (CheckUnlockCondition())
            {
                UnlockGate();
            }

        }
    }


    private bool CheckUnlockCondition()
    {

        return Player.keysCollected >= requiredKeys;
    }

    private void UnlockGate()
    {
      
        Player.keysCollected -= requiredKeys;

    
        Destroy(gameObject);
    }
}