using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV_VR_Setup : MonoBehaviour
{
    
    public Camera player_cam;
    public List<Camera> cameras;
    public float FOV = 75.0f;


    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        FOV = player_cam.fieldOfView;
        foreach (var cam in cameras)
        {
            cam.fieldOfView = FOV;
        }
    }
}
