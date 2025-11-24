using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spritesinimigos : MonoBehaviour
{
    public Sprite[] enemySprites;
    public float switchInterval = 0.5f;

    private SpriteRenderer spriteRenderer;
    private int currentIndex;

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();

   
        if (spriteRenderer != null && enemySprites.Length > 0)
        {
            StartCoroutine(CycleSpritesRoutine());
        }
        else
        {
            Debug.LogError("SpriteRenderer não encontrado ou array de sprites vazio!");
        }
        IEnumerator CycleSpritesRoutine()
        {
            while (true)
            {
                
                yield return new WaitForSeconds(switchInterval);

                
                currentIndex = (currentIndex + 1) % enemySprites.Length;

                spriteRenderer.sprite = enemySprites[currentIndex];
            }
        }
    }
}
