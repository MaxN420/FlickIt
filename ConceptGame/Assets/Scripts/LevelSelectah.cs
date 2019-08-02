using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectah : MonoBehaviour {

	private int level = 0;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 20; i++) {
			if (!LevelManager.levelCompleted[i]) {
				// add image to the icon
				//GameObject.Find("Canvas/Panel/Level" + (i).ToString() + "Btn").GetComponent<Text>().text
				GameObject obj = Instantiate(Resources.Load("LevelSelect/Cross", typeof (GameObject))) as GameObject;
					
				obj.transform.SetParent(GameObject.Find("Canvas/Panel/Level" + (i+1).ToString() + "Btn").transform, false);

			}
		}
	}

	public void selectLevel(Button button) {
		level = int.Parse(button.GetComponentInChildren<Text> ().text);
		if (LevelManager.levelCompleted [level - 1]) {
			PlayerMovement.movesCount = 3;
			LevelManager.levelTracker = level;
			SceneManager.LoadScene ("GenericLevel");
		} else {
			Debug.Log ("You haven't completed this Level yet!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
