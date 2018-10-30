using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushMirror : MonoBehaviour {

	public float limitVelocity;
	public float rotateSpeed;
	public GameObject Mirror;
	public bool isRight = true;

	private float reletiveVelocity;

	private void OnTriggerStay(Collider other) {
		if (other.tag == "Player") {
			reletiveVelocity = Vector3.Dot(other.GetComponent<Rigidbody>().velocity, gameObject.transform.forward.normalized);
			if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && isRight) {
				Mirror.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
			}
			if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !isRight) {
				Mirror.transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
			}
		}
	}
}
