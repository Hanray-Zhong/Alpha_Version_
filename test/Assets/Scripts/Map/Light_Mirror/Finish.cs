using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

	public bool isOpen = false;

	private void OnTriggerStay(Collider other) {
		if (other.tag == "light") {
			isOpen = true;
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.tag == "light") {
			isOpen = false;
		}
	}
	
}
