using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {

    private Rigidbody body;

    public bool left = true;
    public float strength = 80;

    [System.NonSerialized]
    public bool codeOverride = false;

    void Start() {
        body = GetComponent<Rigidbody>();
        body.maxAngularVelocity = 7;
    }

    void FixedUpdate() {
        if(Input.GetKey(KeyCode.W) || codeOverride) {
            body.AddTorque(new Vector3(0, 0, left ? strength : -strength));
        }
    }
}
