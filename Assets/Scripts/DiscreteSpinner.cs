using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscreteSpinner : MonoBehaviour
{
    private Rigidbody body;

    public bool left = true;
    public float strength = 10;
    public int numPositions = 8;

    private float anglePerPosition;

    [System.NonSerialized]
    public int currentPosition = 0;
    private float targetAngle = 0;
    private float startingAngle = 0;//in degrees

    void Start() {
        body = GetComponent<Rigidbody>();
        body.maxAngularVelocity = 7;
        startingAngle = body.transform.eulerAngles.z;
        anglePerPosition = 360.0f / numPositions;
        if(left) {
            anglePerPosition = -anglePerPosition;
        }
        targetAngle = currentPosition * anglePerPosition + startingAngle;
    }

    float Mod(float a, float n) {
        return a - Mathf.Floor(a / n) * n;
    }

    [ExecuteInEditMode]
    void OnValidate() {
        body = GetComponent<Rigidbody>();
        body.maxAngularVelocity = 7;
        startingAngle = body.transform.eulerAngles.z;
        anglePerPosition = 360.0f / numPositions;
        if(left) {
            anglePerPosition = -anglePerPosition;
        }
        targetAngle = currentPosition * anglePerPosition + startingAngle;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.A)) {
            currentPosition++;
            if(currentPosition >= numPositions) {
                currentPosition = 0;
            }
            targetAngle = currentPosition * anglePerPosition + startingAngle;
        }
    }

    void FixedUpdate() {
        float a = targetAngle - body.transform.eulerAngles.z;
        a = Mod(a + 180, 360) - 180;
        body.AddTorque(new Vector3(0, 0, a * strength));
    }
}
