using UnityEngine;

public class MovimentoHorizontal : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaDoPulo = 7f;
    public float forcaDoPuloExtra = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private int jumpCount = 0;
    private int maxJumps = 2;
    private bool isGrounded;
    private bool wasGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimento horizontal
        float eixoX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(eixoX * velocidade, rb.linearVelocity.y); // Corrigido para velocity

        // Checa se está no chão
        wasGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Reseta os pulos ao tocar o chão
        if (isGrounded && !wasGrounded)
        {
            jumpCount = 0;
        }

        // Pulo
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // Zera velocidade vertical antes de pular

            if (jumpCount == 1)
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

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
