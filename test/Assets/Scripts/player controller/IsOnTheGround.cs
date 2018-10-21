using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOnTheGround : MonoBehaviour {

    public float maxDistance;

    public bool isOnTheGround;
    private Ray ray1;
    private Ray ray2;
    private Ray ray3;
    private Ray ray4;
    private Ray ray5;
    private float CD;

    private void Update()
    {
        ray1 = new Ray(transform.position + new Vector3(0, 0, 0)      + new Vector3(0, 0.5f, 0), -Vector3.up);
        ray2 = new Ray(transform.position + new Vector3(0.25f, 0, 0)  + new Vector3(0, 0.5f, 0), -Vector3.up);
        ray3 = new Ray(transform.position + new Vector3(-0.25f, 0, 0) + new Vector3(0, 0.5f, 0), -Vector3.up);
        ray4 = new Ray(transform.position + new Vector3(0, 0, 0.25f)  + new Vector3(0, 0.5f, 0), -Vector3.up);
        ray5 = new Ray(transform.position + new Vector3(0, 0, -0.25f) + new Vector3(0, 0.5f, 0), -Vector3.up);
        RaycastHit hitInfo;

        isOnTheGround = Physics.Raycast(ray1, out hitInfo, maxDistance, 1 << LayerMask.NameToLayer("Map")) |
                        Physics.Raycast(ray2, out hitInfo, maxDistance, 1 << LayerMask.NameToLayer("Map")) |
                        Physics.Raycast(ray3, out hitInfo, maxDistance, 1 << LayerMask.NameToLayer("Map")) |
                        Physics.Raycast(ray4, out hitInfo, maxDistance, 1 << LayerMask.NameToLayer("Map")) |
                        Physics.Raycast(ray5, out hitInfo, maxDistance, 1 << LayerMask.NameToLayer("Map")) ;
    }

}
