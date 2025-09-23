using UnityEngine;

public class MovimentoHorizontal : MonoBehaviour
{
    public float velocidade = 5f;            // Velocidade de movimento lateral
    public float forcaDoPulo = 7f;           // Força do primeiro pulo
    public float forcaDoPuloExtra = 10f;    // Força do segundo pulo
    public Transform groundCheck;            // Objeto vazio nos pés do jogador
    public float groundCheckRadius = 0.2f;  // Raio para checar o chão
    public LayerMask groundLayer;            // Layer do chão

    private Rigidbody2D rb;
    private int jumpCount = 0;
    private int maxJumps = 2; // Máximo 2 pulos seguidos
    private bool isGrounded;
    private bool wasGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimento horizontal
        float eixoX = Input.GetAxisRaw("Horizontal"); // -1, 0 ou 1
        rb.linearVelocity = new Vector2(eixoX * velocidade, rb.linearVelocity.y);

        // Checa se está no chão
        wasGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Reseta o contador de pulos ao tocar o chão
        if (isGrounded && !wasGrounded)
        {
            jumpCount = 0;
        }

        // Pular se ainda tiver pulos disponíveis
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // Zera a velocidade vertical antes do pulo

            if (jumpCount == 1) // Segundo pulo
            {
                rb.AddForce(Vector2.up * forcaDoPuloExtra, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(Vector2.up * forcaDoPulo, ForceMode2D.Impulse);
            }

            jumpCount++;
        }
    }

    // Visualizar o raio no editor
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}