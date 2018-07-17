using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
    public GameObject player;
    public bool isBlocked;
    public bool isBackBlocked;

    private Ray ray;
    private Ray backRay;
    private float distance;
    public float originDistance;

    private void Start()
    {
        originDistance = Vector3.Distance(transform.position, player.transform.position);
    }

    private void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        backRay = new Ray(player.transform.position, -transform.forward);
        RaycastHit hitInfo;
        distance = Vector3.Distance(transform.position, player.transform.position);

        isBlocked = Physics.Raycast(ray, out hitInfo, distance, 1 << LayerMask.NameToLayer("Map"));

        isBackBlocked = Physics.Raycast(backRay, out hitInfo, 7, 1 << LayerMask.NameToLayer("Map"));
    }
}
