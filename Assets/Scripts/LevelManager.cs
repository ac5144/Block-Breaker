using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour {

	int numBlocks;

	SceneLoader sceneLoader;

    //Unity Methods

	private void Start () {

        numBlocks = GameObject.FindGameObjectsWithTag("Breakable").Length;
		sceneLoader = GameObject.FindObjectOfType<SceneLoader> ();

	}

    // Private Methods

    private void LoadNextLevel() {

        GameObject.FindObjectOfType<GameSession>().ResetLives();
        sceneLoader.LoadNextScene();
    }

    // Public Methods

    public void BlockDestroyed() {

		    numBlocks--;
            if (numBlocks <= 0) {

                Invoke("LoadNextLevel", 0.5f);
            }
        }
}
