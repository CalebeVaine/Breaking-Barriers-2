using UnityEngine;

public class ZonaCongelada : MonoBehaviour
{
    public OlhoCongelado olho;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<Player>();

            if (olho.podeCongelar)
                player.freezeMovement = true;
            else
                player.freezeMovement = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().freezeMovement = false;
        }
    }
}