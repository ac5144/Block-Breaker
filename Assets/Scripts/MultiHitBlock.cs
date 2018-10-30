using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiHitBlock : StandardBlock {

    [SerializeField] int maxNumHits = 2;
    [SerializeField] int currentNumHits = 0;
    [SerializeField] Sprite[] breakSprites;

    // Unity Methods

    private void Start() {

        SetPointValue(125);
    }

    protected override void OnCollisionEnter2D(Collision2D collision) {

        currentNumHits++;

        if (currentNumHits >= maxNumHits) {

            base.OnCollisionEnter2D(collision);
        }
        else {

            PlayHitSound();
            UpdateBlockSprite();
        }
    }

    private void UpdateBlockSprite() {

        GetComponent<SpriteRenderer>().sprite = breakSprites[currentNumHits];
    }
}
