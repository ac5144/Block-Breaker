using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block {

    [SerializeField] GameObject breakParticles;

    int pointValue;

    // Unity Methods

    private void Start() {

        SetPointValue(50);
    }

    protected override void OnCollisionEnter2D(Collision2D collision) {

        base.OnCollisionEnter2D(collision);
        DestroyBlock();
    }

    // Private Methods

    private void TriggerBreakParticles() {

        Vector3 particlesPos = transform.position;
        particlesPos.z -= 1;
        GameObject particles = Instantiate(breakParticles, particlesPos, transform.rotation);
        Destroy(particles, 1f);
    }

    // Protected Methods

    protected void DestroyBlock() {

        FindObjectOfType<GameSession>().AddToScore(pointValue);

        FindObjectOfType<LevelManager>().BlockDestroyed();

        TriggerBreakParticles();
        Destroy(gameObject);
    }

    protected void SetPointValue(int newValue) {

        pointValue = newValue;
    }
}
