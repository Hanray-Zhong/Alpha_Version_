using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour {

	public GameObject Ball;
	public float moveForce = 0;

	private float trigger_ori_Height;
	private float ball_ori_heiget;

	private void Start() {
		trigger_ori_Height = transform.position.y;
		ball_ori_heiget = Ball.transform.position.y;
	}
	
	void Update () {
		transform.position = new Vector3(Ball.transform.position.x, trigger_ori_Height, Ball.transform.position.z);
	}

	private void OnTriggerStay(Collider other) {
		if (other.tag == "Player") {
			CubeMove cb = other.GetComponent<CubeMove>();
			cb.moveSpeed = 1;
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
				Ball.transform.position = new Vector3(other.transform.position.x, ball_ori_heiget, other.transform.position.z);
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			CubeMove cb = other.GetComponent<CubeMove>();
			cb.moveSpeed = 6;
		}
	}
}
