using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer_damage : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<Unit>() != null)
        {
            other.GetComponent<Unit>().ApplyDamage(100);
        }
    }
}
