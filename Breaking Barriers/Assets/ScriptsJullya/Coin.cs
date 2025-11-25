using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 1;

    public AudioClip collectSound;

    public float collectVolume = 1.0f;

    private GameManager2 gameManager;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager2>();

        if (gameManager == null)
        {
            Debug.LogError("Coin: GameManager não encontrado na cena. O contador de UI não funcionará.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    public void Collect()
    {

        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position, collectVolume);
        }

        if (gameManager != null)
        {
            gameManager.CollectDocument(points);
        }

        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        Destroy(gameObject);
    }
}