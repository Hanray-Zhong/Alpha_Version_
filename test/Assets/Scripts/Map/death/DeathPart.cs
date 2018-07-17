using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPart : MonoBehaviour {

    public GameObject reveivePoint;
    public GameObject cameraReceivePoint;
    public GameObject Camera;


    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetPositionAndRotation(reveivePoint.transform.position, reveivePoint.transform.rotation);
        Camera.transform.SetPositionAndRotation(cameraReceivePoint.transform.position, cameraReceivePoint.transform.rotation);
        Camera.GetComponent<TPS>().offsetPosition = Camera.GetComponent<TPS>().origin_offsetposition;
        Camera.GetComponent<TPS>().allowToRotate = true;
    }
}
