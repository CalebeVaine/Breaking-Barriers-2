using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 1; // Quantos pontos esta moeda vale

    public void Collect()
    {
        // 1. Adiciona a pontuação no Player
        Player.score += points;

        // 2. Exibe o novo score no Console
        Debug.Log("Ponto coletado! Novo Score: " + Player.score);

        // 3. Destrói o objeto (faz a moeda desaparecer)
        Destroy(gameObject);
    }
}