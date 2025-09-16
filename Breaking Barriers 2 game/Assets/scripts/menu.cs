using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // Nome da cena do jogo
    public string cenaJogo = "GameScene";

    // Referência ao AudioSource que tocará o som
    public AudioSource somBotao;

    // Função chamada quando o botão for pressionado
    public void Jogar()
    {
        // Toca o som apenas se o AudioSource estiver atribuído
        if (somBotao != null && somBotao.clip != null)
        {
            somBotao.Play();
            // Inicia a coroutine para carregar a cena depois que o som tocar
            StartCoroutine(CarregarCenaDepoisDoSom());
        }
        else
        {
            // Se não tiver som, carrega a cena imediatamente
            SceneManager.LoadScene(cenaJogo);
        }
    }

    private System.Collections.IEnumerator CarregarCenaDepoisDoSom()
    {
        // Espera o tempo de duração do som
        yield return new WaitForSeconds(somBotao.clip.length);

        // Agora carrega a cena
        SceneManager.LoadScene(cenaJogo);
    }
}
