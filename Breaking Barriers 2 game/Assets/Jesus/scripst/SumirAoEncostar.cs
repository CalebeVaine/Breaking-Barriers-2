using UnityEngine;

public class SumirAoEncostar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false); // Faz o OBJETO sumir
        }
    }
}