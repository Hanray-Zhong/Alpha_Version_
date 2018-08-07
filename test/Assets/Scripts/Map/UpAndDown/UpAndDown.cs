using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour {

    public float maxHeight;
    public float minHeight;
    public float speed;
    public int constCD;

    public float currentHeight;
    private Vector3 moveDir = new Vector3(0, 0, 0);
    private int CD = 0;
    private bool CDStart = false;
    private bool allowTOMove = false;

    private void Update()
    {
        currentHeight = transform.position.y;

        if (!CDStart && (currentHeight <= minHeight || currentHeight >= maxHeight))
        {
            CDStart = true;
            allowTOMove = false;
            moveDir = new Vector3(0, 0, 0);
        }
        else if (currentHeight <= minHeight && allowTOMove)
        {
            moveDir = Vector3.up;
            transform.SetPositionAndRotation(new Vector3(transform.position.x, minHeight + 0.05f, transform.position.z), transform.rotation);
            CD = 0;
            CDStart = false;
        }
        else if (currentHeight >= maxHeight && allowTOMove)
        {
            moveDir = -Vector3.up;
            transform.SetPositionAndRotation(new Vector3(transform.position.x, maxHeight - 0.05f, transform.position.z), transform.rotation);
            CD = 0;
            CDStart = false;
        }


        if (CD >= constCD)
        {
            allowTOMove = true;
        }

        if (CDStart)
        {
            CD++;
        }

        transform.Translate(moveDir * speed * Time.deltaTime, Space.World);
    }
}
