using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    void Awake() {

        CheckForSingleSession();
    }

    void Start() {

        UpdateScoreText();
    }

    public void AddToScore(int points) {

        currentScore += points;
        UpdateScoreText();
    }

    private void UpdateScoreText() {

        scoreText.text = currentScore.ToString();
    }

    public void ResetGame() {

        Destroy(gameObject);
    }

    private void CheckForSingleSession() {

        int controlCount = FindObjectsOfType<GameSession>().Length;

        if (controlCount > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
}
