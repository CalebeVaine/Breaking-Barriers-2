using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D body;

    public static int score = 0;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        score = 0;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
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
        Debug.Log("Ponto coletado! Novo Score: " + score);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Coin coin = other.GetComponent<Coin>();
            if (coin != null)
            {
                coin.Collect();
            }
        }
    }
}