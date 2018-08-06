using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renew : MonoBehaviour {
    public GameObject[] objs;
    public Material black;
    public Material gray;

    private bool isLocked = true;

    void Update() {
        isLocked = true;
        foreach (var item in objs)
        {
            if (item.GetComponent<Change>().currentMaterials == "black") 
            {
                isLocked = false;
            }
            else
            {
                isLocked = true;
                return;
            }
        }

        if (!isLocked) 
        {
            // open the door
            Debug.Log("get!!!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (var item in objs)
        {
            item.GetComponent<Renderer>().material = GameObject.Instantiate(gray);
            item.GetComponent<Change>().currentMaterials = "gray";
        }
    }
}
