using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_ChangeTarget : MonoBehaviour {

	private bool turnoff = true;
	public bool isOpenSwitch = false;

	private void Update() {
		if (isOpenSwitch && turnoff) {
			gameObject.GetComponent<ChangeTarget>().Change();
			turnoff = false;
		}
	}

	private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
			if (isOpenSwitch == false)
				isOpenSwitch = true;
        }
    }
}
