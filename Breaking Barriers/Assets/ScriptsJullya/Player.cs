using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private float horizontal;
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D body;

    private float originalSpeed;

    public int extraJumps = 1;
    private int jumpsLeft;

    public static int score = 0;
    public static int keysCollected = 0;

    private GameManager2 gameManager;

    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public int health = 1;

    public Animator anim;
    private SpriteRenderer spriteRenderer;

    private bool isFacingRight = true;
    private bool isControlsInverted = false;

    //ADICIONADO: variável de congelamento
    public bool frozen = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        score = 0;
        keysCollected = 0;
        originalSpeed = speed;
        jumpsLeft = extraJumps;

        gameManager = FindFirstObjectByType<GameManager2>();

        if (anim == null)
            anim = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //SE TIVER CONGELADO, NÃO FAZ NADA
        if (frozen)
        {
            body.linearVelocity = Vector2.zero;
            anim.SetBool("IsWalking", false);
            return;
        }

        float rawInput = Input.GetAxisRaw("Horizontal");
        horizontal = isControlsInverted ? -rawInput : rawInput;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if (isGrounded)
        {
            jumpsLeft = extraJumps;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
            }
            else if (jumpsLeft > 0)
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, 0f);

                Jump();
                jumpsLeft--;
            }
        }

        anim.SetBool("IsWalking", horizontal != 0);
        anim.SetFloat("Speed", Mathf.Abs(horizontal));

        if (horizontal > 0.01f && !isFacingRight)
            FlipSprite(true);
        else if (horizontal < -0.01f && isFacingRight)
            FlipSprite(false);
    }

    void FixedUpdate()
    {
        //Impede movimento quando congelado
        if (frozen)
        {
            if (frozen)
            {
                body.linearVelocity = Vector2.zero;
                return;
            }
        }

        float currentSpeed = horizontal * speed;
        body.linearVelocity = new Vector2(currentSpeed, body.linearVelocity.y);
    }

    void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
    }

    public void AddCoin(int points)
    {
        score += points;
    }

    public void AddKey()
    {
        keysCollected++;
        Debug.Log("Chaves Coletadas: " + keysCollected);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Coin coin = other.GetComponent<Coin>();
            if (coin != null)
                coin.Collect();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (gameManager != null)
                gameManager.PlayerHit();
        }
    }

    private void FlipSprite(bool faceRight)
    {
        isFacingRight = faceRight;
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = !faceRight;
        }
        else
        {
            Vector3 s = transform.localScale;
            s.x = Mathf.Abs(s.x) * (faceRight ? 1f : -1f);
            transform.localScale = s;
        }
    }

    public void ActivateSpeedBoost(float multiplier, float duration)
    {
        StopCoroutine("SpeedBoostCoroutine");
        StartCoroutine(SpeedBoostCoroutine(multiplier, duration));
    }

    private IEnumerator SpeedBoostCoroutine(float multiplier, float duration)
    {
        speed = originalSpeed * multiplier;
        yield return new WaitForSeconds(duration);
        speed = originalSpeed;
    }

    public void ActivateInversion(float duration)
    {
        StopCoroutine("InversionCoroutine");
        StartCoroutine(InversionCoroutine(duration));
    }

    private IEnumerator InversionCoroutine(float duration)
    {
        isControlsInverted = true;
        yield return new WaitForSeconds(duration);
        isControlsInverted = false;
    }

    //ADICIONADO: Função chamada pelo inimigo
    public void Freeze(bool state)
    {
        frozen = state;

        if (state) // Congelar
        {
            body.linearVelocity = Vector2.zero;
        }
    }

}