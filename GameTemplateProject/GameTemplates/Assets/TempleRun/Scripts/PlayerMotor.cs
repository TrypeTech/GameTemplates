using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;
    public float speed = 5.0f;

    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    Animator anim;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        moveVector = Vector3.zero;


        // Gravity
        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity;
        }


        // X - Left and Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        // Y - Up and Down
        // moveVector.y = Input.GetAxisRaw("Vertical");
        moveVector.y = verticalVelocity;
        // Z - Forward and Backward
        moveVector.z = speed;

        anim.SetFloat("Forward", speed);
        controller.Move(moveVector * Time.deltaTime);
	}
}
