using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public Text instructionText;
	public Text Score_UIText;
	public static Text ScoreText_UIText;
	public Text Level_UIText;
	public Text TotalScore_UIText;
	public GameObject levelPanelPass;
	public GameObject levelPanelFail;
	public GameObject pausePanel;
	public static int levelTracker = 1;
	public static bool[] levelCompleted = {true, false, false, false, false, false, false, false, false, false,
		false, false, false, false, false, false, false, false, false, false
	};

	public static int[] highscores = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
	private GameObject refLevelTest;
	private Object[] itemsToInstantiate;
	private Button nextLevelButtonPass;
	private Button tryAgainButtonPass;
	private Button quitGameButtonPass;
	private Button tryAgainButtonFail;
	private Button quitGameButtonFail;
	private Button pauseResumeButton;
	private Button pauseTryAgainButton;
	private Button pauseQuitButton;

	public static float levelTime = 0;
	private bool levelFinished = false;
	public static int levelPointsTotal;
	public static int levelPoints;

	// private PlayerMovement refPlayerTest; not used because i only wanna access static movesCount

	// Use this for initialization
	void Awake () {
		Load ();

		switch (levelTracker) {
		case 0:
			SceneManager.LoadScene ("Main");
			Instantiate (Resources.Load<GameObject> ("background"));
			break;
		case 1:
			InstantiateLevel ("Default");
			InstantiateLevel ("Level1");
			InstantiateLevel ("Level1to5");
			InstantiateLevel ("InstructionText");
			break;
		case 2:
			InstantiateLevel("Default");
			InstantiateLevel ("Level1to5");
			InstantiateLevel("Level2");
			break;
		case 3:
			InstantiateLevel("Default");
			InstantiateLevel ("Level1to5");
			InstantiateLevel("Level3");
			break;
		case 4:
			InstantiateLevel("Default");
			InstantiateLevel ("Level1to5");
			InstantiateLevel("Level4");
			break;
		case 5:
			InstantiateLevel("Default");
			InstantiateLevel ("Level1to5");
			InstantiateLevel("Level5");
			break;
		case 6:
			InstantiateLevel("Default");
			InstantiateLevel ("Level6to10");
			InstantiateLevel("Level6");
			break;
		case 7:
			InstantiateLevel("Default");
			InstantiateLevel ("Level6to10");
			InstantiateLevel("Level7");
			break;
		case 8:
			InstantiateLevel("Default");
			InstantiateLevel ("Level6to10");
			InstantiateLevel("Level8");
			break;
		case 9:
			InstantiateLevel("Default");
			InstantiateLevel ("Level6to10");
			InstantiateLevel("Level9");
			break;
		case 10:
			InstantiateLevel("Default");
			InstantiateLevel ("Level6to10");
			InstantiateLevel("Level10");
			break;
		case 11:
			InstantiateLevel ("Default");
			InstantiateLevel ("Level11to15");
			InstantiateLevel ("Level11");
			break;
		case 12:
			InstantiateLevel ("Default");
			InstantiateLevel ("Level11to15");
			InstantiateLevel ("Level12");
			break;
		case 13:
			InstantiateLevel ("Default");
			InstantiateLevel ("Level11to15");
			InstantiateLevel ("Level13");
			break;
		case 14:
			InstantiateLevel ("Default");
			InstantiateLevel ("Level11to15");
			InstantiateLevel ("Level14");
			break;
		case 15:
			InstantiateLevel ("Default");
			InstantiateLevel ("Level11to15");
			InstantiateLevel ("Level15");
			break;
		case 16:
			InstantiateLevel ("Default");
			InstantiateLevel ("Level16to20");
			InstantiateLevel ("Level16");
			break;
		case 17:
			InstantiateLevel ("Default");
			InstantiateLevel ("Level16to20");
			InstantiateLevel ("Level17");
			break;
		case 18:
			InstantiateLevel ("Default");
			InstantiateLevel ("Level16to20");
			InstantiateLevel ("Level18");
			break;
		case 19:
			InstantiateLevel ("Default");
			InstantiateLevel ("Level16to20");
			InstantiateLevel ("Level19");
			break;
		case 20:
			InstantiateLevel ("Default");
			InstantiateLevel ("Level16to20");
			InstantiateLevel ("Level20");
			break;
		default:
			break;
		}
	}

	void Start() {
		//GameObject.Find ("Canvas(Clone)").
		Level_UIText = GameObject.Find ("Canvas(Clone)/Level").GetComponent<Text> ();
		Score_UIText = GameObject.Find ("Canvas(Clone)/Score").GetComponent<Text> ();
		ScoreText_UIText = GameObject.Find ("Canvas(Clone)/ScoreText").GetComponent<Text> ();
		TotalScore_UIText = GameObject.Find ("Canvas(Clone)/TotalScoreText").GetComponent<Text> ();
		TotalScore_UIText.text = "";
		ScoreText_UIText.text = "";
		levelPanelPass = GameObject.Find ("Canvas(Clone)/PanelPass");
		pausePanel = GameObject.Find ("Canvas(Clone)/PausePanel");
		levelPanelFail = GameObject.Find ("Canvas(Clone)/PanelFail");
		// initialising buttons?
		pauseResumeButton = GameObject.Find ("Canvas(Clone)/PausePanel/ResumeBtn").GetComponent<Button> ();
		pauseResumeButton.onClick.AddListener (resumeGame);
		pauseTryAgainButton = GameObject.Find ("Canvas(Clone)/PausePanel/TryAgainBtn").GetComponent<Button> ();
		pauseTryAgainButton.onClick.AddListener (tryAgain);
		pauseQuitButton = GameObject.Find ("Canvas(Clone)/PausePanel/QuitGameBtn").GetComponent<Button> ();
		pauseQuitButton.onClick.AddListener (GameOver);
		nextLevelButtonPass = GameObject.Find ("Canvas(Clone)/PanelPass/NextLevelBtn").GetComponent<Button> ();
		nextLevelButtonPass.onClick.AddListener (nextLevel);
		tryAgainButtonPass = GameObject.Find ("Canvas(Clone)/PanelPass/TryAgainBtn").GetComponent<Button> ();
		tryAgainButtonPass.onClick.AddListener (tryAgain);
		quitGameButtonPass = GameObject.Find ("Canvas(Clone)/PanelPass/QuitGameBtn").GetComponent<Button> ();
		quitGameButtonPass.onClick.AddListener (GameOver);
		tryAgainButtonFail = GameObject.Find ("Canvas(Clone)/PanelFail/TryAgainBtn").GetComponent<Button> ();
		tryAgainButtonFail.onClick.AddListener (tryAgain);
		quitGameButtonFail = GameObject.Find ("Canvas(Clone)/PanelFail/QuitGameBtn").GetComponent<Button> ();
		quitGameButtonFail.onClick.AddListener (GameOver);
		levelPanelPass.SetActive (false);
		levelPanelFail.SetActive (false);
		pausePanel.SetActive (false);
		levelTime = 0f;
		PlayerMovement.movesCount = 3;
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

		if (Input.GetKeyDown (KeyCode.P) || Input.GetKeyDown (KeyCode.Escape)) {
			if (!pausePanel.activeInHierarchy) {
				pauseGame ();
			} else {
				//(pausePanel.activeInHierarchy);
				resumeGame ();
			}
		}

		if (levelFinished != true) {
			levelTime += Time.deltaTime;
		}
	}
		
	public void Save() {
		SaveLoadManager.SavePlayer (this);
	}

	public static void Load() {
		UserData ud = SaveLoadManager.LoadPlayer ();
		levelPointsTotal = ud.points;
		levelCompleted = ud.lvls;
	}

	public void pauseGame() {
		Time.timeScale = 0;
		pausePanel.SetActive (true);
	}

	public void resumeGame() {
		Time.timeScale = 1;
		pausePanel.SetActive (false);
	}

	public void GameOver() {
		Time.timeScale = 1; 
		Save ();
		SceneManager.LoadScene ("Main");
	}

	public void loadPanelFail() {
		levelFinished = true;
		levelPanelFail.SetActive (true);
	}

	public void loadPanelPass() {
		levelCompleted [levelTracker - 1] = true;
		levelFinished = true;
		levelPanelPass.SetActive (true);
		levelPoints = PointsManager.determineLevelPoints (PlayerMovement.movesCount, levelTime, levelTracker);
		if (levelPoints > highscores [levelTracker - 1]) {
			Debug.Log ("New Highscore!!");
			highscores [levelTracker - 1] = levelPoints;
		}
		levelPointsTotal += levelPoints;
		ScoreText_UIText.text = "+" + levelPoints.ToString();
		ScoreText_UIText.GetComponent<PointsManager> ().Initialise (25, Vector2.up);
		TotalScore_UIText.text = levelPointsTotal.ToString ();
		Save ();
	}

	public void nextLevel() {
		levelTracker++;
		//SceneManager.LoadScene ("Level" + levelTracker.ToString());
		PlayerMovement.movesCount = 3;
		levelPanelPass.SetActive (false);
		setupLevel();
	}

	public void tryAgain() {
		reloadLevel ();
		Time.timeScale = 1;
		PlayerMovement.movesCount = 3;
	}

	public void setupLevel() {
		deleteAll();
		reloadLevel ();
	}

	public void reloadLevel(){
		deleteAll ();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void deleteAll() {
		foreach (GameObject o in Object.FindObjectsOfType<GameObject>()) {
			if (o.tag != "MainCamera") {
				Destroy (o);
			}
		}
	}
}
