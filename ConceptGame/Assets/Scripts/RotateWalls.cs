using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateWalls : MonoBehaviour {

	public int speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		UpdateMovement ();
	}

	void UpdateMovement(){
		this.transform.Rotate (new Vector3 (0, 0, 40) * Time.deltaTime * speed);
	}
}
