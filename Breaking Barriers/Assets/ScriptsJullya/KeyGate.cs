using UnityEngine;

public class KeyGate : MonoBehaviour
{
  
    
    [SerializeField] private int requiredKeys = 1; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
     
        if (collision.gameObject.CompareTag("Player"))
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
       
        Destroy(gameObject); 
    }
}