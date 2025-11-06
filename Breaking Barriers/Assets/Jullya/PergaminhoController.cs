using UnityEngine;

public class PergaminhoController : MonoBehaviour
{
    [Header("Objetos a serem controlados")]
    public GameObject pergaminhoFechadoSprite;
    public GameObject telaConteudoAberto;

    [Header("Referência da Narrativa")]
    // NOVO: Referência ao script que controlará o texto de narrativa.
    public NarrativaPrincipal scriptNarrativa;

    [Header("Configurações")]
    private bool estaAberto = false;

    void Start()
    {
        // ... (resto do seu Start() original)
        if (telaConteudoAberto != null)
        {
            telaConteudoAberto.SetActive(false);
        }

        // Opcional: Verificar se o script de narrativa foi configurado
        if (scriptNarrativa == null)
        {
            Debug.LogError("O Script de NarrativaPrincipal precisa ser configurado no Inspector!");
        }
    }

    void OnMouseDown()
    {
        AlternarEstadoDoPergaminho();
    }

    public void AlternarEstadoDoPergaminho()
    {
        if (telaConteudoAberto == null || pergaminhoFechadoSprite == null)
        {
            Debug.LogError("As referências de Objetos não estão configuradas!");
            return;
        }

        if (estaAberto)
        {
            // FECHAR PERGAMINHO
            telaConteudoAberto.SetActive(false);
            pergaminhoFechadoSprite.SetActive(true);
            estaAberto = false;

            // Opcional: Se você quiser que o jogador possa fechar o pergaminho
            // antes que a narrativa termine, adicione lógica para pausar/resetar a narrativa aqui.
        }
        else
        {
            // ABRIR PERGAMINHO
            pergaminhoFechadoSprite.SetActive(false);
            telaConteudoAberto.SetActive(true);
            estaAberto = true;

            // NOVO: Chama a função que inicia a digitação do texto
            if (scriptNarrativa != null)
            {
                scriptNarrativa.IniciarNarrativa();
            }
        }
    }
}