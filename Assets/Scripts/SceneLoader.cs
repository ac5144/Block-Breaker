using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadScene(string sceneName) {

		SceneManager.LoadScene (sceneName);
	}

    public void LoadStartScene() {

        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

	public void LoadNextScene() {

		int currentSceneIndex = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (currentSceneIndex + 1);
	}
}
