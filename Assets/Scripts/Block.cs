using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip clip;
 

    //Cached reference
    Level level;
    GameStatus gameStatus;
    // Start is called before the first frame update

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();

    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        level.DestroyBlocks();
        gameStatus.AddToScore();
        Destroy(gameObject);
    }
}
