using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame 
    public Rigidbody rigidBody;
    public HingeJoint hingeConstraint;
    void Start()
    {
        rigidBody.maxAngularVelocity = Mathf.Infinity;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 angles = transform.rotation.eulerAngles;
        // Vector3 newAngles = new Vector3(angles.x, angles.y, Math.Clamp(angles.z, -50, 50));
        // transform.rotation = Quaternion.Euler(newAngles);
        if (Input.GetKey(KeyCode.Space)) {
            rigidBody.AddTorque(new Vector3(0, 0, -40));
        }
    }
}
