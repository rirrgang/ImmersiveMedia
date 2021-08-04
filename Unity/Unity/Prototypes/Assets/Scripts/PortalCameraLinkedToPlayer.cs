using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraLinkedToPlayer : MonoBehaviour
{
    
    public Transform player_cam;
    public Transform player;
    public Vector3 player_pos;
    public Vector3 player_cam_pos;
    public Transform portal;
    public Transform otherPortal;
    public Vector3 playerOffsetFromCamera;

    private Vector3 playerOffsetFromPortal;
    

    public bool neg;

    private void Start() {  
        player_cam_pos = player_cam.position;
        playerOffsetFromPortal = player_cam.position - otherPortal.position;
        transform.position = new Vector3(portal.position.x, transform.position.y, portal.position.z) - new Vector3(playerOffsetFromPortal.x, 0f, playerOffsetFromPortal.z);

        playerOffsetFromCamera = player_cam.position - transform.position;
    }

   void LateUpdate()
    {
        Vector3 playerOffsetFromPrtal = player_cam.position - otherPortal.position;

        transform.position = new Vector3(portal.position.x, player_cam.position.y, portal.position.z) - new Vector3(playerOffsetFromPrtal.x, playerOffsetFromCamera.y, playerOffsetFromPrtal.z);

        transform.rotation = new Quaternion(player_cam.rotation.x, player.rotation.y, player_cam.rotation.z, player.rotation.w);;
        
        
        //transform.position = player_cam.position + playerOffsetFromCamera;

        // if(!neg){
        //     transform.position = player_cam.position + playerOffsetFromCamera;
        // }else
        //     transform.position = new Vector3(portal.position.x, -portal.position.y, portal.position.z) - new Vector3(playerOffsetFromPortal.x, -playerOffsetFromPortal.y, playerOffsetFromPortal.z);
        // float angularDiff = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        // Quaternion portalRotDiff = Quaternion.AngleAxis(angularDiff, Vector3.up);
        // Vector3 newCamDir = portalRotDiff * player_cam.forward;

        // transform.rotation = Quaternion.LookRotation(newCamDir, Vector3.up);


     /*   Matrix4x4 m = portal.localToWorldMatrix * otherPortal.localToWorldMatrix * player_cam.localToWorldMatrix;

        portal_cam.SetPositionAndRotation(m.GetColumn(3), m.rotation);*/

    }
}
