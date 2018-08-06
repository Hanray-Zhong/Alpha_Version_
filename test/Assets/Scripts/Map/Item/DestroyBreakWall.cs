using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBreakWall : MonoBehaviour {
	
	public float DestroyTime;

	private int time;

	// Update is called once per frame
	void Update () {
		time++;
		if (time >= 100)
		{
			foreach (Transform child in transform)
			{
    			child.gameObject.GetComponent<BoxCollider>().enabled = false;
			}
		}
		Destroy(gameObject, DestroyTime);
	}
}
