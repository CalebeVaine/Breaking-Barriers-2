using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 1;

    [Header("Áudio")]
    public AudioClip collectSound;


    [Tooltip("Volume do som de coleta (0.0 = mudo, 1.0 = volume total).")]
    public float collectVolume = 1.0f;

    private GameManager2 gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager2>();
        if (gameManager == null)
        {
            Debug.LogError("Coin: GameManager não encontrado na cena. O contador de UI não funcionará.");
        }
    }

    public void Collect()
    {
  
        if (collectSound != null)
        {
      
            AudioSource.PlayClipAtPoint(collectSound, transform.position, collectVolume);
        }


        Player.score += points;
        Debug.Log("Ponto coletado! Novo Score: " + Player.score);

        if (gameManager != null)
        {
            gameManager.CollectItem();
        }

   
        Destroy(gameObject);
    }
}