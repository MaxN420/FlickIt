using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** Controls the points in the persons game */
public class PointsManager : MonoBehaviour {

	public static int saveTokens = 10; 
	public static int totalPoints = 0;
	private float speed;
	private Vector2 direction;
	private float fadeTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		float translation = speed * Time.deltaTime;
		if (LevelManager.ScoreText_UIText.GetComponent<RectTransform>().localPosition.y < 160) {
			transform.Translate (direction * translation);
		} else {
			LevelManager.ScoreText_UIText.text = "";
		}
	}

	public static int determineLevelPoints(int moves, float timeTaken, int level) {
		return Mathf.RoundToInt(((100+((1/timeTaken)*10)*((1+moves)*25)))*(1+(((float)level)/10)));
	}

	public void Initialise(float speed, Vector2 direction) {
		this.speed = speed;
		this.direction = direction;
	}
}
