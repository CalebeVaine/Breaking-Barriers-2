using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 
using System.Collections; 

public class GameManager2 : MonoBehaviour
{
    [Header("Configurações do Tempo")]
    public float timeLimit = 16f * 60f;
    private float timeRemaining;
    private bool isTimerRunning = false;

    [Header("Objetivos do Nível")]
    public int totalCollectibles = 0;
    public int collectiblesCollected = 0;
    public int requiredDocuments = 3; 
    public int documentsCollected = 0;
    public string nextSceneName = "GameOver";

    [Header("Referências de UI")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI countText;
    public GameObject warningTextObject; 

    void Start()
    {
        timeRemaining = timeLimit;
        UpdateUI();
        Time.timeScale = 1;

       
       
        if (warningTextObject != null)
        {
            warningTextObject.SetActive(false);
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
        Debug.Log("Fim do Tempo!");
        Time.timeScale = 0;
        SceneManager.LoadScene(nextSceneName);
    }

    public void PlayerHit()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(nextSceneName);
    }

    public void AddCollectible(int points)
    {
        collectiblesCollected++;
    }

    public void AddDocument()
    {
        documentsCollected++;
        UpdateUI();
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
}