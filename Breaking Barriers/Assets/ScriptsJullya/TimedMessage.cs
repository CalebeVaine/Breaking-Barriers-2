using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CanvasGroup))]
public class TimedMessage : MonoBehaviour
{
    public float fadeInDuration = 1.0f;
    public float displayDuration = 3.0f;
    public float fadeOutDuration = 1.0f;

    private CanvasGroup canvasGroup;

    void Awake()
    {
        
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
    }

    void Start()
    {
        
        gameObject.SetActive(true); 
        StartCoroutine(SequenceMessage());
    }

    IEnumerator SequenceMessage()
    {
       
        yield return StartCoroutine(Fade(1f, fadeInDuration));


        yield return new WaitForSeconds(displayDuration);

      
        yield return StartCoroutine(Fade(0f, fadeOutDuration));

 
        gameObject.SetActive(false);
    }

    IEnumerator Fade(float targetAlpha, float duration)
    {
        float startAlpha = canvasGroup.alpha;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float normalizedTime = time / duration;
            
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, normalizedTime);
            yield return null;
        }

        
        canvasGroup.alpha = targetAlpha;
    }
}