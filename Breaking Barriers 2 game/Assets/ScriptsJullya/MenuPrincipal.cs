using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("Jogo"); 
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos"); 
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Jogo encerrado.");
    }
}
