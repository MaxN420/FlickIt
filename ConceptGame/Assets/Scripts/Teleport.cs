using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour {

	public float y;
	public float x;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name == "player(Clone)") {
			//x = this.transform.position.x;
			col.gameObject.GetComponent<Transform> ().transform.position = new Vector2 (x, y);
			col.gameObject.GetComponent<TrailRenderer> ().Clear();
		}
	}

	// Update is called once per frame
	void Update () {
			
	}
}
