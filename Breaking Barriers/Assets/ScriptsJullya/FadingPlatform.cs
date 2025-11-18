using UnityEngine;
using System.Collections;

public class FadingPlatform : MonoBehaviour
{
    public float waitBeforeFade = 0.5f;
    public float fadeOutTime = 0.5f;
    public float respawnTime = 3f;

    private SpriteRenderer spriteRenderer;
    private Collider2D platformCollider;
    private Color originalColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        platformCollider = GetComponent<Collider2D>();

        if (spriteRenderer == null || platformCollider == null)
        {
            Debug.LogError("FadingPlatform: Requer um SpriteRenderer e um Collider2D.");
            enabled = false;
        }
        originalColor = spriteRenderer.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeCycle());
        }
    }

    IEnumerator FadeCycle()
    {
        yield return new WaitForSeconds(waitBeforeFade);

        float timer = 0f;

        while (timer < fadeOutTime)
        {
            timer += Time.deltaTime;
            float alpha = 1f - (timer / fadeOutTime);
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        platformCollider.enabled = false;

        yield return new WaitForSeconds(respawnTime);

        timer = 0f;
        platformCollider.enabled = true;

        while (timer < fadeOutTime)
        {
            timer += Time.deltaTime;
            float alpha = (timer / fadeOutTime);
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        spriteRenderer.color = originalColor;
    }
}