using UnityEngine;

public class OlhoCongelado : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite[] enemySprites;

    public Player player; // <-- agora aparece no inspector

    public float switchInterval = 0.5f;
    private float timer;

    private int index = 0;

    // Sprites que deixam o olho "aberto" (congela o player)
    public Sprite[] openEyeSprites;

    private void Update()
    {
        // Atualiza animação do olho
        timer += Time.deltaTime;

        if (timer >= switchInterval)
        {
            timer = 0;
            index++;

            if (index >= enemySprites.Length)
                index = 0;

            sr.sprite = enemySprites[index];

            CheckPlayerFreeze();
        }
    }

    private void CheckPlayerFreeze()
    {
        foreach (var s in openEyeSprites)
        {
            if (sr.sprite == s)
            {
                player.Freeze(true); // congela
                return;
            }
        }

        player.Freeze(false); // libera
    }
}