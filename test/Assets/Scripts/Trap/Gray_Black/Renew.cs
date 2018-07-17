using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renew : MonoBehaviour {
    public GameObject[] objs;
    public Material black;
    public Material gray;

    private void OnTriggerEnter(Collider other)
    {
        foreach (var item in objs)
        {
            item.GetComponent<Renderer>().material = GameObject.Instantiate(gray);
            item.GetComponent<Change>().currentMaterials = "gray";
        }
    }
}
