using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	[SerializeField] float screenWidthInUnits = 16f;
	[SerializeField] float minXPos = 1f;
	[SerializeField] float maxXPos	= 15f;

	void Update () {

        UpdatePaddlePos();
	}

    private float GetMousePositionInUnits() {

        return Input.mousePosition.x / Screen.width * screenWidthInUnits;
    }

    private void UpdatePaddlePos() {

        float mousePosInUnits = GetMousePositionInUnits();
        Vector2 currentPaddlePos = new Vector2(transform.position.x, transform.position.y);

        currentPaddlePos.x = Mathf.Clamp(mousePosInUnits, minXPos, maxXPos);
        transform.position = currentPaddlePos;
    }

    
}
