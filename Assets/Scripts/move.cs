using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Mirror;

public class move : NetworkBehaviour
{
    private float speed;
    public float walkspeed = 0.2f;
    public float runspeed = 0.06f;
    public float rotationspeed = 2.5f;

    // Rigidbody rigidBody;
    Animator animator;
    CapsuleCollider capsuleCollider;

    private float yaw=0;
    //private float pitch = 0;

    public Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.parent.GetComponent<NetworkIdentity>().hasAuthority)
        {
            // rigidBody = gameObject.GetComponent<Rigidbody>();
            animator= gameObject.GetComponent<Animator>();
            capsuleCollider= gameObject.GetComponent<CapsuleCollider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.parent.GetComponent<NetworkIdentity>().hasAuthority)
        {
            float z = Input.GetAxis("Vertical") * speed;
            float y = Input.GetAxis("Horizontal") * rotationspeed;
            //transform.Translate(0, 0, z);
            //transform.Rotate(0, y,0);
            yaw += rotationspeed * Input.GetAxis("Mouse X");
            //pitch += rotationspeed * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(0, yaw, 0);
            cameraTransform.eulerAngles = new Vector3(0, yaw, 0);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.Z))
                {
                    animator.SetBool("IsWalking", false);
                    animator.SetBool("IsRunning", true);
                    animator.SetBool("IsIdle", false);
                }
                else
                {
                    animator.SetBool("IsWalking", false);
                    animator.SetBool("IsRunning", false);
                    animator.SetBool("IsIdle", true);
                }
                speed = runspeed;
            }
            else
            {
                if (Input.GetKey(KeyCode.Z))
                {
                    animator.SetBool("IsWalking", true);
                    animator.SetBool("IsRunning", false);
                    animator.SetBool("IsIdle", false);
                }
                else
                {
                    animator.SetBool("IsWalking", false);
                    animator.SetBool("IsRunning", false);
                    animator.SetBool("IsIdle", true);
                }
                speed = walkspeed;
            }
        }
    }
}
