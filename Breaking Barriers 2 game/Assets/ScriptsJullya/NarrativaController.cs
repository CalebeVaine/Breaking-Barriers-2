using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections; // Necessário para usar Coroutines

public class NarrativaController : MonoBehaviour
{
    [Header("Configuração de Texto")]
    public string[] falasDaNarrativa;
    public TextMeshProUGUI textoDaNarrativa;

    [Header("Efeito Typewriter")]
    // Velocidade em que os caracteres aparecem (quanto menor, mais rápido)
    public float velocidadeTypewriter = 0.05f;
    private bool estaDigitando = false;

    [Header("Controle de Cena")]
    public string nomeDaCenaDoJogo = "Nivel1";

    private int indiceAtualDaFala = 0;

    void Start()
    {
        if (falasDaNarrativa.Length > 0)
        {
            // Começa o efeito typewriter na primeira fala
            StartCoroutine(EfeitoTypewriter());
        }
        else
        {
            Debug.LogError("O Array de falas está vazio! Adicione falas no Inspector.");
        }
    }

    void Update()
    {
        // Verifica se a tecla 'E' foi pressionada
        if (Input.GetKeyDown(KeyCode.E))
        {
            AvancarNarrativa();
        }
    }

    void AvancarNarrativa()
    {
        // 1. Se o texto ainda estiver sendo digitado, pula para o final da frase atual.
        if (estaDigitando)
        {
            StopAllCoroutines(); // Para a Coroutine atual
            textoDaNarrativa.text = falasDaNarrativa[indiceAtualDaFala];
            estaDigitando = false; // Indica que a digitação terminou
            return;
        }

        // 2. Se a digitação já terminou, avança para a próxima fala ou cena.
        if (indiceAtualDaFala < falasDaNarrativa.Length - 1)
        {
            // Avança para a próxima fala e inicia o efeito
            indiceAtualDaFala++;
            StartCoroutine(EfeitoTypewriter());
        }
        else
        {
            CarregarCenaDoJogo();
        }
    }

    // Coroutine que faz o efeito de máquina de escrever
    IEnumerator EfeitoTypewriter()
    {
        estaDigitando = true;
        string falaCompleta = falasDaNarrativa[indiceAtualDaFala];
        textoDaNarrativa.text = ""; // Limpa o texto antes de começar a digitar

        foreach (char letra in falaCompleta.ToCharArray())
        {
            textoDaNarrativa.text += letra;
            yield return new WaitForSeconds(velocidadeTypewriter);
        }

        estaDigitando = false;
    }

    void CarregarCenaDoJogo()
    {
        Debug.Log("Fim da narrativa. Carregando cena: " + nomeDaCenaDoJogo);
        SceneManager.LoadScene(nomeDaCenaDoJogo);
    }
}