using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerController : MonoBehaviour
{

    public SteamVR_Action_Vector2 input;
    public float speed = 1;
    public float gravity = 9.81f;
    private Vector3 gravityVector;
    private CharacterController characterController;

    private void Start() {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        gravityVector = new Vector3(0, gravity, 0);

        //if(input.axis.magnitude > 0.1f){
            Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
            characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - gravityVector * Time.deltaTime);
        //}
        
        
    }
}
