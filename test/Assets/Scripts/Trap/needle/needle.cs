﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needle : MonoBehaviour {

    public float maxHeight;
    public float minHeight;
    public float speed;
    public float damage;
    public int constCD;

    private float currentHeight;
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
            CD = 0;
            CDStart = false;
        }
        else if (currentHeight >= maxHeight && allowTOMove)
        {
            moveDir = -Vector3.up;
            CD = 0;
            CDStart = false;
        }
        
        
        if (CD >= 100)
        {
            allowTOMove = true;
        }

        if (CDStart)
        {
            CD++;
        }

        transform.Translate(moveDir * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        Unit u = other.GetComponent<Unit>();
        if (u != null)
        {
            u.ApplyDamage(damage);
        }
    }
}