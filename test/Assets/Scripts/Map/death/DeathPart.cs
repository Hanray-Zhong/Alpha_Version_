using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPart : MonoBehaviour {

    public GameObject reveivePoint;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<Unit>() != null)
        {
            other.transform.SetPositionAndRotation(reveivePoint.transform.position, reveivePoint.transform.rotation);
        }
    }
}
