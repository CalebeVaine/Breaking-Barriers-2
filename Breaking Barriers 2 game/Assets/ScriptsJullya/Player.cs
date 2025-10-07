using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D body;

    public static int score = 0;

    // Referências para o Quiz
    [SerializeField]
    private QuizManager quizManager;
    public int coinsToStartQuiz = 5;
    private bool quizActive = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        score = 0;
        if (quizManager == null)
        {
            quizManager = FindObjectOfType<QuizManager>();
        }
        Time.timeScale = 1;
    }

    void Update()
    {
        // Movimento só é permitido se o quiz NÃO estiver ativo
        if (!quizActive)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }

    void FixedUpdate()
    {
        float currentSpeed = quizActive ? 0 : horizontal * speed;
        // Usa 'velocity' (corrigindo o erro de API obsoleta)
        body.linearVelocity = new Vector2(currentSpeed, body.linearVelocity.y);
    }

    void Jump()
    {
        if (!quizActive)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        }
    }

    // Método chamado pelo script da Coin
    public void AddCoin(int points)
    {
        score += points;
        Debug.Log("Ponto coletado! Novo Score: " + score);

        if (score >= coinsToStartQuiz && !quizActive)
        {
            StartQuiz();
        }
    }

    void StartQuiz()
    {
        if (quizManager != null)
        {
            quizActive = true;
            Time.timeScale = 0; // PAUSA o jogo
            quizManager.ShowQuiz();
        }
    }

    // Método que o QuizManager chama para despausar o jogo (corrigindo o erro CS1061 anterior)
    public void EndQuiz()
    {
        quizActive = false;
        Time.timeScale = 1; // DESPAUSA o jogo
        score = 0; // Reseta o score para começar a próxima contagem
        Debug.Log("Quiz finalizado. Jogo resumido.");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Coin coin = other.GetComponent<Coin>();
            if (coin != null)
            {
                // CHAMADA CORRIGIDA: Passa a referência do Player ('this')
                coin.Collect(this);
            }
        }
    }
}