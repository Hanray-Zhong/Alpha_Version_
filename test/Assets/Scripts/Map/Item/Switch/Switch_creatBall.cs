using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_creatBall : MonoBehaviour {

	private Animator anim;
	public bool isOpenSwitch = false;
	private AnimatorStateInfo info;

	public GameObject receivePoint;
	public GameObject BallPrefab;
	public GameObject ball;

	void Start() {
		anim = GetComponent<Animator>();
	}

	void Update() {
		info = anim.GetCurrentAnimatorStateInfo(0);

		if (isOpenSwitch) {
			Destroy(ball);
			ball = Instantiate(BallPrefab, receivePoint.transform.position, BallPrefab.transform.rotation);
			isOpenSwitch = false;
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
