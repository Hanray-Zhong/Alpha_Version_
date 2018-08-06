using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour {

    public GameObject glod;

    public float force;

    private bool isOpen = false;

	private Animator anim;
    private AnimatorStateInfo info;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

    private void Update() {
        info = anim.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime > 0.9f && !isOpen)
        {
            GameObject newGold = Instantiate(glod, transform.position, glod.transform.rotation);
            newGold.GetComponent<Rigidbody>().AddForce((Vector3.up + Vector3.forward) * force * Time.deltaTime, ForceMode.Impulse);
            newGold.GetComponent<GoldCoinRotate>().price = 20;
            isOpen = true;
        }
    }

	private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            anim.enabled = true;
        }
    }
}
