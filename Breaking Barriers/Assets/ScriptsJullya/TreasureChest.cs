using UnityEngine;
using System.Collections;

public class TreasureChest : MonoBehaviour
{
    private bool isPlayerNear = false;
    private GameManager2 gameManager;

    public Animator anim;
    public GameObject rewardObject;
    public GameObject sparkleEffect;

    public float delayAfterOpen = 1.0f;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager2>();

        if (gameManager == null)
        {
            Debug.LogError("TreasureChest: GameManager2 não encontrado na cena.");
        }

        if (rewardObject != null) rewardObject.SetActive(false);
        if (sparkleEffect != null) sparkleEffect.SetActive(false);

        if (anim == null) anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            OpenChestAndWin();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Pressione E para abrir o Baú!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    private void OpenChestAndWin()
    {
        GetComponent<Collider2D>().enabled = false;
        isPlayerNear = false;

        if (anim != null)
        {
            anim.SetTrigger("Open");
        }

        if (rewardObject != null)
        {
            rewardObject.SetActive(true);
        }

        if (sparkleEffect != null)
        {
            sparkleEffect.SetActive(true);
        }

        StartCoroutine(WinAfterDelay());
    }

    private IEnumerator WinAfterDelay()
    {
        yield return new WaitForSeconds(delayAfterOpen);

        if (gameManager != null)
        {
            gameManager.WinGame();
        }

        Destroy(gameObject);
    }
}