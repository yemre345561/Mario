using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundingswitch : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject virtualCam;
    
    private void Start(){
    virtualCam = gameObject.transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag=="Player"&&!collision.isTrigger){
            virtualCam.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.tag=="Player"&&!collision.isTrigger){
            virtualCam.SetActive(false);
        }
    }
}
