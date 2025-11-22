using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points; 
    public float speed = 2f;
    private int currentPointIndex;

    void Start()
    {
        currentPointIndex = 0;
    }

    void Update()
    {
        if (points.Length == 0) return;

        transform.position = Vector3.MoveTowards(
            transform.position, 
            points[currentPointIndex].position, 
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, points[currentPointIndex].position) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % points.Length;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}