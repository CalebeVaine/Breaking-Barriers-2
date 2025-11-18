using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    [Tooltip("Arraste o Game Object do Player (Jaqueline) aqui.")]
    public Transform target;


    [Tooltip("A diferença de posição entre a câmera e o alvo.")]
    public Vector3 offset = new Vector3(0f, 10f, -10f);


    [Tooltip("Define quão rápido a câmera alcança o player. Valores menores são mais suaves.")]
    [Range(0.01f, 1.0f)]
    public float smoothSpeed = 0.125f;

  
    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogError("O Alvo (Player) da câmera não está definido no Inspector!");
            return;
        }

        Vector3 desiredPosition = target.position + offset;

  
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);


        transform.position = smoothedPosition;

     
    }
}