using UnityEngine;
using UnityEngine.UI;

public class Caixa : MonoBehaviour
{
    public GameObject painelDialogo;
    public Text textoDialogo;
    public string[] falas;
    public float tempoEntreLetras = 0.03f;

    private int indice;
    private bool dialogoAtivo;
    private bool escrevendo;

    void Start()
    {
        painelDialogo.SetActive(false);
    }

    void Update()
    {
        if (dialogoAtivo && Input.GetKeyDown(KeyCode.E))
        {
            ProximaFala();
        }
    }

    public void IniciarDialogo()
    {
        if (dialogoAtivo) return;
        painelDialogo.SetActive(true);
        dialogoAtivo = true;
        indice = 0;
        StartCoroutine(MostrarFala(falas[indice]));
    }

    void ProximaFala()
    {
        if (escrevendo) return;

        indice++;
        if (indice < falas.Length)
        {
            StartCoroutine(MostrarFala(falas[indice]));
        }
        else
        {
            painelDialogo.SetActive(false);
            dialogoAtivo = false;
        }
    }

    System.Collections.IEnumerator MostrarFala(string fala)
    {
        escrevendo = true;
        textoDialogo.text = "";
        foreach (char letra in fala)
        {
            textoDialogo.text += letra;
            yield return new WaitForSeconds(tempoEntreLetras);
        }
        escrevendo = false;
    }
}
