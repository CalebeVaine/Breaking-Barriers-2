using UnityEngine;

public class CollectibleKey : MonoBehaviour
{
    

    public AudioClip collectSound;
    public float collectVolume = 1.0f;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            Player playerComponent = other.GetComponent<Player>();

            if (playerComponent != null)
            {
                playerComponent.AddKey();
            }

         
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position, collectVolume);
            }

          
            Destroy(gameObject);
        }
    }
}