using UnityEngine;
using UnityEngine.SceneManagement; // Essencial para mudar de cena

public class GameOverController : MonoBehaviour
{
    // Variável para a cena do jogo (sua fase de plataforma)
    public string levelSceneName = "Level1";
    // Variável para a cena do menu principal
    public string mainMenuSceneName = "MainMenu";

    // Este método é chamado pelo botão "Tentar Novamente"
    public void RestartGame()
    {
        // Garante que o tempo volte ao normal, caso tenha sido pausado pelo GameManager
        Time.timeScale = 1;

        // Recarrega a cena da fase de plataforma
        Debug.Log("Reiniciando o jogo: " + levelSceneName);
        SceneManager.LoadScene(levelSceneName);
    }

    // Este método é chamado pelo botão "Menu Principal"
    public void LoadMainMenu()
    {
        Time.timeScale = 1;

        // Carrega a cena do menu principal
        Debug.Log("Voltando ao Menu Principal: " + mainMenuSceneName);
        SceneManager.LoadScene(mainMenuSceneName);
    }

    // Este método é chamado pelo botão "Sair do Jogo" (opcional)
    public void QuitGame()
    {
        Debug.Log("Saindo do Jogo...");
        Application.Quit();

        // No Editor do Unity, Application.Quit não funciona; use este log para saber que funcionou:
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}