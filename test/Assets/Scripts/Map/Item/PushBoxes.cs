using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBoxes : MonoBehaviour {

	public GameObject Box; 
	public float pushSpeed;
    public GameObject Box_collider;
    public bool isNearTheWall = false;
    public float overlap_radius;

    void Update() {
        Collider[] cols = Physics.OverlapSphere(transform.position, overlap_radius, 1 << LayerMask.NameToLayer("Map"));
        if (cols.Length != 0) 
        {
            isNearTheWall = true;
        }
        else
        {
            isNearTheWall = false;
        }
    }

	private void OnTriggerStay(Collider other)
    {
        if (!Box_collider.GetComponent<PushBoxes>().isNearTheWall && other.tag == "Player" && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            // Box.transform.Translate(-transform.forward * pushSpeed * Time.deltaTime);
            Box.GetComponent<Rigidbody>().AddForce(-transform.forward * pushSpeed, ForceMode.VelocityChange);
            other.GetComponent<CubeMove>().moveSpeed = 3;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!Box_collider.GetComponent<PushBoxes>().isNearTheWall && other.tag == "Player" && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            other.GetComponent<CubeMove>().moveSpeed = 5;
        }
    }

}
