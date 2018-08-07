using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBoxes : MonoBehaviour {

	public GameObject Box; 
	public float pushSpeed;

	private void OnTriggerStay(Collider other)
    {
        Debug.Log("get!");
        if (other.tag == "Player" && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            Box.transform.Translate(-transform.forward * pushSpeed * Time.deltaTime);
        }
    }
}
