using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed;
    public float walkSpeed = 10f;
    public float sprintSpeed = 20f;
    public float gravity = 9.81f;

    public Vector3 velocity = new Vector3(0f,0f,0f);

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;
    public LayerMask groundMask;

    public bool isGrounded;
    
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.W) && Input.GetKey("left shift")){
            speed = sprintSpeed;
        }else{
            speed = walkSpeed;
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }

        

        velocity.y -= gravity * Time.deltaTime * 2;

        controller.Move(velocity * Time.deltaTime);
    }
}
