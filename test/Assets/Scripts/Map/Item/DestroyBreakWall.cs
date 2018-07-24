using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBreakWall : MonoBehaviour {
	
	public float DestroyTime;

	// Update is called once per frame
	void Update () {
		Destroy(gameObject, DestroyTime);
	}
}
