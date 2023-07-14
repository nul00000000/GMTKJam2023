using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour {

    public Rigidbody follow;
    public float zOffset = -13.0f;
    public bool followRotation = false;
    public bool followX = true;

    private Rigidbody rigidBody;

    void Start() {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update() {
        if(followRotation) {
            transform.eulerAngles = new Vector3(0, 0, follow.transform.eulerAngles.z);
            transform.position = follow.position;
            rigidBody.velocity = follow.velocity;
        } else {
            float x = follow.position.x;

            if (!followX) {
                x = 0;
            }
            
            transform.position = new Vector3(x, follow.position.y, zOffset);
        }
    }

}
