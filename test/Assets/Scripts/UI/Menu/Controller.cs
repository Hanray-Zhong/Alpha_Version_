using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

	public void Quit() {
		Application.Quit();
	}

	public void loadLevel(string levelName) {
		SceneManager.LoadScene(levelName);
	}

}
