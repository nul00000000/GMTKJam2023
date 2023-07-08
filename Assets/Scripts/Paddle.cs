using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame 
    public bool left = true;
    public Rigidbody rigidBody;
    public HingeJoint HingeConstraint;
    public float flipperStrength = 10;
    void Start()
    {
        rigidBody.maxAngularVelocity = Mathf.Infinity;
    }

    [ExecuteInEditMode]
    void OnValidate() {
        if(left) {
            transform.eulerAngles = new Vector3(0, 0, 0);
            JointLimits n = HingeConstraint.limits;
            n.min = -80;
            n.max = 50;
            HingeConstraint.limits = n;
        } else {
            transform.eulerAngles = new Vector3(0, 0, 180);
            JointLimits n = HingeConstraint.limits;
            n.min = -50;
            n.max = 80;
            HingeConstraint.limits = n;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Vector3 angles = transform.rotation.eulerAngles;
        // Vector3 newAngles = new Vector3(angles.x, angles.y, Math.Clamp(angles.z, -50, 50));
        // transform.rotation = Quaternion.Euler(newAngles);
        if (Input.GetKey(KeyCode.Q)) {
            rigidBody.AddTorque(new Vector3(0, 0, left ? -flipperStrength : flipperStrength));
        }
    }
}
