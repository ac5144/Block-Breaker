using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

    int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;

    const int maxNumLives = 3;
    [SerializeField] int numLives;

    // Unity Methods

    private void Awake() {

        CheckForSingleSession();
    }

    private void Start() {

        ResetLives();
        UpdateScoreText();
    }

    // Private Methods

    private void UpdateScoreText() {

        scoreText.text = currentScore.ToString();
    }

    private void UpdateLivesText() {

        livesText.text = "Lives: " + numLives.ToString();
    }

    private void CheckForSingleSession() {

        int controlCount = FindObjectsOfType<GameSession>().Length;

        if (controlCount > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    // Public Methods

    public void AddToScore(int points) {

        currentScore += points;
        UpdateScoreText();
    }

    public void DecrementLives() {

        numLives--;
        UpdateLivesText();
    }

    public int GetNumLives() {

        return numLives;
    }

    public void ResetLives() {

        numLives = maxNumLives;
        UpdateLivesText();
    }

    public void ResetGame() {

        Destroy(gameObject);
    }
}
