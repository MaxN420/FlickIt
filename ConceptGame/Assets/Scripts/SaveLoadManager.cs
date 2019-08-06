using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadManager {

	public static void SavePlayer(LevelManager lvlman) {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream stream = new FileStream (Application.persistentDataPath + "/player.lsd", FileMode.Create);

		UserData data = new UserData ();

		bf.Serialize (stream, data);
		stream.Close ();
		Debug.Log ("Saved data");
	}

	public static UserData LoadPlayer() {
		// just checking save file exists
		if (File.Exists (Application.persistentDataPath + "/player.lsd")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/player.lsd", FileMode.Open);

			UserData data = bf.Deserialize (stream) as UserData;
			stream.Close ();

			Debug.Log ("Loaded data");
			return data;
		} else {
			Debug.Log ("No file made yet");
			return new UserData ();
		}
		//}
	}

}

[Serializable]
public class UserData {

	public bool[] lvls;
	public int points;
	public int[] highscores;

	public UserData() {
		lvls = new bool[20];
		highscores = new int[20];
		// i need to stop making half my shit static
		points = LevelManager.levelPointsTotal;
		for (int i = 0; i < 20; i++) {
			lvls [i] = LevelManager.levelCompleted [i];
			highscores [i] = LevelManager.highscores [i];
		}
	}

}
