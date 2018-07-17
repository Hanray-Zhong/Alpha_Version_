using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public float health = 100;             //生命值

    private bool isDead = false;

    public void ApplyDamage(float damage)
    {
        if (damage < health)
        {
            health -= damage;
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
        // death
    }
}
