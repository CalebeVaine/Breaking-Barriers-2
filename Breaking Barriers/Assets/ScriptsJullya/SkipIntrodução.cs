using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para gerenciar cenas

// Anexe este script a um GameObject na sua cena de Introdução
public class SkipIntrodução : MonoBehaviour
{
    // Variável para definir qual cena carregar
    [Tooltip("O nome da cena (Scene) a ser carregada após pular a introdução (ex: MainMenu ou Level1).")]
    public string nextSceneName = "MainMenu";

    void Update()
    {
        // Verifica se a tecla 'F' foi pressionada APENAS uma vez neste frame
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Introdução pulada pelo jogador (Tecla 'F'). Carregando a cena: " + nextSceneName);
            LoadNextScene();
        }
    }

    /// <summary>
    /// Função principal para carregar a próxima cena do jogo.
    /// </summary>
    void LoadNextScene()
    {
        // 1. (Opcional) Adicione aqui código para PARAR qualquer animação/vídeo/áudio rodando.
        // Se a introdução for um vídeo (componente VideoPlayer), você pode fazer:
        /*
        VideoPlayer vp = GetComponent<VideoPlayer>();
        if (vp != null)
        {
            vp.Stop();
        }
        */

        // Se a introdução for uma sequência de Coroutines (rotinas), use:
        // StopAllCoroutines(); 

        // 2. Carrega a próxima cena pelo nome.
        SceneManager.LoadScene(nextSceneName);

        // Desativa o script para garantir que o código não seja executado novamente
        enabled = false;
    }
}