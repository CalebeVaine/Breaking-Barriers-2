using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D body;

    public static int score = 0;

    private GameManager2 gameManager;

    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public int health = 1;

    public Animator anim;
    private SpriteRenderer spriteRenderer;

    private bool isFacingRight = true;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        score = 0;

        gameManager = FindObjectOfType<GameManager2>();

        if (anim == null)
            anim = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();

        anim.SetBool("IsWalking", horizontal != 0);
        anim.SetFloat("Speed", Mathf.Abs(horizontal));

        if (horizontal > 0.01f && !isFacingRight)
            FlipSprite(true);
        else if (horizontal < -0.01f && isFacingRight)
            FlipSprite(false);
    }

    void FixedUpdate()
    {
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
            health--;

            if (health <= 0)
            {
                if (gameManager != null)
                    gameManager.PlayerHit();

                this.enabled = false;
            }
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
}