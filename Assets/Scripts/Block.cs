using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject blockSparklesVFX;
   
    [SerializeField] Sprite[] hitSprites;

    // state variables
    [SerializeField] int timesHit; //serialized for debug purposes
 

    //Cached reference
    Level level;
    GameSession gameStatus;
    // Start is called before the first frame update

    private void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();
        CountBreaklableBlocks();

    }

    private void CountBreaklableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }

    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
           
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array"+gameObject.name);
        
        }
        
    }

    private void DestroyBlock()
    {
      
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
            level.DestroyBlocks();
            Destroy(gameObject);
            TriggerSparklesVFX();
            gameStatus.AddToScore();
       
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX,transform.position,transform.rotation);
        Destroy(sparkles, 1f);
    }

}
