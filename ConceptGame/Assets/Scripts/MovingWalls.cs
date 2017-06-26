using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalls : MonoBehaviour {

	private Vector2 MovingDirection;
	private float WallSpeedConstant = 2;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		UpdateMovement();
	}

	void UpdateMovement(){
		if (this.transform.position.x > 3f) {
			MovingDirection = Vector2.left;
		} else if (this.transform.position.x < -3f) { 
			MovingDirection = Vector2.right;
		} 
		this.transform.Translate (MovingDirection * (Time.smoothDeltaTime*WallSpeedConstant));
	}

}
