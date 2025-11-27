using UnityEngine;

public class OlhoCongelado : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite[] enemySprites;

    public float switchInterval = 0.5f;
    private float timer;
    private int index = 0;

    // Sprites que representam o olho aberto
    public Sprite[] openEyeSprites;

    // ESSA variável é o estado real do olho
    [HideInInspector] public bool podeCongelar = false;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchInterval)
        {
            timer = 0;
            index++;

            if (index >= enemySprites.Length)
                index = 0;

            sr.sprite = enemySprites[index];

            AtualizarEstadoDoOlho();

            Debug.Log("Olho pode congelar: " + podeCongelar);
        }
    }

    private void AtualizarEstadoDoOlho()
    {
        // verifica se o sprite ATUAL é um dos abertos
        foreach (var s in openEyeSprites)
        {
            if (sr.sprite == s)
            {
                podeCongelar = true;
                return;
            }
        }

        podeCongelar = false;
    }
}