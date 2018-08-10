using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_animation : MonoBehaviour {

    public float jumpForce;

    void Jump()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
