using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTarget : MonoBehaviour {

	public GameObject MainCamera;
	public GameObject newCamera;
	public GameObject Player;
	public GameObject UIController;
	public Animator anim;
	public float changeTime;

	private AnimatorStateInfo info;

	private void Awake() {
		info = anim.GetCurrentAnimatorStateInfo(0);
	}
	
	public void Change() {
		Player.GetComponent<CubeMove>().enabled = false;
		if (info.IsName("Run")) {
            anim.Play("Idle", 0, 0);
        }
		UIController.GetComponent<Settings>().is_stop = true;
		MainCamera.SetActive(false);
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
