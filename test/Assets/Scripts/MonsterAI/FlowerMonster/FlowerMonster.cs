using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerMonster : MonoBehaviour {

    public float searchRadius;
    public float attackRadius;
    public float rotateSpeed;
    public float shootForce;
    public GameObject seed;
    public GameObject shootPos;

    private Ray ray;
    private GameObject target;
    private Vector3 dir;
    private float distance;
    private Animator anim;
    private AnimatorStateInfo info;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        RaycastHit hitInfo;
        Collider[] cols = Physics.OverlapSphere(transform.position, searchRadius, 1 << LayerMask.NameToLayer("Player"));
        if (cols.Length != 0)
        {
            foreach (var item in cols)
            {
                target = item.gameObject;
            }
        }
        else
        {
            target = null;
        }

        if (target != null)
        {
            dir = target.transform.position - transform.position + new Vector3(0, 0.3f, 0);
            distance = Vector3.Distance(target.transform.position, transform.position);
            ray = new Ray(transform.position, dir);

            /*
            Quaternion wantedRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, rotateSpeed * Time.deltaTime);
            */
            transform.right = new Vector3(dir.x, 0, dir.z);

            if (distance <= attackRadius && !Physics.Raycast(ray, out hitInfo, distance, 1 << LayerMask.NameToLayer("Map")))
            {
                anim.SetBool("isAttack", true);
            }
            else
            {
                anim.SetBool("isAttack", false);
            }

            info = anim.GetCurrentAnimatorStateInfo(0);
            if (info.IsName("Attack_anim"))
            {
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            }
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    public void Attack()
    {
        GameObject newSeed = Instantiate(seed, shootPos.transform.position, shootPos.transform.rotation);
        newSeed.GetComponent<Rigidbody>().AddForce(shootPos.transform.up * shootForce, ForceMode.Impulse);
    }
}
