using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenMinuteLine : MonoBehaviour
{
    public AudioSource good;
    public AudioSource bad;
    public TimeTouch timeReference;

    private bool played = false;

    void OnCollisionEnter(Collision collision) {
        if(!played && collision.gameObject.tag == "Player") {
            if(timeReference.timeTouching < 60) {
                Debug.Log("Good" + timeReference.timeTouching);
                good.Play();
            } else {
                Debug.Log("Bad" + timeReference.timeTouching);
                bad.Play();
            }
            played = true;
        }
    }

}
