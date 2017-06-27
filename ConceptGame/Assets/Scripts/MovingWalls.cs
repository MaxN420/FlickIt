using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalls : MonoBehaviour {

	private Vector2 MovingDirection;
	public float wallSpeedConstant = 2;
	public float xConstraints = 1f;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		UpdateMovement();
	}

	void UpdateMovement(){
		if (this.transform.position.x > xConstraints) {
			MovingDirection = Vector2.left;
		} else if (this.transform.position.x < -xConstraints) { 
			MovingDirection = Vector2.right;
		} 
		this.transform.Translate (MovingDirection * (Time.smoothDeltaTime*wallSpeedConstant));
	}

}
