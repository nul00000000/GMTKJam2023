using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Boss : MonoBehaviour {

    public GameObject bossFight;

    private bool running = false;

    void Start() {
        bossFight.SetActive(false);
    }

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Player") {
            running = true;
            bossFight.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision) {
        if (collision.gameObject.tag == "Player") {
            running = false;
            bossFight.SetActive(false);
        }
    }

    void Update() {
        
    }

}
