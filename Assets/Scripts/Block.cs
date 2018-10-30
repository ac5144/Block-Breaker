using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
	
	[SerializeField] AudioClip[] hitSounds;

    protected virtual void OnCollisionEnter2D(Collision2D collision) {

        PlayHitSound();
    }

    protected void PlayHitSound() {

        AudioClip hitSoundClip = hitSounds[Random.Range(0, hitSounds.Length)];
        AudioSource.PlayClipAtPoint(hitSoundClip, Camera.main.transform.position);
    }
}
