using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 
using System.Collections; 

public class GameManager2 : MonoBehaviour
{
    [Header("Configurações do Tempo")]
    public float timeLimit = 960f;
    private float timeRemaining;
    private bool isTimerRunning = false;

    [Header("Objetivos do Nível")]
    public int totalCollectibles = 0;
    public int collectiblesCollected = 0;
    public int requiredDocuments = 3; 
    public int documentsCollected = 0;
    private int totalCoinsInScene;
    
    public string victorySceneName = "WinScene"; 
    public string defeatSceneName = "GameOver"; 

    [Header("Referências de UI")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI countText;
    public GameObject warningTextObject; 

    [Header("UI de Conhecimento")]
    public GameObject knowledgeTextContainer; 
    public TextMeshProUGUI knowledgeText; 

    void Awake()
    {
        Coin[] allCoins = FindObjectsByType<Coin>(FindObjectsSortMode.None);
        totalCoinsInScene = allCoins.Length;
    }

    void Start()
    {
        timeRemaining = timeLimit;
        UpdateUI();
        Time.timeScale = 1;

        if (warningTextObject != null)
        {
            warningTextObject.SetActive(false);
        }
        
        if (knowledgeTextContainer != null)
        {
            knowledgeTextContainer.SetActive(true);
            UpdateKnowledgeUI(); 
        }
    }

    void Update()
    {
        if (isTimerRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateUI();
        }
        else if (isTimerRunning && timeRemaining <= 0)
        {
            timeRemaining = 0;
            TimeIsUp();
        }
    }

    void UpdateUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        
        if (countText != null)
        {
            countText.text = "Documentos: " + documentsCollected + "/" + requiredDocuments;
        }
    }

    public void TimeIsUp()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(defeatSceneName);
    }

    public void PlayerHit()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(defeatSceneName);
    }

    public void AddCollectible(int points)
    {
        collectiblesCollected++;
        UpdateKnowledgeUI(); 
        CheckCoinWinCondition();
    }

    public void AddDocument()
    {
        documentsCollected++;
        UpdateUI();
    }

    private void UpdateKnowledgeUI()
    {
        if (knowledgeText != null)
        {
            knowledgeText.text = "Conhecimento: " + collectiblesCollected + "/" + totalCoinsInScene;
        }
    }

    public void CheckCoinWinCondition()
    {
        if (collectiblesCollected >= totalCoinsInScene)
        {
            LevelComplete();
        }
    }

    public void CheckWinCondition()
    {
        if (documentsCollected >= requiredDocuments)
        {
            LevelComplete();
        }
    }

    public void LevelComplete()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(victorySceneName); 
    }

    public void SetTimerActive(bool state)
    {
        isTimerRunning = state;
    }

    public void ShowWarningText(float duration)
    {
        StopCoroutine("WarningTextCoroutine"); 
        StartCoroutine(WarningTextCoroutine(duration));
    }

    private IEnumerator WarningTextCoroutine(float duration)
    {
        if (warningTextObject != null)
        {
            warningTextObject.SetActive(true); 
        }
        
        yield return new WaitForSeconds(duration);

        if (warningTextObject != null)
        {
            warningTextObject.SetActive(false); 
        }
    }
    
    public void ShowKnowledgeText(string message, float duration)
    {
    }
}