using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {

	public GameObject menu;
	public GameObject mohu;
	public GameObject MainCamera;

	public bool is_stop = false;

	
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape)) {
			MainCamera.GetComponent<TPS>().MousePointNone();
			Time.timeScale = 0;
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
