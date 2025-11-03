using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class NarrativaController : MonoBehaviour
{
    [Header("Configuração de Texto")]
    public string[] falasDaNarrativa;
    public TextMeshProUGUI textoDaNarrativa;

    [Header("Efeito Typewriter")]
    public float velocidadeTypewriter = 0.05f;
    private bool estaDigitando = false;

    [Header("Controle de Cena")]
    [Tooltip("Nome da cena do Menu Principal/Entrada.")]
    public string nomeDaCenaDoMenu = "CenaMenuPrincipal";

    [Tooltip("Nome da cena que inicia a jogabilidade.")]
    public string nomeDaCenaDoJogo = "Nivel1";

    private int indiceAtualDaFala = 0;

    void Start()
    {
        if (falasDaNarrativa.Length > 0)
        {
            StartCoroutine(EfeitoTypewriter());
        }
        else
        {
            Debug.LogError("O Array de falas está vazio! Adicione falas no Inspector.");
        }
    }

    // Código REATIVADO: Usa a tecla E para chamar a função de avanço.
    void Update()
    {
        // Pula para a próxima frase (ou para o fim do Typewriter) ao pressionar E
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AvancarNarrativa();
        }
    }

    /// <summary>
    /// Avança para a próxima fala da narrativa ou carrega a cena do jogo.
    /// Esta função é chamada ao apertar E ou pelo evento OnClick de um botão "Avançar".
    /// </summary>
    public void AvancarNarrativa()
    {
        if (estaDigitando)
        {
            // Se estiver digitando, pula o efeito e mostra o texto completo
            StopAllCoroutines();
            textoDaNarrativa.text = falasDaNarrativa[indiceAtualDaFala];
            estaDigitando = false;
            return;
        }

        if (indiceAtualDaFala < falasDaNarrativa.Length - 1)
        {
            // Avança para a próxima fala e inicia o efeito typewriter
            indiceAtualDaFala++;
            StartCoroutine(EfeitoTypewriter());
        }
        
    
    }

    IEnumerator EfeitoTypewriter()
    {
        estaDigitando = true;
        string falaCompleta = falasDaNarrativa[indiceAtualDaFala];
        textoDaNarrativa.text = "";

        // Garante que a velocidade não é zero para evitar um loop infinito
        float waitTime = velocidadeTypewriter > 0 ? velocidadeTypewriter : 0.05f;

        foreach (char letra in falaCompleta.ToCharArray())
        {
            textoDaNarrativa.text += letra;
            yield return new WaitForSeconds(waitTime);
        }

        estaDigitando = false;
    }

    /// <summary>
    /// Carrega a cena do jogo (Fim da Narrativa).
    /// </summary>
    
    /// <summary>
    /// Carrega a cena do Menu Principal/Entrada.
    /// Esta função DEVE ser chamada pelo evento OnClick de um botão "Voltar".
    /// </summary>
    public void VoltarParaMenu()
    {
        if (!string.IsNullOrEmpty(nomeDaCenaDoMenu))
        {
            Debug.Log("Voltando para o Menu Principal: " + nomeDaCenaDoMenu);
            SceneManager.LoadScene(nomeDaCenaDoMenu);
        }
        else
        {
            Debug.LogError("O nome da cena do Menu Principal não foi definido no Inspector!");
        }
    }
}