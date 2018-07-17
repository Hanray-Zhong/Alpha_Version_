using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : MonoBehaviour {

    public GameObject weapon;

    public float damage;

    void attackActive()
    {
        weapon.GetComponent<Damage>().damage = this.damage;
    }
    void attackDeactive()
    {
        weapon.GetComponent<Damage>().damage = 0;
    }
}
