using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour {

    public GameObject glod;
    public int price;
    public float force;

    private bool isOpen = false;
    private int coinNum = 0;
	private Animator anim;
    private AnimatorStateInfo info;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

    private void Update() {
        info = anim.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime > 0.9f && !isOpen)
        {
            Debug.Log("get");
            InvokeRepeating("CreatCoin", 0, 0.2f);
            isOpen = true;
        }
        if (coinNum >= 10) {
            this.CancelInvoke();
        }
    }

	private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            anim.enabled = true;
        }
    }

    private void CreatCoin() {
        GameObject newGold = Instantiate(glod, transform.position, glod.transform.rotation);
        newGold.GetComponent<Rigidbody>().AddForce((transform.up - transform.right) * force * Time.deltaTime, ForceMode.Impulse);
        newGold.GetComponent<GoldCoinRotate>().price = price;
        coinNum++;
    }
}
