using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public int documentsCollected = 0;
    public int requiredDocuments = 3;
    public int totalCollectibles = 0;

    public TextMeshProUGUI documentsText;
    public TextMeshProUGUI collectiblesText;
    public TextMeshProUGUI warningText;
    public TextMeshProUGUI timerText;

    public float speedBoostMultiplier = 1.5f;
    public float speedBoostDuration = 4f;

    public bool isTimerActive = false;
    public int playerHealth = 3;
    public float maxTime = 60f;
    private float currentTimer;

    public GameObject smokePanelObject;
    private Player playerScript;

    public string victorySceneName = "VictoryScreen";
    public string gameOverSceneName = "GameOverScreen";

    void Start()
    {
        currentTimer = maxTime;
        UpdateUI();
        UpdateTimerUI();
        Time.timeScale = 1f;

        if (smokePanelObject != null)
        {
            smokePanelObject.SetActive(false);
        }

        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        if (playerGO != null)
        {
            playerScript = playerGO.GetComponent<Player>();
        }
    }

    void Update()
    {
        if (isTimerActive)
        {
            currentTimer -= Time.deltaTime;
            if (currentTimer <= 0)
            {
                currentTimer = 0;
                GameOver();
            }
            UpdateTimerUI();
        }
    }

    public void CollectDocument(int points)
    {
        
        documentsCollected++;
        UpdateUI();
    }

    public void AddCollectible(int value)
    {
        totalCollectibles += value;
        UpdateUI();
    }

    public void PlayerHit()
    {
        playerHealth--;
        if (playerHealth <= 0)
        {
            GameOver();
        }
    }


    public void SetTimerActive(bool state)
    {
        isTimerActive = state;

        if (smokePanelObject != null)
        {
            smokePanelObject.SetActive(state);
        }
    }


    public void ShowWarningText(string text)
    {
        if (warningText != null)
        {
            warningText.text = text;
        }
    }

    void UpdateUI()
    {
        if (documentsText != null)
        {
            documentsText.text = "Documentos: " + documentsCollected + "/" + requiredDocuments;
        }
        if (collectiblesText != null)
        {
            collectiblesText.text = "Conhecimento: " + totalCollectibles;
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(currentTimer / 60f);
            int seconds = Mathf.FloorToInt(currentTimer % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void WinGame()
    {
        Victory();
    }

    public void Victory()
    {
        Time.timeScale = 1f;
        if (!string.IsNullOrEmpty(victorySceneName))
        {
            SceneManager.LoadScene(victorySceneName);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 1f;
        if (!string.IsNullOrEmpty(gameOverSceneName))
        {
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}