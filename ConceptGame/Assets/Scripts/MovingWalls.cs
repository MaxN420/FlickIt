using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingWalls : MonoBehaviour {

	private Vector2 MovingDirection;
	public float wallSpeedConstant = 2;
	public float xConstraints = 1f;
	public float yConstraints = 2f;
	public bool horizontal;
	public bool vertical;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		UpdateMovement();
	}

	void UpdateMovement(){
		if (horizontal) {
			if (this.transform.position.x > xConstraints) {
				MovingDirection = Vector2.left;
			} else if (this.transform.position.x < -xConstraints) { 
				MovingDirection = Vector2.right;
			} 
			this.transform.Translate (MovingDirection * (Time.smoothDeltaTime * wallSpeedConstant));
		} else if (vertical){
			if (this.transform.position.y > yConstraints) {
				MovingDirection = new Vector2(-1, -1);
			} else if (this.transform.position.y < -yConstraints) { 
				MovingDirection = new Vector2(1, 1);
			} 
			this.transform.Translate (MovingDirection * (Time.smoothDeltaTime * wallSpeedConstant));
		}
	}

}
