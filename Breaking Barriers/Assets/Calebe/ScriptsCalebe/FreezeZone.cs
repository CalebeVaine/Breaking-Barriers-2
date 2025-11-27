using UnityEngine;

public class FreezeZone : MonoBehaviour
{
    public Player player;
    public OlhoCongelado olho;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.freezeMovement = false; // garante que não congela instantâneo
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // congela SOMENTE se o olho puder congelar
            player.freezeMovement = olho.podeCongelar;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.freezeMovement = false; // sempre libera ao sair
        }
    }
}