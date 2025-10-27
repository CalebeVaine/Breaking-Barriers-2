using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 1;

    public void Collect()
    {
        Player.score += points;
        Debug.Log("Ponto coletado! Novo Score: " + Player.score);
        Destroy(gameObject);
    }
}