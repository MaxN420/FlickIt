using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Vector2 currentMousePos;
	public GameObject currentPlayer;
	private Vector2 currentPlayerPos;
	public Rigidbody2D rigidBody2D;
	private float speed;
	private Vector2 direction;
	private float xDiff;
	private float yDiff;
	public static int movesCount = 3;
	private LevelManager levelRef;
	public float maxSpeed = 15f;
	private GameObject[] gravityHole;
	public float maxGravDist = 3.0f;
	public float maxGravity = 35.0f;
	public static AudioSource sound;

	void Start() {
		//sound = GameObject.Find ("Flcksnd").GetComponent<AudioSource>();
		levelRef = GameObject.Find("Main Camera").GetComponent<LevelManager>();
		gravityHole = GameObject.FindGameObjectsWithTag ("GravityHole");
	}
	//When mouse click is ended, determines the ending mouse position.
	//Need to compare this with the current ball position.
	//Depending on how far the mouse is dragged away from the ball,
	//will determine the forces applied to the player (including angles too).
	void OnMouseUp() {
		//making sure enough moves left, and that the ball isn't currently moving
		// && rigidBody2D.velocity.magnitude < 0.7f
		if (movesCount != 0) {
			//Audio.playFlck ();
			//sound.Play ();
			movesCount-=1;
			currentMousePos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0f));
			currentPlayerPos = currentPlayer.GetComponent<Transform> ().position;

			xDiff = currentMousePos.x - currentPlayerPos.x;
			yDiff = currentMousePos.y - currentPlayerPos.y;

			direction = new Vector2 (xDiff, yDiff);

			rigidBody2D.AddForce (direction * 500);
		}
	}


	// Use this for initialization
	void Awake () {
		//source = Resources.Load ("Sounds/Sound Effects/soundscrate-arrow-swoosh-4");
		//source.GetComponent<AudioSource> ();
	}
		

	void FixedUpdate() {
		// Allows the ball to slow down quicker, applying forces means it takes ages to stop.
		if (rigidBody2D.velocity.magnitude < 1.5 && rigidBody2D.velocity.magnitude != 0) {
			rigidBody2D.drag += 0.02f;
		} else {
			rigidBody2D.drag = 1f;
		}

		//Checks if have no moves left and ball is inactive
		if (movesCount == 0 && rigidBody2D.IsSleeping() && !(levelRef.levelPanelPass.activeSelf)) {
			levelRef.loadPanelFail();
		}

		//Trying to create a speed limiter
		if(rigidBody2D.velocity.magnitude > maxSpeed){
			rigidBody2D.velocity = rigidBody2D.velocity.normalized * maxSpeed;
			//Debug.Log (rigidBody2D.velocity.magnitude);
		}

		// Gravity effect
		foreach (GameObject planet in gravityHole) {
			float dist = Vector2.Distance (planet.transform.position, transform.position);
			if (dist <= maxGravDist && rigidBody2D.velocity.magnitude < 0) {
				Vector2 v = planet.transform.position - transform.position;
				rigidBody2D.AddForce (v.normalized * (1f - dist / maxGravDist) * maxGravity);
			}
		}
	}
}