using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Necessário para usar Coroutines

public class SceneTransition : MonoBehaviour
{
    [Tooltip("Nome da cena a ser carregada (ex: MainMenu, Level1, GameOver).")]
    public string nextSceneName = "MainMenu";

    [Tooltip("Tempo de espera (em segundos) antes de carregar a cena. Use 0 para carregar imediatamente.")]
    public float transitionDelay = 0f;

    /// <summary>
    /// Inicia o processo de transição de cena.
    /// </summary>
    public void LoadNextScene()
    {
        // Garante que o jogo não está pausado, caso esteja vindo do Game Over.
        Time.timeScale = 1;

        if (transitionDelay > 0)
        {
            // Se houver um atraso, inicia uma coroutine
            StartCoroutine(DelayBeforeLoading(nextSceneName, transitionDelay));
        }
        else
        {
            // Se não houver atraso, carrega imediatamente
            SceneManager.LoadScene(nextSceneName);
        }
    }

    /// <summary>
    /// Coroutine que espera um tempo definido e então carrega a cena.
    /// </summary>
    IEnumerator DelayBeforeLoading(string sceneName, float delay)
    {
        // Pausa a execução do código por 'delay' segundos
        yield return new WaitForSeconds(delay);

        // Verifica se o nome da cena é válido
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("SceneTransition: O nome da cena não foi definido.");
        }
        else
        {
            // Carrega a cena
            SceneManager.LoadScene(sceneName);
        }
    }

    /// <summary>
    /// Função reutilizável para carregar uma cena específica sem precisar configurar a variável pública.
    /// Útil para botões de menu.
    /// </summary>
    public void LoadSpecificScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
}