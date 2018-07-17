using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour {

    public GameObject[] objs;
    public Material black;
    public Material gray;

    public string currentMaterials;

    
    private void Start()
    {
        currentMaterials = "gray";
    }


    private void OnTriggerEnter(Collider other)
    {
        foreach (var item in objs)
        {
            if (item.GetComponent<Change>().currentMaterials.Equals("black"))
            {
                item.GetComponent<Renderer>().material = GameObject.Instantiate(gray);
                item.GetComponent<Change>().currentMaterials = "gray";
            }
            else if (item.GetComponent<Change>().currentMaterials.Equals("gray"))
            {
                item.GetComponent<Renderer>().material = GameObject.Instantiate(black);
                item.GetComponent<Change>().currentMaterials = "black";
            }
        }
    }

}
