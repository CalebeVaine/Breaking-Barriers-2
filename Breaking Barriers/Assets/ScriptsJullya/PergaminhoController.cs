using UnityEngine;

public class PergaminhoController : MonoBehaviour
{
    [Header("Objetos a serem controlados")]
    public GameObject pergaminhoFechadoSprite;
    public GameObject telaConteudoAberto;

    [Header("Referência da Narrativa")]
   
    public NarrativaPrincipal scriptNarrativa;

    [Header("Configurações")]
    private bool estaAberto = false;

    void Start()
    {

        if (telaConteudoAberto != null)
        {
            telaConteudoAberto.SetActive(false);
        }

   
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
            telaConteudoAberto.SetActive(false);
            pergaminhoFechadoSprite.SetActive(true);
            estaAberto = false;

           
        }
        else
        {
        
            pergaminhoFechadoSprite.SetActive(false);
            telaConteudoAberto.SetActive(true);
            estaAberto = true;

          
            if (scriptNarrativa != null)
            {
                scriptNarrativa.IniciarNarrativa();
            }
        }
    }
}