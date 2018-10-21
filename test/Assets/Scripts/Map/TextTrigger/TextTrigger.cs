using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour {

	public GameObject TargetText;

	private ChangeTarget changeTarget;
	private bool canTrigger = true;

	private void Awake() {
		changeTarget = GetComponent<ChangeTarget>();
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Player" && canTrigger) {
			TargetText.SetActive(true);
			this.ChangeTarget();
			canTrigger = false;
			Destroy(gameObject, 4f);
		}

	}

	private void ChangeTarget() {
		if (changeTarget != null) {
			changeTarget.Change();
		}
	}
}
