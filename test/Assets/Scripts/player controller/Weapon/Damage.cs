using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        MonsterUnit mu = other.GetComponent<MonsterUnit>();
        if (mu != null)
        {
            mu.ApplyDamage(damage);
        }

        BreakWall bw = other.GetComponent<BreakWall>();
        if (bw != null){
            bw.ApplyDamage(damage);
        }
    }
}
