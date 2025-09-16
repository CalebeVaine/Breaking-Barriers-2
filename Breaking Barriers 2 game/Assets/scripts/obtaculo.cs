using UnityEngine;
using UnityEngine.SceneManagement;

public class obtaculo : MonoBehaviour
{
    [SerializeField] private string nomeCenaDestino;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nomeCenaDestino);
        }
    }
}