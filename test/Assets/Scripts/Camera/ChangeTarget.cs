using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTarget : MonoBehaviour {

	public GameObject MainCamera;
	public GameObject newCamera;
	public GameObject Player;
	public float changeTime;
	
	public void Change() {
		Player.GetComponent<CubeMove>().enabled = false;
		MainCamera.SetActive(false);
		newCamera.SetActive(true);
		StartCoroutine(ChangeBack());
	}

	IEnumerator ChangeBack() {
		yield return new WaitForSeconds(changeTime);
		MainCamera.SetActive(true);
		newCamera.SetActive(false);
		Player.GetComponent<CubeMove>().enabled = true;
	}
}
