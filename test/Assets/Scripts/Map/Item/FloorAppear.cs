using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorAppear : MonoBehaviour {

	public GameObject statue_1;
	public GameObject statue_2;

	public GameObject floor;

	private void Update() {
		if (statue_1.GetComponent<Statue>().isOpen && statue_2.GetComponent<Statue>().isOpen) {
			floor.SetActive(true);
			floor.GetComponent<FocusOn>().Focus();
		}
	}
}
