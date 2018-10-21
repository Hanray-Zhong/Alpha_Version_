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
				if (child.gameObject.GetComponent<MeshCollider>() != null)
    				child.gameObject.GetComponent<MeshCollider>().enabled = false;
				if (child.gameObject.GetComponent<BoxCollider>() != null)
    				child.gameObject.GetComponent<BoxCollider>().enabled = false;
				
			}
		}
		Destroy(gameObject, DestroyTime);
	}
}
