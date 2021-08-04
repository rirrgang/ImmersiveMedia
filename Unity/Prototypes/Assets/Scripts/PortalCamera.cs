using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform player_cam;
    public Transform portal;
    public Transform otherPortal;

    public bool neg;

    public bool is_VR = false;

    void Start()
    {
        
    }


    void LateUpdate()
    {
        Vector3 playerOffsetFromPrtal = player_cam.position - otherPortal.position;
        if(!neg)
            transform.position = portal.position + playerOffsetFromPrtal;
        else
            transform.position = new Vector3(portal.position.x, -portal.position.y, portal.position.z) - new Vector3(playerOffsetFromPrtal.x, -playerOffsetFromPrtal.y, playerOffsetFromPrtal.z);
        float angularDiff = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotDiff = Quaternion.AngleAxis(angularDiff, Vector3.up);
        Vector3 newCamDir = portalRotDiff * player_cam.forward;
        

        if(is_VR == false){
            transform.rotation = Quaternion.LookRotation(newCamDir, Vector3.up);
        }else{
            transform.rotation = player_cam.rotation;  //Quaternion.LookRotation(new Vector3(newCamDir.x, 0, newCamDir.z), Vector3.up);
        }


     /*   Matrix4x4 m = portal.localToWorldMatrix * otherPortal.localToWorldMatrix * player_cam.localToWorldMatrix;

        portal_cam.SetPositionAndRotation(m.GetColumn(3), m.rotation);*/

    }
}
