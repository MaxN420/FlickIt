using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Vector2 currentMousePos;
	public GameObject currentPlayer;
	public GameObject wall1;
	private Vector2 currentPlayerPos;
	public Rigidbody2D rigidBody2D;
	private float speed;
	private Vector2 direction;
	private float clickHypotenuse;
	private float xDiff;
	private float yDiff;
	public static int movesCount = 3;
	private LevelManager levelRef;

	void Start() {
		levelRef = GameObject.Find("Main Camera").GetComponent<LevelManager>();
	}
	//When mouse click is ended, determines the ending mouse position.
	//Need to compare this with the current ball position.
	//Depending on how far the mouse is dragged away from the ball,
	//will determine the forces applied to the player (including angles too).
	void OnMouseUp() {
		//making sure enough moves left, and that the ball isn't currently moving
		if (movesCount != 0 && rigidBody2D.velocity.magnitude < 0.3f) {
			movesCount-=1;
			currentMousePos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0f));
			currentPlayerPos = currentPlayer.GetComponent<Transform> ().position;

			xDiff = currentMousePos.x - currentPlayerPos.x;
			yDiff = currentMousePos.y - currentPlayerPos.y;

			direction = new Vector2 (-(xDiff), -(yDiff));
			clickHypotenuse = Mathf.Sqrt ((xDiff * xDiff) + (yDiff * yDiff));

			//Sets a limit on ball speed so that doesn't break through the wall (default collider doesn't work with high speeds qq)
			if (clickHypotenuse < 5) {
				rigidBody2D.AddForce (direction * (clickHypotenuse * 100));
			} else {
				rigidBody2D.AddForce (direction / 1.5f * (5 * 100));
			}
		}
	}

	void FixedUpdate() {
		// Allows the ball to slow down quicker, applying forces means it takes ages to stop.
		if (rigidBody2D.velocity.magnitude < 1.5 && rigidBody2D.velocity.magnitude != 0) {
			rigidBody2D.drag += 0.02f;
		} else {
			rigidBody2D.drag = 0.5f;
		}

		if (movesCount == 0 && rigidBody2D.IsSleeping()) {
			movesCount = 3;
			levelRef.GameOver();
		}
	}

}