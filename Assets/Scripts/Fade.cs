using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    public static bool eSlide = true;

    public bool on = true;

    public GameObject[] defaultOn;
    public GameObject[] defaultOff;
    // private 

    // Start is called before the first frame update
    void Start() {
        
    }

    [ExecuteInEditMode]
    void OnValidate() {
        for(int i = 0; i < defaultOn.Length; i++) {
            defaultOn[i].SetActive(on);
        }
        for(int i = 0; i < defaultOff.Length; i++) {
            defaultOff[i].SetActive(!on);
        }
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            on = !on;
            for(int i = 0; i < defaultOn.Length; i++) {
                defaultOn[i].SetActive(on);
            }
            for(int i = 0; i < defaultOff.Length; i++) {
                defaultOff[i].SetActive(!on);
            }
        } 
    }
}
