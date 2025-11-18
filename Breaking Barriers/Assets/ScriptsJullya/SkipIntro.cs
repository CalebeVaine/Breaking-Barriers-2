using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para gerenciar cenas

public class SkipIntro : MonoBehaviour
{
    // Variável para definir qual cena carregar
    [Tooltip("O nome da cena (Scene) a ser carregada após pular a introdução (ex: MainMenu ou Level1).")]
    public string nextSceneName = "MainMenu";

    void Update()
    {

    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
        enabled = false;
    }
}