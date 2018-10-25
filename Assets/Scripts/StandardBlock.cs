using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block {

    [SerializeField] GameObject breakParticles;

    [SerializeField] int pointValue = 50;

    protected override void OnCollisionEnter2D(Collision2D collision) {

        base.OnCollisionEnter2D(collision);
        DestroyBlock();
    }

    private void TriggerBreakParticles() {

        Vector3 particlesPos = transform.position;
        particlesPos.z -= 1;
        GameObject particles = Instantiate(breakParticles, transform.position, transform.rotation);
        Destroy(particles, 1f);
    }

    private void DestroyBlock() {

        FindObjectOfType<GameSession>().addScore(pointValue);

        FindObjectOfType<LevelManager>().BlockDestroyed();

        TriggerBreakParticles();
        Destroy(gameObject);
    }
}
