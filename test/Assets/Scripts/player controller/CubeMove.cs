using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MoveDir
{
    Up = 1,
    Down = -1,
    Left = 10,
    Right = -10,
}


public class CubeMove : MonoBehaviour {

    public GameObject Camera;
    public Transform x_z_dir;
    public Animator anim;

    public float rotateSpeed;
    public float moveSpeed;
    public bool isPushBox = false;


    private Vector3 forward;
    private Vector3 back;
    private Vector3 left;
    private Vector3 right;
    private AnimatorStateInfo info;
    private float oriMoveSpeed;
    private bool isNearWall = false;

    public bool isOnTheGround;
    public int moveDirValue = 0;
    public bool isAttack = false;

    private void Awake() {
        oriMoveSpeed = moveSpeed;
    }


    void FixedUpdate() {
        // 初始化
        if (!isPushBox) 
        {
            moveSpeed = oriMoveSpeed;
        }
        forward = new Vector3(Camera.transform.forward.x, 0, Camera.transform.forward.z);
        back = new Vector3(-Camera.transform.forward.x, 0, -Camera.transform.forward.z);
        left = new Vector3(-Camera.transform.right.x, 0, -Camera.transform.right.z);
        right = new Vector3(Camera.transform.right.x, 0, Camera.transform.right.z);
        moveDirValue = 0;
        isOnTheGround = gameObject.GetComponent<IsOnTheGround>().isOnTheGround;
        if (isOnTheGround)
            anim.SetBool("isOnTheGround", true);
        else
            anim.SetBool("isOnTheGround", false);
        /*---------------------------------------------*/


        if (Input.GetKey(KeyCode.W))
        {
            moveDirValue += (int)MoveDir.Up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirValue += (int)MoveDir.Down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirValue += (int)MoveDir.Left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirValue += (int)MoveDir.Right;
        }

        // animator
        info = anim.GetCurrentAnimatorStateInfo(0);
        if (!info.IsName("anm_jump"))
        {
            anim.SetBool("isJump", false);
        }
        else if (info.IsName("anm_jump") && info.normalizedTime >= 0.95f)
        {
            anim.SetBool("isJump", false);
        }

        if (Input.GetKey(KeyCode.Space) && isOnTheGround && !info.IsName("Hit"))
        {
            if (!info.IsName("anm_jump") || (info.IsName("anm_jump") && info.normalizedTime >= 0.85f))
            {
                anim.Play("anm_jump", 0, 0);
            }
            anim.SetBool("isJump", true);
        }
        else if (moveDirValue == 0)
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isMove", false);
        }
        else
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isMove", true);
        }

        if (info.IsName("anm_jump"))
        {
            if (!isOnTheGround && info.normalizedTime >= 0.4f)
            {
                anim.speed = 0.1f;
            }
            else
            {
                anim.speed = 1;
            }
        }
        if (isOnTheGround)
        {
            anim.speed = 1;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && !info.IsName("normal_attack") && !info.IsName("anm_jump"))
        {
            anim.Play("normal_attack");
            anim.SetBool("isAttack", true);
        }
        else
        {
            anim.SetBool("isAttack", false);
        }

        if (info.IsName("normal_attack"))
        {
            isAttack = true;
        }
        else if (!info.IsName("normal_attack") || info.normalizedTime >= 0.9f)
        {
            isAttack = false;
        }

        Vector3 rotateDir = GetRotateDir(moveDirValue);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            Rotating(rotateDir.x, rotateDir.z);
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
        x_z_dir.forward = new Vector3(Camera.transform.forward.x, 0, Camera.transform.forward.z);
        if (!isAttack && !info.IsName("Hit") && !isNearWall)
        {
            transform.Translate(GetMoveDir(moveDirValue) * moveSpeed * Time.deltaTime, x_z_dir);
        }
    }

    private void Rotating(float hor, float ver)
    {  
        Vector3 dir = new Vector3(hor, 0, ver);  
        Quaternion quaDir = Quaternion.LookRotation(dir, Vector3.up);  
        transform.rotation = Quaternion.Lerp(transform.rotation, quaDir, Time.fixedDeltaTime * rotateSpeed);
    }

    public Vector3 GetMoveDir(int moveDirValue)
    {
        Vector3 dir = new Vector3(0, 0, 0);

        switch (moveDirValue)
        {
            case 1 :
                dir.z = 1;
                break;
            case -1 :
                dir.z = -1;
                break;
            case 10 :
                dir.x = -1;
                break;
            case -10 :
                dir.x = 1;
                break;
            case 11 :
                dir.x = -1;
                dir.z = 1;
                break;
            case -9 :
                dir.x = 1;
                dir.z = 1;
                break;
            case 9 :
                dir.x = -1;
                dir.z = -1;
                break;
            case -11 :
                dir.x = 1;
                dir.z = -1;
                break;
        }

        dir = dir.normalized;
        return dir;
    }

    private Vector3 GetRotateDir(int moveDirValue)
    {
        Vector3 dir = new Vector3(0, 0, 0);

        switch (moveDirValue)
        {
            case 1:// 前
                dir = forward;
                break;
            case -1:// 后
                dir = back;
                break;
            case 10:// 左
                dir = left;
                break;
            case -10:// 右
                dir = right;
                break;
            case 11:// 左上
                dir = left + forward;
                break;
            case -9:// 右上
                dir = right + forward;
                break;
            case 9:// 左下
                dir = left + back;
                break;
            case -11:// 右下
                dir = right + back;
                break;
        }

        return dir.normalized;
    }
}
