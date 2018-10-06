using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renew : MonoBehaviour {
    public GameObject[] objs;
    public Material black;
    public Material gray;
    public GameObject door;
    public float speed;

    private bool isLocked = true;
    private ChangeTarget changeTarget;
    private bool needCheck = true;

	private void Awake() {
		changeTarget = GetComponent<ChangeTarget>();
	}

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
            Transform transform = door.GetComponent<Transform>();
            if (transform.position.y > 5)
            {
                transform.Translate(-Vector3.up * speed * Time.deltaTime, Space.World);
            }
            if (needCheck) {
                this.ChangeTarget();
                needCheck = false;
            }
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

    private void ChangeTarget() {
		if (changeTarget != null) {
			changeTarget.Change();
		}
	}
}
