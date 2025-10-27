using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Adicione se estiver usando TextMeshPro para a UI

public class GameManager2 : MonoBehaviour
{
    // Variáveis de Jogo
    [Header("Objetivos do Nível")]
    public float timeLimit = 60f; // Limite de 60 segundos
    public int totalCollectibles = 5; // Quantos objetos precisam ser coletados

    private int collectedCount = 0;
    private float timeRemaining;

    // Referências de UI (Opcional, mas recomendado)
    [Header("Referências de UI")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI countText;

    // Nome da cena para Vitória e Derrota
    [Header("Cenas de Fim de Jogo")]
    public string victorySceneName = "Level2";
    public string gameOverSceneName = "GameOver";


    void Start()
    {
        timeRemaining = timeLimit;
        UpdateUI();
        Time.timeScale = 1; // Garante que o jogo esteja rodando
    }

    void Update()
    {
        // Contagem regressiva
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateUI();
        }
        else
        {
            // Tempo esgotado!
            timeRemaining = 0;
            EndGame(false); // Fim de jogo por tempo esgotado
        }
    }

    /// <summary>
    /// Chamado pelo script Collectible quando um item é pego.
    /// </summary>
    public void CollectItem()
    {
        collectedCount++;
        UpdateUI();

        // Condição de Vitória: Coletou todos os itens
        if (collectedCount >= totalCollectibles)
        {
            EndGame(true); // Fim de jogo por vitória
        }
    }

    /// <summary>
    /// Chamado pelo PlayerController quando o jogador é atingido por um inimigo.
    /// </summary>
    public void PlayerHit()
    {
        // Nesta fase, o desvio é a principal mecânica, então ser atingido resulta em derrota/reinício.
        EndGame(false);
    }

    /// <summary>
    /// Atualiza o texto na interface do usuário (UI).
    /// </summary>
    void UpdateUI()
    {
        // Atualiza o cronômetro
        if (timerText != null)
        {
            timerText.text = "Tempo: " + Mathf.Max(0, timeRemaining).ToString("F1"); // Exibe com uma casa decimal
        }
        // Atualiza a contagem
        if (countText != null)
        {
            countText.text = "Conhecimento: " + collectedCount + " / " + totalCollectibles;
        }
    }

    /// <summary>
    /// Encerra o jogo e carrega a cena apropriada.
    /// </summary>
    void EndGame(bool success)
    {
        // Garante que a função não seja chamada múltiplas vezes
        if (Time.timeScale == 0) return;

        Time.timeScale = 0; // Pausa o jogo (útil antes de carregar a cena)

        if (success)
        {
            Debug.Log("VITÓRIA! Preparando para a próxima fase.");
            SceneManager.LoadScene(victorySceneName);
        }
        else
        {
            Debug.Log("DERROTA! Reiniciando ou indo para Game Over.");
            // Pode ir para uma tela de Game Over ou recarregar a fase
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}