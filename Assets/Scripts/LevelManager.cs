using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour {

	int numBlocks;

	SceneLoader sceneLoader;

	public void BlockDestroyed() {

		numBlocks--;
        if (numBlocks <= 0) {

            sceneLoader.LoadNextScene();
        }
    }

	void Start () {

        numBlocks = GameObject.FindGameObjectsWithTag("Breakable").Length;
		sceneLoader = GameObject.FindObjectOfType<SceneLoader> ();
	}

}
