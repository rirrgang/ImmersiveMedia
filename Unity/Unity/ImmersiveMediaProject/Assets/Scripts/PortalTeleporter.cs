using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{

    public Transform player;
    public Transform receiver;
    
    public bool playerIsOverlapping = false;

    public float dotProduct;

    public float rotationalDiff;

    public Vector3 positionOffset;

    public bool turnAround;

    public bool inverseDotProduct;

    void Update()
    {
        if(playerIsOverlapping){
            Vector3 portalToPlayer = player.position - transform.position;
            dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            // If this is true: The player has moved across the portal
            if(dotProduct < 0f){
               teleport(portalToPlayer);
            }
                //playerIsOverlapping = false;
            
            
            
            

        }

        void teleport(Vector3 portalToPlayer){
            Debug.Log("I should teleport him");
                // Teleport him
                rotationalDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                if(turnAround == true){
                    rotationalDiff += 180;
                }
                
                player.Rotate(Vector3.up, rotationalDiff);

                positionOffset = Quaternion.Euler(0f, rotationalDiff, 0f) * portalToPlayer;
                player.position = receiver.transform.position + positionOffset;

                playerIsOverlapping = false;
        }
        
            
            
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" || other.tag == "Player_VR"){
            playerIsOverlapping = true;
            Debug.Log("PLAYER ENTERED!");
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player" || other.tag == "Player_VR"){
            playerIsOverlapping = false;
            Debug.Log("PLAYER EXITED!");
        }
    }
}
