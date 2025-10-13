using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaPulo = 12f;
    public Transform checarChao;
    public float raioChao = 0.2f;
    public LayerMask camadaChao;

    private Rigidbody2D rb;
    private bool estaNoChao;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Mover();
        Pular();
    }

    void Mover()
    {
        float movimento = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movimento * velocidade, rb.velocity.y);

        if (movimento > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (movimento < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void Pular()
    {
        estaNoChao = Physics2D.OverlapCircle(checarChao.position, raioChao, camadaChao);

        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            rb.velocity = new Vector2(rb.velocity.x, forcaPulo);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (checarChao != null)
            Gizmos.DrawWireSphere(checarChao.position, raioChao);
    }
}