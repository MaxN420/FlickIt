using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Controls the points in the persons game */
public class PointsManager : MonoBehaviour {

	public static int totalPoints = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static int determineLevelPoints(int moves, float timeTaken) {
		return Mathf.RoundToInt(100+((1/timeTaken)*10)*((1+moves)*25));
	}
}
