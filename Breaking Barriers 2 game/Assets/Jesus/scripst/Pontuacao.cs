using UnityEngine;
using TMPro; // Importa o TMP

public class Pontuacao : MonoBehaviour
{
    public static Pontuacao Instance;

    private int pontosAtuais = 0;

    [SerializeField] private TextMeshProUGUI textoPontos; // Referência ao TMP na tela

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AdicionarPontos(int valor)
    {
        pontosAtuais += valor;
        AtualizarTexto();
    }

    private void AtualizarTexto()
    {
        if (textoPontos != null)
        {
            textoPontos.text = "Pontos: " + pontosAtuais;
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI não está atribuído na Pontuacao.cs");
        }
    }
}