using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    public float speed = 5f;
    public float jumpForce = 10f; // Adicionei a for�a de pulo que voc� pediu antes
    private Rigidbody2D body;

    // VARI�VEL DE PONTUA��O E TEXTO
    public static int score = 0; // Vari�vel est�tica para ser acessada de qualquer lugar
    // NOTA: Em um jogo real, voc� usaria um script de 'GameManager' para pontua��o.

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        // � sempre bom iniciar a pontua��o
        score = 0;
        Debug.Log("Score inicial: " + score); // Veja o score na janela Console
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        // Exemplo de pulo (permite pulo infinito, como voc� pediu antes)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // CORRIGIDO: Use 'velocity' em vez de 'linearVelocity' (que est� obsoleto)
        body.linearVelocity = new Vector2(horizontal * speed, body.linearVelocity.y);
    }

    void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
    }

    // NOVO M�TODO: Detecta quando o jogador toca em um objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto com o qual colidimos tem a tag "Coin" (Moeda)
        if (other.CompareTag("Coin"))
        {
            // Chamamos o m�todo de coleta da moeda (Coin.cs)
            // A moeda se encarregar� de adicionar a pontua��o e se destruir.
            Coin coin = other.GetComponent<Coin>();
            if (coin != null)
            {
                coin.Collect();
            }
        }
    }
}