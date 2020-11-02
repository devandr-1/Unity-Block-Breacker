using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    [Range(0.5f, 10f)]
    float gameSpeed = 0.5f;

    [SerializeField]
    int pointsPerBlockDestroyed = 83;

    [SerializeField]
    int currentScore = 0;

    [SerializeField]
    TextMeshProUGUI scoreText;

    private void Awake()
    {
        int count = FindObjectsOfType<GameSession>().Length;
        if (count > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
