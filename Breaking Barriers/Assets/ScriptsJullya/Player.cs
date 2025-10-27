using UnityEngine;

public class Player : MonoBehaviour
{
    // --- Vari�veis de Movimento Existentes ---
    private float horizontal;
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D body;

    // --- Vari�veis de Jogo e Refer�ncias ---
    public static int score = 0;

    // Novo: Refer�ncia para o GameManager
    private GameManager2 gameManager;

    // Novo: Vari�veis de Controle de Pulo
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    // Novo: Pontos de vida (Opcional, mas bom para colis�es)
    public int health = 1;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        score = 0; // Reinicia o score ao iniciar a fase

        // Novo: Encontra o GameManager na cena
        gameManager = FindObjectOfType<GameManager2>();
        if (gameManager == null)
        {
            Debug.LogError("Player: O GameManager n�o foi encontrado na cena! A l�gica de derrota n�o funcionar�.");
        }
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        // Novo: Verifica se o jogador est� no ch�o
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Novo: S� permite pular se estiver no ch�o
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        float currentSpeed = horizontal * speed;
        // Ajustando a atribui��o de velocidade (pode variar de acordo com a vers�o do Unity)
        // body.linearVelocity � uma propriedade mais direta do Rigidbody2D
        body.linearVelocity = new Vector2(currentSpeed, body.linearVelocity.y);
    }

    void Jump()
    {
        // Aplica a for�a de pulo no eixo Y
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
    }

    // --- M�todos de Intera��o ---

    public void AddCoin(int points)
    {
        score += points;
        Debug.Log("Ponto coletado! Novo Score: " + score);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // L�gica de coleta de "P�ginas de Conhecimento" (Coin)
        if (other.CompareTag("Coin"))
        {
            // Note: O item Coin deve ter o script Collectible/Coin
            Coin coin = other.GetComponent<Coin>();
            if (coin != null)
            {
                coin.Collect();
                // Assumindo que Coin.Collect() chama Player.AddCoin internamente ou que voc� far� isso no script Coin.
                // Se AddCoin for chamado aqui: AddCoin(1);
            }
        }
    }

    // Novo: L�gica de Colis�o com Inimigos
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Se Jaqueline for atingida pelo "Eco do Preconceito" (Enemy)
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Diminui a vida ou causa a derrota instant�nea
            health--;
            Debug.Log("Jaqueline foi atingida pelo preconceito!");

            if (health <= 0)
            {
                // Notifica o GameManager da derrota
                if (gameManager != null)
                {
                    gameManager.PlayerHit();
                }
                // Desativa o movimento do jogador imediatamente para evitar mais intera��es
                this.enabled = false;
            }
            // Opcional: Adicione l�gica de dano visual (piscar, som)
        }
    }
}