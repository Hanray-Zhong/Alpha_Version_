using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour {

	private Animator anim;
	public bool isOpenSwitch = false;
	private AnimatorStateInfo info;
	private Vector3 dir = new Vector3(0, 0, 0);
	private Transform floor_transform;

	public float floor_position_x;
	public float max_x_des;
	public float min_x_des;

	public GameObject floor;
	public float raise_speed;

	void Start() {
		anim = GetComponent<Animator>();
		floor_transform = floor.GetComponent<Transform>();
	}

	void Update() {
		floor_position_x = floor_transform.position.x;
		info = anim.GetCurrentAnimatorStateInfo(0);

		if (isOpenSwitch) {
			if (floor_position_x > max_x_des) {
				floor_transform.SetPositionAndRotation(new Vector3(floor_transform.position.x, max_x_des - 0.05f, floor_transform.position.z), floor_transform.rotation);
				dir = -Vector3.forward;
				isOpenSwitch = false;
			}

			if (floor_position_x < min_x_des) {
				floor_transform.SetPositionAndRotation(new Vector3(floor_transform.position.x, min_x_des + 0.05f, floor_transform.position.z), floor_transform.rotation);
				dir = Vector3.forward;
				isOpenSwitch = false;
			}
		}

		floor_transform.Translate(dir * raise_speed * Time.deltaTime, Space.World);

		floor_position_x = floor_transform.position.x;
		if (!isOpenSwitch && (floor_position_x > max_x_des || floor_position_x < min_x_des)) {
			dir = new Vector3(0, 0, 0);
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
