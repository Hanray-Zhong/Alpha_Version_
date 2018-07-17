using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTest : MonoBehaviour {

    public GameObject player;

    private void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        transform.right = new Vector3(dir.x, 0, dir.z);
    }
}
