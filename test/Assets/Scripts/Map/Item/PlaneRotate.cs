using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRotate : MonoBehaviour {

	public float rotateSpeed;

	void Update () {
		transform.Rotate(transform.forward * rotateSpeed * Time.deltaTime, Space.World);
	}
}
