using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriPointMove : MonoBehaviour {

	public GameObject inLight;
	
	void Update () {
		if (inLight != null)
			transform.position = inLight.GetComponent<ReflectLight>().hitInfo.point;
	}
}
