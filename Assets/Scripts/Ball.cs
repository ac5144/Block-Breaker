using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	[SerializeField] Paddle paddle;
	[SerializeField] float xVelocity = 5f;
	[SerializeField] float yVelocity = 15f;
	[SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

	Vector2 paddleToBallVector;
	bool hasLaunched = false;

	AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;

	// Use this for initialization
	void Start () {

		paddleToBallVector = transform.position - paddle.transform.position;
		myAudioSource = GetComponent<AudioSource> ();
        myRigidbody2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!hasLaunched) {
			
			LockBallToPaddle ();
			LaunchOnClick ();
		}
	}


	//Other methods
	private void LockBallToPaddle() {

		Vector2 paddlePos = new Vector2 (paddle.transform.position.x, paddle.transform.position.y);

		transform.position = paddlePos + paddleToBallVector;
	}

	private void LaunchOnClick() {

		if (Input.GetMouseButtonDown (0)) {

			myRigidbody2D.velocity = new Vector2(xVelocity, yVelocity);
			hasLaunched = true;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {

        Vector2 tweakedVelocity = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

		if (hasLaunched) {

			AudioClip clip = ballSounds [UnityEngine.Random.Range (0, ballSounds.Length)];
			myAudioSource.PlayOneShot (clip);
            myRigidbody2D.velocity += tweakedVelocity;
		}
	}
}
