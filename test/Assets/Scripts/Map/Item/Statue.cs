using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour {

	public bool isOpen = false;

	private void Update() {
		if (this.gameObject.transform.position.y >= -0.0689) {
			isOpen = true;
		}
	}
}
