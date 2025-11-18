using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class GameManager2 : MonoBehaviour
{
    
    [Header("Objetivos do Nível")]
    public float timeLimit = 60f; 
    public int totalCollectibles = 5; 

    private int collectedCount = 0;
    private float timeRemaining;

    
    [Header("Referências de UI")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI countText;

    [Header("Cenas de Fim de Jogo")]
    public string victorySceneName = "Level2";
    public string gameOverSceneName = "GameOver";


    void Start()
    {
        timeRemaining = timeLimit;
        UpdateUI();
        Time.timeScale = 1;
    }

    void Update()
    {
        
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateUI();
        }
        else
        {
            
            timeRemaining = 0;
            EndGame(false); 
        }
    }

    public void CollectItem()
    {
        collectedCount++;
        UpdateUI();

        
        if (collectedCount >= totalCollectibles)
        {
            EndGame(true); 
        }
    }

    
    public void PlayerHit()
    {
        
        EndGame(false);
    }

   
    void UpdateUI()
    {
        
        if (timerText != null)
        {
            timerText.text = "Tempo: " + Mathf.Max(0, timeRemaining).ToString("F1");
        }
        
        if (countText != null)
        {
            countText.text = "Conhecimento: " + collectedCount + " / " + totalCollectibles;
        }
    }

   
    void EndGame(bool success)
    {
        
        if (Time.timeScale == 0) return;

        Time.timeScale = 0; 

        if (success)
        {
            Debug.Log("VITÓRIA! Preparando para a próxima fase.");
            SceneManager.LoadScene(victorySceneName);
        }
        else
        {
            Debug.Log("DERROTA! Reiniciando ou indo para Game Over.");
            
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}