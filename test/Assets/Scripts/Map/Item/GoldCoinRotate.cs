using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoinRotate : MonoBehaviour {

	public float rotateSpeed;
    public int price;

	void Update () {
		transform.Rotate(transform.right * rotateSpeed * Time.deltaTime, Space.World);
	}

	private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
			other.GetComponent<Unit>().gold += price;
            Destroy(gameObject);
        }

        
    }
}
