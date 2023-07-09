using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerVoice : MonoBehaviour {

    public AudioSource fall1;
    public AudioSource fall2;
    public AudioSource fall3;
    public AudioSource fall10;

    private int numTimes = 0;

    void OnTriggerExit(Collider collision) {
        if (collision.gameObject.tag == "Player") {
            numTimes++;
            if(numTimes == 1) {
                fall1.Play();
            } else if(numTimes == 2) {
                fall2.Play();
            } else if(numTimes == 3) {
                fall3.Play();
            } else if(numTimes == 10) {
                fall10.Play();
            }
        }
    }

}
