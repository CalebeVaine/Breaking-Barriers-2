using UnityEngine;

public class FreezeZone : MonoBehaviour
{
    public OlhoCongelado olho;        // Referência ao olho
    public Rigidbody2D rb;            // Rigidbody do player
    public float freezeTime = 1.5f;   // Duração do congelamento

    private bool isFrozen = false;
    private float freezeTimer = 0f;

    private float originalGravity;

    void Start()
    {
        originalGravity = rb.gravityScale;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;

        if (olho.podeCongelar && !isFrozen)
        {
            Congelar();
        }
    }

    void Update()
    {
        if (!isFrozen) return;

        freezeTimer -= Time.deltaTime;

        if (freezeTimer <= 0)
        {
            Descongelar();
        }
    }

    void Congelar()
    {
        isFrozen = true;
        freezeTimer = freezeTime;

        // Congela corretamente sem bug de ficar preso no chão
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void Descongelar()
    {
        isFrozen = false;

        // Libera o corpo SEM grudar no chão
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = originalGravity;
    }
}