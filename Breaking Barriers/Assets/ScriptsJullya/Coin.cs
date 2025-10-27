using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 1;

    // NOVO: Referência privada ao GameManager
    private GameManager2 gameManager;

    void Start()
    {
        // NOVO: Encontra e armazena a referência ao GameManager logo no início.
        gameManager = FindObjectOfType<GameManager2>();

        if (gameManager == null)
        {
            // Mensagem de erro para alertar se o GameManager estiver faltando na cena.
            Debug.LogError("Coin: GameManager não encontrado na cena. O contador de UI não funcionará.");
        }
    }

    public void Collect()
    {
        // 1. (EXISTENTE) Aumenta o score estático da Jaqueline.
        // Isso é para a pontuação total (se você for usar o 'score' em outro lugar).
        // Lembre-se que 'Player.score' precisa ser estático.
        Player.score += points;
        Debug.Log("Ponto coletado! Novo Score: " + Player.score);

        // 2. (NOVO) Notifica o GameManager que um item foi coletado.
        if (gameManager != null)
        {
            // Chama o método no GameManager para incrementar o contador (collectedCount)
            // e atualizar o 'Count Text' na UI.
            gameManager.CollectItem();
        }

        // 3. (EXISTENTE) Destrói o objeto (a moeda desaparece).
        Destroy(gameObject);
    }
}