using UnityEngine;

public class SlowZone : MonoBehaviour
{

    [SerializeField] private float slowFactor = 0.5f;


    [SerializeField] private float effectDuration = 9999f;


    private const string PlayerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PlayerTag))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {

                player.ActivateSpeedBoost(slowFactor, effectDuration);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(PlayerTag))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                
                if (player.gameObject.activeInHierarchy)
                {
                    player.ActivateSpeedBoost(1.0f, 0.1f);
                }
            }
        }
    }
}