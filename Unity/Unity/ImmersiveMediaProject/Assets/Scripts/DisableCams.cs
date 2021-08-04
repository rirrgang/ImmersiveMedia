using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCams : MonoBehaviour
{

    public bool disabled_at_start = false;

    public bool is_enabled = true;

    public bool playerIsOverlapping;

    public List<Camera> cams = new List<Camera>();

    public List<MeshRenderer > meshRenderers = new List<MeshRenderer >();


    // Start is called before the first frame update
    void Start()
    {
        if(disabled_at_start){
            for (int i = 0; i < cams.Count; i++){
                cams[i].enabled = false;  
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(playerIsOverlapping){
            for (int i = 0; i < cams.Count; i++){
                cams[i].enabled = is_enabled;
            }

            for (int i = 0; i < meshRenderers.Count; i++){
                meshRenderers[i].enabled = is_enabled;
            }

        }


        // if(Input.GetKey("1")){
        //     for (int i = 0; i < cams.Count; i++){
        //         cams[i].enabled = false;
        //     }
        // }

        // if(Input.GetKey("2")){
        //     for (int i = 0; i < cams.Count; i++){
        //         cams[i].enabled = true;
        //     }
        // }
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" || other.tag == "Player_VR"){
            playerIsOverlapping = true;
            is_enabled = !is_enabled;
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
