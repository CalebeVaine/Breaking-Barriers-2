using UnityEngine;

public class CollectibleKey : MonoBehaviour
{
    private GameManager2 gameManager;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager2>(); 
        
        if (gameManager == null)
        {
            Debug.LogError("ERRO FATAL: GameManager2 não encontrado. A coleta não funcionará.");
            enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      
        Debug.Log("Gatilho acionado com: " + other.gameObject.name + " (Tag: " + other.tag + ")");

        if (other.CompareTag("Player"))
        {

            Debug.Log("SUCESSO: Player detectado. Iniciando a coleta.");

            if (gameManager != null)
            {
                gameManager.AddDocument();
               
                Debug.Log("SUCESSO: Chamada AddDocument() enviada ao GameManager.");
            }
            
            
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            Destroy(gameObject, 0.1f);
        }
        else
        {
             Debug.Log("Objeto colidido não é o Player. Tag atual: " + other.tag + ".");
        }
    }
}