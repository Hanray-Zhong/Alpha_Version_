using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour {

	private Animator anim;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            anim.enabled = true;
        }
    }
}
