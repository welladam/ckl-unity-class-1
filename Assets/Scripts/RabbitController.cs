using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour {

    float speed = 1.5f;
    float rootSpeed = 80;
    float rotation = 0f;
    float gravity = 8;

    Vector3 moveDirection = Vector3.zero;

    CharacterController controller;
    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(controller.isGrounded) {
            if(Input.GetKey(KeyCode.W)) {
                animator.SetBool("isWalking", true);
                moveDirection = new Vector3(0, 0, 1);
                moveDirection *= speed;
                moveDirection = transform.TransformDirection(moveDirection);
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                animator.SetBool("isWalking", false);
                moveDirection = new Vector3(0, 0, 0);
            }
        }

        rotation += Input.GetAxis("Horizontal") * rootSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotation, 0);

        moveDirection.y = gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
	}
}
