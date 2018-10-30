﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision) {

        GameSession currentSession = FindObjectOfType<GameSession> ();

        currentSession.DecrementLives();

        if (currentSession.GetNumLives() > 0)

            FindObjectOfType<Ball>().ResetBall();
        else

            SceneManager.LoadScene("Lose");
	}
}
