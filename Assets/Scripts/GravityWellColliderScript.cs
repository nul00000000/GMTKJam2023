using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWellColliderScript : MonoBehaviour
{
    void Start() {
        
    }

    void Update() {
        
    }

    public void OnTriggerEnter(Collider collider) {

        if (collider.gameObject.tag == "Player") {
            collider.gameObject.GetComponentInParent<Rigidbody>().useGravity = false;
            return;
        }
        // Rigidbody gameObj = collider.gameObject.GetComponent<Rigidbody>();
        // if (gameObj != null) {
        //     gameObj.useGravity = false;
        // }
    }

    public void OnTriggerExit(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            collider.gameObject.GetComponentInParent<Rigidbody>().useGravity = true;
            return;
        }

        // Rigidbody gameObj = collider.gameObject.GetComponent<Rigidbody>();
        // if (gameObj != null) {
        //     gameObj.useGravity = true;
        // }
    }
}
