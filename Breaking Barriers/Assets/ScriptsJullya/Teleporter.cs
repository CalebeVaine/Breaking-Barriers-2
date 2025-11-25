using UnityEngine;

public class Teleporter : MonoBehaviour
{
    
    public Transform destination;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (destination != null)
            {
                other.transform.position = destination.position;
            }
            else
            {
                Debug.LogError("O Teleporter não tem um destino definido!");
            }

            
            Destroy(gameObject);
        }
    }
}