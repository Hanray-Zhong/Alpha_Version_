using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusOn : MonoBehaviour {

	public GameObject[] Cameras;

	public GameObject newCamera;
	public GameObject MainCamera;
	public GameObject Player;
	public GameObject UIController;

	public float changeTime;

	public void Focus() {
		foreach (var camera in Cameras) {
			if (camera.activeSelf == true) {
				camera.SetActive(false);
			}
		}
		Player.GetComponent<CubeMove>().enabled = false;
		if (UIController != null)
			UIController.GetComponent<Settings>().is_stop = true;
		newCamera.SetActive(true);
		StartCoroutine(ChangeBack());
	}

	IEnumerator ChangeBack() {
		yield return new WaitForSeconds(changeTime);
		MainCamera.SetActive(true);
		newCamera.SetActive(false);
		Player.GetComponent<CubeMove>().enabled = true;
		UIController.GetComponent<Settings>().is_stop = false;
	}
}
