using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuController : MonoBehaviour
{
   
    [Header("Nomes das Cenas")]
    [Tooltip("Nome da cena que conta a história de Jaqueline (fundo, contexto, lore).")]
    public string nomeCenaHistoria;

    [Tooltip("Nome da cena que inicia a jogabilidade (introdução ao gameplay).")]
    public string nomeCenaNarrativaPrincipal;

    

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

    
    public void SairDoJogo()
    {
#if UNITY_EDITOR
    
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Se estiver no build final, encerra o aplicativo
            Application.Quit();
#endif
    }
}