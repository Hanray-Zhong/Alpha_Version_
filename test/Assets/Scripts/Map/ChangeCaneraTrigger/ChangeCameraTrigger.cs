using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraTrigger : MonoBehaviour {

	public GameObject MainCamera;
	public GameObject newCamera;
	

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			MainCamera.SetActive(false);
			newCamera.SetActive(true);
			other.GetComponent<CubeMove>().isChangeCamera = true;
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			MainCamera.SetActive(true);
			newCamera.SetActive(false);
			other.GetComponent<CubeMove>().isChangeCamera = false;
		}
	}
}
