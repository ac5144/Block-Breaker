using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnbreakableBlock : Block {

    protected override void OnCollisionEnter2D(Collision2D collision) {

        base.OnCollisionEnter2D(collision);
    }
}
