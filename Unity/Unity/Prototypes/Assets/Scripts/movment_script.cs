using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment_script : MonoBehaviour
{

    public float speed = 10f;
    public float gravity = 9.81f;

    private Vector3 moveDirection = Vector3.zero;

    public CharacterController controller;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isGrounded){
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
