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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AvancarNarrativa();
        }
    }

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