using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	[SerializeField] Paddle paddle;
	[SerializeField] float xVelocity = 5f;
	[SerializeField] float yVelocity = 15f;
    [SerializeField] float randomFactor = 0.2f;

	Vector2 paddleToBallVector;
	bool hasLaunched = false;

	AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;

	void Start () {

		paddleToBallVector = transform.position - paddle.transform.position;
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
	}
	
	void Update () {

		if (!hasLaunched) {
			
			LockBallToPaddle ();
			LaunchOnClick ();
		}
	}

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

    private void PlayBounceAudio(GameObject otherObject) {

        if (otherObject.tag == "Wall" || hasLaunched && otherObject.tag == "Player")
            myAudioSource.Play();

    }

	private void OnCollisionEnter2D(Collision2D collision) {

        Vector2 tweakedVelocity = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

		if (hasLaunched) {

            myRigidbody2D.velocity += tweakedVelocity;
		}

        PlayBounceAudio(collision.gameObject);
	}
}
