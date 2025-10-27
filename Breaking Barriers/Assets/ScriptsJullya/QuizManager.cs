using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public GameObject painelQuiz;
    public Text textoPergunta;
    public Button[] botoesResposta;
    public string pergunta;
    public string[] respostas;
    public int indiceCorreto;

    void Start()
    {
        painelQuiz.SetActive(false);
    }

    public void AbrirQuiz()
    {
        painelQuiz.SetActive(true);
        textoPergunta.text = pergunta;

        for (int i = 0; i < botoesResposta.Length; i++)
        {
            botoesResposta[i].GetComponentInChildren<Text>().text = respostas[i];
            int indice = i;
            botoesResposta[i].onClick.RemoveAllListeners();
            botoesResposta[i].onClick.AddListener(() => VerificarResposta(indice));
        }
    }

    void VerificarResposta(int indiceEscolhido)
    {
        if (indiceEscolhido == indiceCorreto)
        {
            Debug.Log("Resposta correta!");
        }
        else
        {
            Debug.Log("Resposta errada!");
        }

        painelQuiz.SetActive(false);
    }
}