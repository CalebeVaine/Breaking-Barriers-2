using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    [Tooltip("Velocidade do inimigo (ajustar no Inspector).")]
    public float speed = 2f;

    // NOVO: Transforms (Objetos Vazios) que definem os limites de patrulha
    [Header("Pontos de Patrulha")]
    [Tooltip("O ponto de parada mais à esquerda.")]
    public Transform pointA;
    [Tooltip("O ponto de parada mais à direita.")]
    public Transform pointB;

    private Vector3 currentTarget; // O ponto para onde o inimigo está se movendo no momento

    // Opcional: Referência ao SpriteRenderer para inverter o sprite
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // 1. Define o primeiro alvo como o Ponto B
        currentTarget = pointB.position;

        // 2. Tenta pegar o SpriteRenderer (para inverter o inimigo)
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 1. Move o inimigo em direção ao alvo atual
        transform.position = Vector3.MoveTowards(
            transform.position,
            currentTarget,
            speed * Time.deltaTime
        );

        // 2. Verifica se o inimigo alcançou o ponto alvo
        if (transform.position == currentTarget)
        {
            // 3. Inverte o alvo:
            if (currentTarget == pointB.position)
            {
                // Se chegou em B, o novo alvo é A
                currentTarget = pointA.position;
                FlipSprite(false); // Vira para a esquerda (se A for à esquerda)
            }
            else
            {
                // Se chegou em A, o novo alvo é B
                currentTarget = pointB.position;
                FlipSprite(true); // Vira para a direita (se B for à direita)
            }
        }
    }

    /// <summary>
    /// Inverte o sprite do inimigo para que ele "olhe" na direção do movimento.
    /// </summary>
    void FlipSprite(bool facingRight)
    {
        if (spriteRenderer != null)
        {
            // O inimigo olha para a direita por padrão. Se estiver indo para a esquerda, inverta.
            spriteRenderer.flipX = !facingRight;
        }
    }

    // Opcional: Desenha linhas no Editor para ver os pontos de patrulha
    private void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(pointA.position, pointB.position);
            Gizmos.DrawWireSphere(pointA.position, 0.2f);
            Gizmos.DrawWireSphere(pointB.position, 0.2f);
        }
    }
}