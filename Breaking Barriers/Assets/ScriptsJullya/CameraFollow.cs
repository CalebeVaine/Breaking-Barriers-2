using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // O alvo que a câmera deve seguir (o transform do player Jaqueline)
    [Tooltip("Arraste o Game Object do Player (Jaqueline) aqui.")]
    public Transform target;

    // A distância (offset) que a câmera deve manter em relação ao alvo
    [Tooltip("A diferença de posição entre a câmera e o alvo.")]
    public Vector3 offset = new Vector3(0f, 10f, -10f);

    // Velocidade de suavização do movimento da câmera (0 para sem suavização)
    [Tooltip("Define quão rápido a câmera alcança o player. Valores menores são mais suaves.")]
    [Range(0.01f, 1.0f)]
    public float smoothSpeed = 0.125f;

    // A função LateUpdate é chamada depois que todos os objetos do jogo foram atualizados.
    // Isso garante que a câmera segue o player APÓS ele ter se movido naquele frame.
    void LateUpdate()
    {
        // Verifica se o alvo (player) está definido
        if (target == null)
        {
            Debug.LogError("O Alvo (Player) da câmera não está definido no Inspector!");
            return;
        }

        // 1. Calcula a posição desejada: A posição do alvo mais o offset (distância)
        Vector3 desiredPosition = target.position + offset;

        // 2. Aplica a suavização (Lerp): Move a câmera da posição atual para a desejada de forma suave
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // 3. Define a posição final da câmera
        transform.position = smoothedPosition;

        // Opcional: Faz a câmera olhar diretamente para o player
        // Se a câmera estiver em um ângulo Top-Down (cima para baixo), isso pode ser ignorado.
        // transform.LookAt(target); 
    }
}