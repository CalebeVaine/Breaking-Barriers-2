using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    [Tooltip("Velocidade do inimigo (ajustar no Inspector).")]
    public float speed = 2f;

    [Header("Pontos de Patrulha")]
    [Tooltip("O ponto de parada mais à esquerda.")]
    public Transform pointA;
    [Tooltip("O ponto de parada mais à direita.")]
    public Transform pointB;

    private Vector3 currentTarget; 

 
    private SpriteRenderer spriteRenderer;

    void Start()
    {
    
        currentTarget = pointB.position;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        transform.position = Vector3.MoveTowards(
            transform.position,
            currentTarget,
            speed * Time.deltaTime
        );

        
        if (transform.position == currentTarget)
        {
       
            if (currentTarget == pointB.position)
            {
              
                currentTarget = pointA.position;
                FlipSprite(false);
            }
            else
            {
                
                currentTarget = pointB.position;
                FlipSprite(true); 
            }
        }
    }


    void FlipSprite(bool facingRight)
    {
        if (spriteRenderer != null)
        {
            
            spriteRenderer.flipX = !facingRight;
        }
    }


    private void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(pointA.position, pointB.position);
            Gizmos.DrawWireSphere(pointA.position, 0.2f);
            Gizmos.DrawWireSphere(pointB.position, 0.2f);
        }
    }
}