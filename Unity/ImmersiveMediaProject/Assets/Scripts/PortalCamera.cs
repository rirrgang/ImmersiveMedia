using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform player_cam;
    public Transform portal;
    public Transform otherPortal;

    public bool reverse;

    public bool neg;

    public bool look_behind = false;

    public bool is_VR = false;

    public bool lock_y = false;

    void Start()
    {
        
    }


    void LateUpdate()
    {
        Vector3 playerOffsetFromPortal;
        if(!reverse){
            //Original
            playerOffsetFromPortal = player_cam.position - otherPortal.position;
        }else{
            playerOffsetFromPortal = player_cam.position + otherPortal.position;
        }
        


        if(!neg)
            if(lock_y){
                transform.position = new Vector3(portal.position.x, 0f, portal.position.z) + new Vector3(playerOffsetFromPortal.x, playerOffsetFromPortal.y, playerOffsetFromPortal.z);
            }else{
                //original
                transform.position = new Vector3(portal.position.x, portal.position.y, portal.position.z) + new Vector3(playerOffsetFromPortal.x, playerOffsetFromPortal.y, playerOffsetFromPortal.z);
                
            }
        else
            transform.position = new Vector3(portal.position.x, -portal.position.y, portal.position.z) - new Vector3(playerOffsetFromPortal.x, -playerOffsetFromPortal.y, playerOffsetFromPortal.z);
        float angularDiff = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        if(look_behind){
            angularDiff += 180;
        }

        Quaternion portalRotDiff = Quaternion.AngleAxis(angularDiff, Vector3.up);

        Vector3 newCamDir = portalRotDiff * player_cam.forward;
        

        if(is_VR == false){
            transform.rotation = Quaternion.LookRotation(newCamDir, Vector3.up);
        }else{
            transform.rotation = Quaternion.LookRotation(new Vector3(newCamDir.x, 0, newCamDir.z), Vector3.up);
        }


     /*   Matrix4x4 m = portal.localToWorldMatrix * otherPortal.localToWorldMatrix * player_cam.localToWorldMatrix;

        portal_cam.SetPositionAndRotation(m.GetColumn(3), m.rotation);*/

    }
}
