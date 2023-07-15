using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Boss : MonoBehaviour {

    void Start() {
        
    }

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Player") {
            
        }
    }

    void OnTriggerExit(Collider collision) {
        if (collision.gameObject.tag == "Player") {
            
        }
    }

    void Update() {
        
    }

}
