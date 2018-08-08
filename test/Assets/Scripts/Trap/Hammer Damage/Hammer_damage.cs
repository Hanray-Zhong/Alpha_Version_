using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer_damage : MonoBehaviour {

    public GameObject reveivePoint;

	private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<Unit>() != null)
        {
            other.GetComponent<Unit>().ApplyDamage(20);
            other.transform.SetPositionAndRotation(reveivePoint.transform.position, reveivePoint.transform.rotation);
        }
    }
}
