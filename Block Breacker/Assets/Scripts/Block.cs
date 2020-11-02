using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    AudioClip breakSound;

    [SerializeField]
    GameObject blockSparklesVFX;

    // Cached References
    Level level;
    GameSession gameStatus;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            gameStatus = FindObjectOfType<GameSession>();
            level = FindObjectOfType<Level>();
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestoySFX();
        level.BlockDestroed();
        FindObjectOfType<GameSession>().AddToScore();
        TriggerSparklesVFX();
    }

    private void PlayBlockDestoySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
