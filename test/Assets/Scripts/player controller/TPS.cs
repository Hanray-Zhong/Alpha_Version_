using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TPS : MonoBehaviour {
    public Transform player;
    public float rotateSpeed;
    public float distance;
    public Vector3 offsetPosition;
    public Vector3 origin_offsetposition;
    public bool allowToRotate = true;
    public float changeDistance = 0;

    private bool isRotating = true;
    private float originDistance;
    private MoveCamera moveCamera;
    private Ray ray;



    private void Start()
    {
        offsetPosition = transform.position - player.position;
        origin_offsetposition = offsetPosition;
        originDistance = offsetPosition.magnitude;
        moveCamera = gameObject.GetComponent<MoveCamera>();
    }

    private void Update()
    {
        SrollView();
        transform.position = player.position + offsetPosition;
        RotateView();
    }

    private void SrollView()
    {
        distance = offsetPosition.magnitude;
        changeDistance = originDistance - distance;
        if (!moveCamera.isBlocked && !moveCamera.isBackBlocked && distance <= originDistance)
        {
            distance += 0.2f;
        }
        else if (moveCamera.isBlocked)
        {
            distance -= 0.2f;
        }
        else if (moveCamera.isBackBlocked)
        {
            // content...
        }
        offsetPosition = offsetPosition.normalized * distance;
    }

    private void RotateView()
    {
        if (isRotating)
        {
            float angle;
            angle = Vector3.Angle(Vector3.up, transform.forward);
            transform.RotateAround(player.position, Vector3.up, Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime);
            if (angle >= 150)
            {
                if(Input.GetAxis("Mouse Y") > 0)
                {
                    allowToRotate = true;
                }
                else
                {
                    allowToRotate = false;
                }
            }
            if (angle <= 30)
            {
                if (Input.GetAxis("Mouse Y") < 0)
                {
                    allowToRotate = true;
                }
                else
                {
                    allowToRotate = false;
                }
            }
            if (allowToRotate)
            {
                transform.RotateAround(player.position, -transform.right, Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime);
            }
            offsetPosition = transform.position - player.position;
        }
        else
        {
            return;
        }
    }
}
