using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_animation : MonoBehaviour {

    public float jumpForce;

    private IsOnTheGround isOnTheGround;
    private Vector3 originColliderPos = new Vector3(0, 0.71f, 0);
    private Vector3 newColliderPos = new Vector3(0, 0.71f, 0);

    private void Update()
    {
        isOnTheGround = gameObject.GetComponent<IsOnTheGround>();
        if (isOnTheGround.isOnTheGround)
        {
            gameObject.GetComponent<CapsuleCollider>().center = originColliderPos;
        }
        else
        {
            gameObject.GetComponent<CapsuleCollider>().center = newColliderPos;
        }
    }

    void Jump()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
