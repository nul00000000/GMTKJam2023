using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTouch : MonoBehaviour
{

    public float timeTouching;
    private bool colliding;
    // Start is called before the first frame update

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            colliding = true;
        }
    }

    void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            colliding = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(colliding) {
            timeTouching += Time.deltaTime;
        }
    }
}
