using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    public float duration = 5f;
    public float speedMultiplier = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.ActivateSpeedBoost(speedMultiplier, duration);

               
                GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;

                Destroy(gameObject, 0.5f);
            }
        }
    }
}