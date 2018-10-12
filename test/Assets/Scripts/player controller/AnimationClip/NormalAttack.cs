using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : MonoBehaviour {

    public GameObject weapon;

    public float damage;

    void attackActive()
    {
        weapon.GetComponent<BoxCollider>().enabled = true;
        weapon.GetComponent<Damage>().damage = this.damage;
    }
    void attackDeactive()
    {
        weapon.GetComponent<BoxCollider>().enabled = false;
        weapon.GetComponent<Damage>().damage = 0;
    }
}
