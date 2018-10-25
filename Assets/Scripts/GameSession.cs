using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

    // Score Variables
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    [Range(0.1f, 2f)] [SerializeField] float gameSpeed = 1f;

    // Score Methods
    public void addScore(int points) {

        currentScore += points;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame() {

        Destroy(gameObject);
    }

    // Unity Methods

    void Awake() {

        int controlCount = FindObjectsOfType<GameSession>().Length;
        if (controlCount > 1) {

            Destroy(gameObject);
        }
        else {

            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start () {

        scoreText.text = currentScore.ToString();
    }

    void Update() {

        Time.timeScale = gameSpeed;
    }
}
