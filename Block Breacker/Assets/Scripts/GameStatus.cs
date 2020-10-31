using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
}
