using UnityEngine;

public class Coletavel : MonoBehaviour
{
    public int valor = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController pc = other.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.Collect(valor);
                Destroy(gameObject);
            }
        }
    }
}
