using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoinRotate : MonoBehaviour {

	public float rotateSpeed;
    public int price;
    public float radius;
    public float moveSpeed;

    private int playerLayer = 9;
    private GameObject target;
    private bool canMove = false;
    
    private void Awake() {
        StartCoroutine(StartMove());
    }

	void Update () {
		transform.Rotate(transform.right * rotateSpeed * Time.deltaTime, Space.World);

        // 金币自动吸取
        Collider[] cols = Physics.OverlapSphere(transform.position, radius, 1 << playerLayer);
        if (cols.Length != 0) {
            foreach(var item in cols) {
                target = item.gameObject;
            }
        }
        if (target != null && canMove) {
            Vector3 moveDir = target.transform.position - transform.position;
            transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
        }
	}

	private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
			other.GetComponent<Unit>().gold += price;
            Destroy(gameObject);
        }
    }

    IEnumerator StartMove() {
        yield return new WaitForSeconds(1f);
        canMove = true;
    }
}
