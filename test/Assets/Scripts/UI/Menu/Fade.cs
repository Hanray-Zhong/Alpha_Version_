using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {
	private CanvasGroup canvasGroup;
	private bool canFade = false;
	private bool canJianBian = true;

	public float changeSpeed;
	public GameObject nextText;

	void Start () {
		canvasGroup = gameObject.GetComponent<CanvasGroup>();
	}

	void Update () {
		if (canJianBian && canvasGroup.alpha < 1) {
			canvasGroup.alpha += changeSpeed * Time.deltaTime;
		}
		if (canvasGroup.alpha > 0 && canFade)
			canvasGroup.alpha -= changeSpeed * Time.deltaTime;
		if (canvasGroup.alpha == 0 && canFade) {
			if (nextText != null)
				nextText.SetActive(true);
			Destroy(gameObject);
		}
	}

	public void FadeClose() {
		canJianBian = false;
		canFade = true;
	}

}
