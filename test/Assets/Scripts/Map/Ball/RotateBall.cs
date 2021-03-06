﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour {

	public GameObject Ball;
	public float rotateSpeed = 0;

	private float trigger_ori_Height;
	private float ball_ori_heiget;

	private void Start() {
		trigger_ori_Height = transform.position.y;
		ball_ori_heiget = Ball.transform.position.y;
	}
	
	void Update () {
		transform.position = new Vector3(Ball.transform.position.x, trigger_ori_Height, Ball.transform.position.z);
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			other.transform.position = new Vector3(Ball.transform.position.x, other.transform.position.y, Ball.transform.position.z);
		}
	}

	private void OnTriggerStay(Collider other) {
		if (other.tag == "Player") {
			CubeMove cb = other.GetComponent<CubeMove>();
			cb.moveSpeed = 1;
			Ball.GetComponent<SphereCollider>().enabled = false;
			other.GetComponent<SphereCollider>().enabled = true;
			other.GetComponent<IsOnTheGround>().maxDistance = 10;
			Ball.transform.position = new Vector3(other.transform.position.x, ball_ori_heiget, other.transform.position.z);
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
				Ball.transform.Rotate(other.transform.right, rotateSpeed, Space.World);
			}
				
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			CubeMove cb = other.GetComponent<CubeMove>();
			cb.moveSpeed = 6;
			other.GetComponent<SphereCollider>().enabled = false;
			Ball.GetComponent<SphereCollider>().enabled = true;
			other.GetComponent<IsOnTheGround>().maxDistance = 2;
		}
	}
}
