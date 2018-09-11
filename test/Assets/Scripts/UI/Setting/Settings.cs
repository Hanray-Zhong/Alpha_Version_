using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {

	public GameObject menu;
	public GameObject mohu;
	public GameObject mousePointer;

	
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape)) {
			Time.timeScale = 0;
			Cursor.lockState = CursorLockMode.None;
			mousePointer.GetComponent<TPS>().enabled = false;
			mohu.SetActive(true);
			menu.SetActive(true);
		}
	}

	public void loadLevel(string levelName) {
		SceneManager.LoadScene(levelName);
	}

	public void Play() {
		Time.timeScale = 1;
	}
}
