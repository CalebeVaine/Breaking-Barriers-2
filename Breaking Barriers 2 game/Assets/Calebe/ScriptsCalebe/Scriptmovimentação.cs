using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float velocidade = 5f;   
    public float forcaPulo = 7f;   
    private Rigidbody rb;
    private bool noChao = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimento no eixo X e Z (setas ou WASD)
        float moveX = Input.GetAxis("Horizontal"); 
        float moveZ = Input.GetAxis("Vertical");   

        Vector3 movimento = new Vector3(moveX, 0, moveZ) * velocidade;
        Vector3 novaVelocidade = new Vector3(movimento.x, rb.linearVelocity.y, movimento.z);

        rb.linearVelocity = novaVelocidade;

        // Pular com espaço
        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            noChao = true;
        }
    }
}