using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPart : MonoBehaviour {

    public GameObject reveivePoint;
    public GameObject reveivePoint_ball;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<Unit>() != null)
        {
            other.transform.SetPositionAndRotation(reveivePoint.transform.position, reveivePoint.transform.rotation);
        }

        if (other.tag == "MapItem") {
            // 再来一个球
        }
    }
}
