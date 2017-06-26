using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

	private LevelManager levelRef;

	void Start() {
		levelRef = GameObject.Find("Main Camera").GetComponent<LevelManager>();
	}
		
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			Destroy (gameObject);
			levelRef.LevelPassed();
		}
	}
}
