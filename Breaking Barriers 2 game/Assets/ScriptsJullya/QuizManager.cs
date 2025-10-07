using UnityEngine;
using TMPro; // Não se esqueça de importar
using UnityEngine.UI;

// Estrutura para manter os dados da pergunta organizados
[System.Serializable]
public class Question
{
    public string questionText;
    public string[] answers;
    public int correctAnswerIndex; // O índice da resposta correta (0, 1, 2, ou 3)
}

public class QuizManager : MonoBehaviour
{
    // Referências de UI que você precisa arrastar no Inspector
    public GameObject quizPanel;
    public TextMeshProUGUI questionTextUI;
    public Button[] answerButtons;

    // Dados do Quiz
    public Question[] questions;
    private Player player;
    private int currentQuestionIndex = 0;

    void Awake()
    {
        quizPanel.SetActive(false);
        player = FindObjectOfType<Player>();
    }

    public void ShowQuiz()
    {
        quizPanel.SetActive(true);
        currentQuestionIndex = 0;
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        if (currentQuestionIndex >= questions.Length)
        {
            FinishQuiz(true); // Sucesso se todas as perguntas acabarem
            return;
        }

        Question q = questions[currentQuestionIndex];
        questionTextUI.text = q.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = q.answers[i];

            // Limpa e adiciona o Listener
            answerButtons[i].onClick.RemoveAllListeners();
            int index = i;
            answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    public void CheckAnswer(int selectedAnswerIndex)
    {
        Question currentQuestion = questions[currentQuestionIndex];

        if (selectedAnswerIndex == currentQuestion.correctAnswerIndex)
        {
            Debug.Log("Resposta Correta!");
            currentQuestionIndex++;
            DisplayQuestion();
        }
        else
        {
            Debug.Log("Resposta Incorreta! Fim do Quiz.");
            FinishQuiz(false); // Falha no Quiz
        }
    }

    void FinishQuiz(bool success)
    {
        quizPanel.SetActive(false);

        if (player != null)
        {
            player.EndQuiz(); // Chama o método corrigido no Player para despausar
        }

        if (success)
        {
            Debug.Log("PARABÉNS! Você completou o Quiz!");
        }
        else
        {
            Debug.Log("Você errou e o Quiz foi encerrado.");
        }
    }
}