using UnityEngine;
using UnityEngine.SceneManagement; // Essencial para mudar de cena

public class GameOverController : MonoBehaviour
{
    public string levelSceneName = "Level1"; 
    
    public string mainMenuSceneName = "MainMenu"; 

 
    public void RestartGame()
    {
        
        Time.timeScale = 1; 
        

        Debug.Log("Reiniciando o jogo: " + levelSceneName);
        SceneManager.LoadScene(levelSceneName);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1; 
        
    
        Debug.Log("Voltando ao Menu Principal: " + mainMenuSceneName);
        SceneManager.LoadScene(mainMenuSceneName);
    }


    public void QuitGame()
    {
        Debug.Log("Saindo do Jogo...");
        Application.Quit();
        
     
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}