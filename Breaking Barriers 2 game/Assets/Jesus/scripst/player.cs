using UnityEngine;

public class MovimentoHorizontal : MonoBehaviour
{
    // Velocidade de deslocamento (unidades por segundo)
    public float velocidade = 5f;

    // Referência ao componente Rigidbody2D (opcional, mas recomendado)
    private Rigidbody2D rb;

    void Awake()
    {
        // Busca o Rigidbody2D no mesmo objeto (se houver)
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Lê o eixo horizontal: A/D, ←/→ ou joystick
        float eixoX = Input.GetAxisRaw("Horizontal"); // -1, 0 ou 1

        // Calcula o deslocamento para este frame
        Vector2 movimento = new Vector2(eixoX * velocidade, 0f);

        // Se estiver usando Rigidbody2D, mova com física:
        if (rb != null)
            rb.linearVelocity = new Vector2(movimento.x, rb.linearVelocity.y);
        else
            // Caso não tenha Rigidbody2D, move transform diretamente
            transform.Translate(movimento * Time.deltaTime);
    }
}