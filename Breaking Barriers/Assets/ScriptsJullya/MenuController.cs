using UnityEngine;
using UnityEngine.SceneManagement; // ESSENCIAL para trabalhar com cenas

public class MenuController : MonoBehaviour
{
    // Variáveis públicas para armazenar os nomes das cenas no Inspector
    [Header("Nomes das Cenas")]
    [Tooltip("Nome da cena que conta a história de Jaqueline (fundo, contexto, lore).")]
    public string nomeCenaHistoria;

    [Tooltip("Nome da cena que inicia a jogabilidade (introdução ao gameplay).")]
    public string nomeCenaNarrativaPrincipal;

    /// <summary>
    /// Carrega a cena de narrativa da história de fundo (Lore) de Jaqueline.
    /// Esta função deve ser atribuída ao botão "História de Jaqueline".
    /// </summary>
    public void CarregarCenaHistoria()
    {
        if (!string.IsNullOrEmpty(nomeCenaHistoria))
        {
            SceneManager.LoadScene(nomeCenaHistoria);
        }
        else
        {
            Debug.LogError("O nome da cena da História não foi definido no Inspector!");
        }
    }

    /// <summary>
    /// Carrega a cena de introdução ao jogo e gameplay.
    /// Esta função deve ser atribuída ao botão "Iniciar Jogo".
    /// </summary>
    public void CarregarCenaIntroducaoJogo()
    {
        if (!string.IsNullOrEmpty(nomeCenaNarrativaPrincipal))
        {
            SceneManager.LoadScene(nomeCenaNarrativaPrincipal);
        }
        else
        {
            Debug.LogError("O nome da cena de Introdução ao Jogo não foi definido no Inspector!");
        }
    }

    // Opcional: Função para sair do jogo (útil para menus principais)
    public void SairDoJogo()
    {
#if UNITY_EDITOR
        // Se estiver no Editor da Unity, para o modo de Play
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Se estiver no build final, encerra o aplicativo
            Application.Quit();
#endif
    }
}