using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour {

    public float destroyTime;
    public float damage;

	void Update () {

        Destroy(gameObject, destroyTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        Unit u = other.GetComponent<Unit>();
        if (u != null)
        {
            u.ApplyDamage(damage);
            Destroy(gameObject);
        }
    }
}
