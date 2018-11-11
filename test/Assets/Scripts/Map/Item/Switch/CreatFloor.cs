using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatFloor : MonoBehaviour {

	private Animator anim;
	public bool isOpenSwitch = false;
	private AnimatorStateInfo info;

	public GameObject floor;

	void Start() {
		anim = GetComponent<Animator>();
	}

	void Update() {
		info = anim.GetCurrentAnimatorStateInfo(0);

		if (isOpenSwitch) {
			floor.SetActive(true);
		}
	}

	private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && info.normalizedTime > 0.95f)
        {
            anim.Play("OpenSwitch", 0, 0);
			if (isOpenSwitch == false)
				isOpenSwitch = true;
        }
    }
}
