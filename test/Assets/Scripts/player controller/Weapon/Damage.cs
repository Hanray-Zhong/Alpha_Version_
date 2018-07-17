using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        MonsterUnit u = other.GetComponent<MonsterUnit>();
        if (u != null)
        {
            u.ApplyDamage(damage);
        }
    }
}
