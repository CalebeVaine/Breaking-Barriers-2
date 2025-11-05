using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 1;

    [Header("Áudio")]
    public AudioClip collectSound;

    // NOVO: Variável pública para controlar o volume
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
        // 1. Toca o efeito sonoro usando o volume definido
        if (collectSound != null)
        {
            // O PlayClipAtPoint AGORA recebe o volume como terceiro parâmetro!
            AudioSource.PlayClipAtPoint(collectSound, transform.position, collectVolume);
        }

        // 2. Aumenta a pontuação
        Player.score += points;
        Debug.Log("Ponto coletado! Novo Score: " + Player.score);

        // 3. Notifica o GameManager
        if (gameManager != null)
        {
            gameManager.CollectItem();
        }

        // 4. Destrói o objeto da moeda
        Destroy(gameObject);
    }
}