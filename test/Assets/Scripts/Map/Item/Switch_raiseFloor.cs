using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_raiseFloor : MonoBehaviour {

	private Animator anim;
	public bool isOpenSwitch = false;
	private AnimatorStateInfo info;
	private Vector3 dir = new Vector3(0, 0, 0);
	private Transform floor_transform;

	public float floor_height;

	public GameObject floor;
	public float raise_speed;

	void Start() {
		anim = GetComponent<Animator>();
		floor_transform = floor.GetComponent<Transform>();
	}

	void Update() {
		floor_height = floor_transform.position.y;
		info = anim.GetCurrentAnimatorStateInfo(0);

		if (isOpenSwitch) {
			if (floor_height > 9.137f) {
				floor_transform.SetPositionAndRotation(new Vector3(floor_transform.position.x, 9.137f - 0.05f, floor_transform.position.z), floor_transform.rotation);
				dir = -Vector3.up;
				isOpenSwitch = false;
			}

			if (floor_height < 6.877f) {
				floor_transform.SetPositionAndRotation(new Vector3(floor_transform.position.x, 6.877f + 0.05f, floor_transform.position.z), floor_transform.rotation);
				dir = Vector3.up;
				isOpenSwitch = false;
			}
		}

		floor_transform.Translate(dir * raise_speed * Time.deltaTime, Space.World);

		floor_height = floor_transform.position.y;
		if (!isOpenSwitch && (floor_height > 9.137f || floor_height < 6.877f)) {
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
				Debug.Log("get!!");
        }
    }
}
