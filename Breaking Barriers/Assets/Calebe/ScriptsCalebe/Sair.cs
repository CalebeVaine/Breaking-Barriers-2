using UnityEngine;

public class Sair : MonoBehaviour
{
    // Método para sair do jogo
    public void SairdoJogo()
    {
        // Se o jogo estiver rodando no editor, apenas para a execução
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Caso contrário, fecha o jogo
            Application.Quit();
#endif
    }
}