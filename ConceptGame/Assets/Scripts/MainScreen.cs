using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainScreen : MonoBehaviour {

	public Text TotalScore_UIText;

	public void Start() {
		LevelManager.Load ();

		if (SceneManager.GetActiveScene ().name != "Main" && SceneManager.GetActiveScene ().name != "LevelSelect") {
			TotalScore_UIText = GameObject.Find ("Canvas/Points").GetComponent<Text> ();
			TotalScore_UIText.text = "Points: " + LevelManager.levelPointsTotal.ToString ();
		}
	}

	public void StartGame() {
		SceneManager.LoadScene ("GenericLevel");
	}

	//public void openShop() {
		//SceneManager.LoadScene ("Shop");
	//}

	public void openLevelSelect() {
		SceneManager.LoadScene ("LevelSelect");
	}

	public void backToMain() {
		SceneManager.LoadScene ("Main");
	}



}
