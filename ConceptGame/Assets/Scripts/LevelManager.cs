using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public Text Score_UIText;
	public Text Level_UIText;
	public GameObject levelPanel;
	public static int levelTracker = 1;
	private GameObject refLevelTest;
	private Object[] itemsToInstantiate;

	// private PlayerMovement refPlayerTest; not used because i only wanna access static movesCount

	// Use this for initialization
	void Awake () {
		if (SceneManager.GetActiveScene ().name == "Main") {
			Instantiate (Resources.Load<GameObject> ("background"));
		} else if (SceneManager.GetActiveScene ().name == "Level1") {
			InstantiateLevel("Default");
			InstantiateLevel ("Level1to4");
			levelTracker = 1;
		} else if (SceneManager.GetActiveScene ().name == "Level2") {
			InstantiateLevel("Default");
			InstantiateLevel ("Level1to4");
			InstantiateLevel("Level2");
			levelTracker = 2;
		} else if (SceneManager.GetActiveScene ().name == "Level3") {
			InstantiateLevel("Default");
			InstantiateLevel ("Level1to4");
			InstantiateLevel("Level3");
			levelTracker = 3;
		} else if (SceneManager.GetActiveScene ().name == "Level4") {
			InstantiateLevel("Default");
			InstantiateLevel ("Level1to4");
			InstantiateLevel("Level4");
			levelTracker = 4;
		}  else if (SceneManager.GetActiveScene ().name == "Level5") {
			InstantiateLevel("Default");
			InstantiateLevel ("Level5to9");
			InstantiateLevel("Level5");
			levelTracker = 5;
		}  else if (SceneManager.GetActiveScene ().name == "Level6") {
			InstantiateLevel("Default");
			InstantiateLevel ("Level5to9");
			InstantiateLevel("Level6");
			levelTracker = 6;
		} else if (SceneManager.GetActiveScene ().name == "Level7") {
			InstantiateLevel("Default");
			InstantiateLevel ("Level5to9");
			InstantiateLevel("Level7");
			levelTracker = 7;
		}
	}

	void Start() {
		Level_UIText = GameObject.Find ("Canvas(Clone)/Level").GetComponent<Text> ();
		Score_UIText = GameObject.Find ("Canvas(Clone)/Score").GetComponent<Text> ();
		levelPanel = GameObject.Find ("Canvas(Clone)/Panel");
		// initialising buttons?
		GameObject.Find ("Canvas(Clone)/Panel/NextLevelBtn").GetComponent<Button> ().onClick.AddListener (nextLevel);
		GameObject.Find ("Canvas(Clone)/Panel/TryAgainBtn").GetComponent<Button> ().onClick.AddListener (tryAgain);
		GameObject.Find ("Canvas(Clone)/Panel/QuitGameBtn").GetComponent<Button> ().onClick.AddListener (GameOver);
		levelPanel.SetActive (false);
	}
		
	void InstantiateLevel(string toInstantiate) {
		itemsToInstantiate = Resources.LoadAll(toInstantiate);
		foreach (var a in itemsToInstantiate) {
			Instantiate(a);
		}
	}

	void Update() {
			Score_UIText.text = PlayerMovement.movesCount.ToString () + " moves left";
			Level_UIText.text = "Level " + levelTracker.ToString ();
			if (Input.GetKeyDown (KeyCode.V)) {
				SceneManager.LoadScene ("Main");
				levelTracker = 1;
				PlayerMovement.movesCount = 3;
			}
	}


	public void GameOver() {
		SceneManager.LoadScene ("Main");
	}

	public void LevelPassed() {
		levelPanel.SetActive (true);
	}

	public void nextLevel() {
		levelTracker++;
		SceneManager.LoadScene ("Level" + levelTracker.ToString());
		PlayerMovement.movesCount = 3;
		levelPanel.SetActive (false);
	}

	public void tryAgain() {
		SceneManager.LoadScene ("Level" + levelTracker.ToString());
		PlayerMovement.movesCount = 3;
	}
}
