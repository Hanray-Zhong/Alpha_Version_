using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour {

	public GameObject breakWall;
	public float health;
    public GameObject TargetText;

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
        if (TargetText != null) {
            TargetText.SetActive(true);
        }
        Instantiate(breakWall, transform.position, transform.rotation);
		Destroy(gameObject);
    }

}
