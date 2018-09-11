using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCloud : MonoBehaviour {

	private RawImage rawImage;
	private Rect UV;
	
	public float moveSpeed; 

	void Start () {
		rawImage = gameObject.GetComponent<RawImage>();
	}
	
	void Update () {
		UV = rawImage.uvRect;
		if (UV.x < 1) {
			UV.x += moveSpeed*Time.deltaTime;
			rawImage.uvRect = UV;
		}
		
		else {
			UV.x = 0;
			rawImage.uvRect = UV;
		}	
	}
}
