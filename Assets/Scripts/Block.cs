using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
	
	[SerializeField] AudioClip breakSound;
	[SerializeField] int pointValue = 100;
    [SerializeField] int maxHits = 3;
    [SerializeField] Sprite[] hitSprites;

    [SerializeField] int currentHits;

    [SerializeField] GameObject blockParticles;

	private void OnCollisionEnter2D(Collision2D collision) {

        if (tag == "Breakable") {

            currentHits++;

            if (currentHits == maxHits)
                DestroyBlock();
            else
                UpdateSprite();
        }
	}

    private void UpdateSprite() {

        GetComponent<SpriteRenderer>().sprite = hitSprites[currentHits];

    }

	private void DestroyBlock() {

        GameObject.FindObjectOfType<LevelManager>().BlockDestroyed();
        GameObject.FindObjectOfType<GameSession>().addScore(pointValue);
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        TriggerParticles();
        Destroy(gameObject);
	}

    private void TriggerParticles() {

        GameObject particles = Instantiate(blockParticles, transform.position, transform.rotation);
        Destroy(particles, 1f);
    }
}
