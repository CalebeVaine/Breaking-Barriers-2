using UnityEngine;

public class DebuffItem : MonoBehaviour
{
  
    public float inversionDuration = 4f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                
                player.ActivateInversion(inversionDuration);

                GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                
                Destroy(gameObject, 0.5f);
            }
        }
    }
}