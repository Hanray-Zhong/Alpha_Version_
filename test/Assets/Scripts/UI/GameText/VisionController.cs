using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionController : MonoBehaviour {

	private Fade fade;
	private CanvasGroup canvasGroup;

	public float appearTime;

	void Start () {
		fade = GetComponent<Fade>();
	}
	
	void Update () {
		StartCoroutine(Close());
	}

	IEnumerator Close() {
		yield return new WaitForSeconds(appearTime);
		fade.FadeClose();
	}
}
