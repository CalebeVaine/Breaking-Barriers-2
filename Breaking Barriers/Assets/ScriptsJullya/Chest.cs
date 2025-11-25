using UnityEngine;
using TMPro; 

public class Chest : MonoBehaviour
{
    
    public TextMeshProUGUI warningTextUI;


    public int requiredKeys = 1;


    private bool playerInZone = false;

    
    private bool isOpened = false;

    
    private const string OpenText = "Pressione E para Abrir";

    void Start()
    {
        if (warningTextUI != null)
        {
            warningTextUI.gameObject.SetActive(false);
        }
    }

    void Update()
    {
       
        if (playerInZone && !isOpened && Input.GetKeyDown(KeyCode.E))
        {
            TryOpenChest();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpened)
        {
            playerInZone = true;
          
            ShowWarning(OpenText);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
         
            HideWarning();
        }
    }

    private void TryOpenChest()
    {
      
        if (Player.keysCollected >= requiredKeys)
        {
           
            Debug.Log("Baú Aberto! Chave Usada.");
            Player.keysCollected -= requiredKeys; 

            isOpened = true;
            HideWarning(); 

            

            
        }
        else
        {
            
            ShowWarning("Chave necessária! (" + Player.keysCollected + "/" + requiredKeys + ")");
 
            StartCoroutine(ClearWarningAfterDelay(2f));
        }
    }

    private void ShowWarning(string message)
    {
        if (warningTextUI != null)
        {
            warningTextUI.text = message;
            warningTextUI.gameObject.SetActive(true);
        }
    }

    private void HideWarning()
    {
        if (warningTextUI != null)
        {
            warningTextUI.gameObject.SetActive(false);
        }
    }

    private System.Collections.IEnumerator ClearWarningAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (playerInZone && !isOpened)
        {
          
            ShowWarning(OpenText);
        }
        else
        {
           
            HideWarning();
        }
    }
}