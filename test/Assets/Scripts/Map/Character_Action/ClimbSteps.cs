using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbSteps : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        if(rigidbody != null)
        {
            rigidbody.useGravity = false;
        }
        else
        {
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.useGravity = true;
        }
        else
        {
            return;
        }
    }
}
