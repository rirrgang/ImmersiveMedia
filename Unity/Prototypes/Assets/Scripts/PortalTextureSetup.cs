using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{

    public Camera player_cam;
    public List<Camera> cams = new List<Camera>();
    public List<Material> mats = new List<Material>();
    public float FOV = 75.0f;

    void Start()
    {
        for (int i = 0; i < cams.Count; i++)
        {
            if (cams[i].targetTexture != null)
            {
                cams[i].targetTexture.Release();
            }
            
            FOV = player_cam.fieldOfView;
            cams[i].fieldOfView = FOV;
            cams[i].targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            mats[i].mainTexture = cams[i].targetTexture;
        }
    }

    
    void Update()
    {
        
    }
}
