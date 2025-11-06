using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class NarrativaPrincipal : MonoBehaviour
{
    [Header("Configuração de Texto")]
    public string[] falasDaNarrativa;
    public TextMeshProUGUI textoDaNarrativa;

    [Header("Efeito Typewriter")]
    public float velocidadeTypewriter = 0.05f;
    private bool estaDigitando = false;

    [Header("Controle de Cena")]
    public string nomeDaCenaDoJogo = "Nivel1";

    private int indiceAtualDaFala = 0;

    // NOVO: Adicione uma flag para saber se a narrativa já foi iniciada
    private bool narrativaIniciada = false;

    // O Start() agora está vazio, pois não queremos começar imediatamente.
    void Start()
    {
        // Certifique-se de que o texto esteja vazio no início
        if (textoDaNarrativa != null)
        {
            textoDaNarrativa.text = "";
        }
    }

    // UPDATE: Só avance se a narrativa já tiver sido iniciada
    void Update()
    {
        if (narrativaIniciada && Input.GetKeyDown(KeyCode.Space))
        {
            AvancarNarrativa();
        }
    }

    // NOVA FUNÇÃO PÚBLICA: Será chamada pelo script do pergaminho.
    public void IniciarNarrativa()
    {
        if (narrativaIniciada) return; // Impede que a narrativa comece mais de uma vez

        if (falasDaNarrativa.Length > 0)
        {
            narrativaIniciada = true; // Marca como iniciado
            StartCoroutine(EfeitoTypewriter());
        }
        else
        {
            Debug.LogError("O Array de falas está vazio! Adicione falas no Inspector.");
        }
    }

    // O restante das funções (AvancarNarrativa, EfeitoTypewriter, CarregarCenaDoJogo)
    // permanece o mesmo...

    void AvancarNarrativa()
    {
        if (estaDigitando)
        {
            StopAllCoroutines();
            textoDaNarrativa.text = falasDaNarrativa[indiceAtualDaFala];
            estaDigitando = false;
            return;
        }

        if (indiceAtualDaFala < falasDaNarrativa.Length - 1)
        {
            indiceAtualDaFala++;
            StartCoroutine(EfeitoTypewriter());
        }
        else
        {
            CarregarCenaDoJogo();
        }
    }

    IEnumerator EfeitoTypewriter()
    {
        estaDigitando = true;
        string falaCompleta = falasDaNarrativa[indiceAtualDaFala];
        textoDaNarrativa.text = "";

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