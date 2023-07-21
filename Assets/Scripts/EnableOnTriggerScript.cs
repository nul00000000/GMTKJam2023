using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTriggerScript : MonoBehaviour
{
    public GameObject bossFight;

    public bool defaultOn = false;
    public bool onEnter = true;
    public bool onExit = true;

    void Start() {
        bossFight.SetActive(defaultOn);
    }

    void OnTriggerEnter(Collider collision) {
        if (onEnter && collision.gameObject.tag == "Player") {
            bossFight.SetActive(!defaultOn);
        }
    }

    void OnTriggerExit(Collider collision) {
        if (onExit && collision.gameObject.tag == "Player") {
            bossFight.SetActive(defaultOn);
        }
    }

}
