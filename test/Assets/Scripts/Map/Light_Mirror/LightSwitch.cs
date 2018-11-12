using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {

	public GameObject Crystal_1;
	public GameObject Crystal_2;
	public GameObject target;
	
	public bool notFinished = true;

	public float ori_Y_position;

	private void Awake() {
		ori_Y_position = target.transform.position.y;
	}

	private void Update() {
		if (Crystal_1.GetComponent<Finish>().isOpen && Crystal_2.GetComponent<Finish>().isOpen) {
			
			if (target.transform.position.y <= ori_Y_position) {
				gameObject.GetComponent<ChangeTarget>().Change();
			}
			if (target.transform.position.y <= -0.0689) {
				target.transform.Translate(Vector3.up * 2 * Time.deltaTime, Space.World);
			}
		}
	}
}
