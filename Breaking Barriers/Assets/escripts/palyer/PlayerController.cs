using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaPulo = 10f;
    public float velocidadeExtra = 8f;
    public float tempoBoost = 0.5f;

    private float velocidadeAtual;
    private Rigidbody2D rig;
    public bool isJumping = false;

    // Pontuação
    public int score = 0;
    public TextMeshProUGUI scoreText;

    // Tecla A
    private float ultimoToqueA = 0f;
    private float tempoEntreToques = 0.3f; // tempo máximo entre cliques duplos

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        velocidadeAtual = velocidade;
        AtualizarPontuacao();
    }

    void Update()
    {
        DetectarDuploToque();
        Move();

        if (!isJumping)
        {
            Jump();
        }
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal, 0f, 0f) * Time.deltaTime * velocidadeAtual;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rig.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    // Detecta duplo toque na tecla A ou a
    void DetectarDuploToque()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Time.time - ultimoToqueA < tempoEntreToques)
            {
                StopAllCoroutines(); // Evita sobreposição de boosts
                StartCoroutine(AumentarVelocidadeTemporariamente());
            }

            ultimoToqueA = Time.time;
        }
    }

    // BOOST de velocidade temporário
    System.Collections.IEnumerator AumentarVelocidadeTemporariamente()
    {
        velocidadeAtual = velocidade + velocidadeExtra;
        yield return new WaitForSeconds(tempoBoost);
        velocidadeAtual = velocidade;
    }

    // Chamado ao coletar um objeto
    public void Collect(int amount)
    {
        score += amount;
        AtualizarPontuacao();
        Debug.Log("Coletado! Pontuação atual: " + score);

        // Ativa boost de velocidade ao coletar
        StopAllCoroutines();
        StartCoroutine(AumentarVelocidadeTemporariamente());
    }

    void AtualizarPontuacao()
    {
        if (scoreText != null)
        {
            scoreText.text = "Itens coletados: " + score;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isJumping = false;
        }
    }
}
