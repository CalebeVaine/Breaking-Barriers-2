using UnityEngine;

public class SpawnOnTouch : MonoBehaviour
{
    public GameObject objetoParaSpawnar; // O que será criado
    public Transform pontoDeSpawn;       // Onde será criado (opcional)

    private bool jaSpawnou = false;      // Evita múltiplos spawns

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!jaSpawnou && other.CompareTag("Player"))
        {
            // Define onde spawnar: no ponto indicado ou na posição do objeto
            Vector3 posicaoSpawn = pontoDeSpawn != null ? pontoDeSpawn.position : transform.position;

            Instantiate(objetoParaSpawnar, posicaoSpawn, Quaternion.identity);
            jaSpawnou = true;
        }
    }
}
