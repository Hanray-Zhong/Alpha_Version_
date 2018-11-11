using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "IronBall") {
			this.gameObject.GetComponent<Switch_raiseFloor>().isOpenSwitch = true;
			gameObject.GetComponent<ChangeTarget>().Change();
			this.gameObject.GetComponent<BoxCollider>().enabled = false;
		}
	}
}
