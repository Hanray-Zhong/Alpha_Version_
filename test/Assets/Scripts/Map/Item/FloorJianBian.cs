using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorJianBian : MonoBehaviour {

	public Material _material;
	private float a = 0;

	private void Awake() {
		_material.SetVector("_Color", new Vector4(1, 1, 1, 0));
	}

	private void Update() {
		if (_material.color.a <= 1) {
			_material.SetVector("_Color", new Vector4(1, 1, 1, a));
			a += 0.01f;
		}
	}
}
