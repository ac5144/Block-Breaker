using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	[SerializeField] Paddle paddle;
    [SerializeField] float speedFactor = 10f;
    [SerializeField] float randomFactor = 0.2f;
    [SerializeField] float xVelocityComp = 1f;
    [SerializeField] float yVelocityComp = 1f;

	Vector2 paddleToBallVector;
	bool hasLaunched = false;

	AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;

    // Unity Methods

	private void Start () {

		paddleToBallVector = transform.position - paddle.transform.position;
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
	}
	
	private void Update () {

		if (!hasLaunched) {
			
			LockBallToPaddle ();
			LaunchOnClick ();
		}
	}

    private void OnCollisionEnter2D (Collision2D collision) {

        TweakVelocity();
        PlayBounceAudio(collision.gameObject);
    }
    
    // Private Methods

    private void TweakVelocity() {

        if (hasLaunched) {

            Vector2 tweakedVelocity = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
            myRigidbody2D.velocity += tweakedVelocity;

        }
    }

    private void LockBallToPaddle() {

		Vector2 paddlePos = new Vector2 (paddle.transform.position.x, paddle.transform.position.y);

		transform.position = paddlePos + paddleToBallVector;
	}

	private void LaunchOnClick() {

		if (Input.GetMouseButtonDown (0)) {
            Vector2 ballVelocity = new Vector2(xVelocityComp, yVelocityComp);
            myRigidbody2D.velocity = ballVelocity * speedFactor;
			hasLaunched = true;
		}
	}

    private void PlayBounceAudio(GameObject otherObject) {

        if (otherObject.tag == "Wall" || hasLaunched && otherObject.tag == "Player")

            myAudioSource.Play();

    }

    // Public Methods

    public void ResetBall()
    {
        hasLaunched = false;
    }
}
