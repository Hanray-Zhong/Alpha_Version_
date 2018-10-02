using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

	public void Quit() {
		Application.Quit();
	}

	public void loadLevel(string levelName) {
		StartCoroutine(LoadLevel(levelName));
	}

	IEnumerator LoadLevel(string levelName) {
		yield return new WaitForSeconds(5f);
		SceneManager.LoadScene(levelName);
	}

}
