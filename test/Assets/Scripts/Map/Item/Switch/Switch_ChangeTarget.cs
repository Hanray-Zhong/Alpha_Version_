using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_ChangeTarget : MonoBehaviour {

	private void Update() {
		if (gameObject.GetComponent<Switch_raiseFloor>() != null && gameObject.GetComponent<Switch_raiseFloor>().isOpenSwitch == true) {
			gameObject.GetComponent<ChangeTarget>().Change();
					gameObject.GetComponent<Switch_ChangeTarget>().enabled = false;
		}
		if (gameObject.GetComponent<CreatFloor>() != null && gameObject.GetComponent<CreatFloor>().isOpenSwitch == true) {
			gameObject.GetComponent<ChangeTarget>().Change();
					gameObject.GetComponent<Switch_ChangeTarget>().enabled = false;
		}
	}
}
