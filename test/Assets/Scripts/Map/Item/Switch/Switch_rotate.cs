using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_rotate : MonoBehaviour {

	private Animator anim;
	public bool isOpenSwitch = false;
	private AnimatorStateInfo info;

	public GameObject target;
	public GameObject Player;
	public float rotateSpeed;
	private bool canRotate = false;
	private float oriRotation;

	void Start() {
		anim = GetComponent<Animator>();
	}

	void Update() {
		info = anim.GetCurrentAnimatorStateInfo(0);

		if (isOpenSwitch) {
			canRotate = true;
			oriRotation = target.transform.eulerAngles.y;
			isOpenSwitch = false;
		}

		if (canRotate) {
			target.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
			Player.transform.RotateAround(target.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
			gameObject.transform.RotateAround(target.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
			if (Mathf.Abs(target.transform.eulerAngles.y - oriRotation) >= 90) {
				canRotate = false;
			}
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
