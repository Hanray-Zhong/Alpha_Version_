using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public float health = 100;             //生命值
    public int gold = 0;
    public Animator anim;


    private bool isDead = false;


    public void ApplyDamage(float damage)
    {
        if (damage < health)
        {
            health -= damage;
            anim.Play("Hit");
        }

        else
        {
            isDead = true;
            health = 0;
            if (isDead)
            {
                Destruct();
            }
        }
    }

    private void Destruct()
    {
        anim.SetBool("isDead", true);
        GetComponent<CubeMove>().enabled = false;
        // GetComponent<CapsuleCollider>().enabled = false;
    }
}
