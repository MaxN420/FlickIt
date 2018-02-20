using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingWalls : MonoBehaviour {

	private Vector2 MovingDirection;
	public float wallSpeedConstant = 2;
	public bool horizontal;
	public bool vertical;
	public float xLow;
	public float xHigh;
	public float yLow;
	public float yHigh;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		UpdateMovement();
	}

	void UpdateMovement(){
		if (horizontal) {
			if (this.transform.position.x >= xHigh) {
				MovingDirection = Vector2.left;
			} else if (this.transform.position.x <= xLow) { 
				MovingDirection = Vector2.right;
			} 
			this.transform.Translate (MovingDirection * (Time.smoothDeltaTime * wallSpeedConstant));
			// code below needs to change constants to yHigh/yLow but not sure if will implement vertical, 
			// but will leave here anyway incase i change mind
		} else if (vertical){
			if (this.transform.position.y >= yHigh) {
				MovingDirection = new Vector2(-1, 0);
			} else if (this.transform.position.y <= yLow) { 
				MovingDirection = new Vector2(1, 0);
			} 
			this.transform.Translate (MovingDirection * (Time.smoothDeltaTime * wallSpeedConstant));
		}
	}

}
