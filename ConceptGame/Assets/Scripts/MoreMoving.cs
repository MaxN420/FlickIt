using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreMoving : MonoBehaviour {

	public Vector3 startPoint;
	public Vector3 point1;
	public Vector3 point2;
	public Vector3 point3;
	public float wallSpeed;
	public int objectPosition = 0;

	// Use this for initialization
	void Start () {
		
	}



	// Update is called once per frame
	void Update () {
		// will update to use customisable points
		if (transform.position == startPoint)
			objectPosition = 0;
		if (transform.position == point1)
			objectPosition = 1;
		if (transform.position == point2)
			objectPosition = 2;
		if (transform.position == point3)
			objectPosition = 3;
		switch (objectPosition) {
		case 0:
			transform.position = Vector3.MoveTowards (transform.position, point1, Time.deltaTime * wallSpeed);
			break;
		case 1:
			transform.position = Vector3.MoveTowards (transform.position, point2, Time.deltaTime * wallSpeed);
			break;
		case 2:
			transform.position = Vector3.MoveTowards (transform.position, point3, Time.deltaTime * wallSpeed);
			break;
		case 3:
			transform.position = Vector3.MoveTowards (transform.position, startPoint, Time.deltaTime * wallSpeed);
			break;
		default:
			break;
		}

	}
}
