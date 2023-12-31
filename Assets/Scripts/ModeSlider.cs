using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSlider : MonoBehaviour {
    public Rigidbody slider;
    public Transform path;
    public bool horizontal = true;
    public bool defaultLeft = true;
    public float strengthLeft = 6.0f;
    public float strengthRight = 6.0f;
    public float length = 4.0f;
    public float distance = 10.0f;

    private float target;

    void Start() {
        target = (distance - length) / 2;
        if(defaultLeft) {
            target = -target;
        }
        if(horizontal) {
            transform.eulerAngles = new Vector3();
            slider.transform.localScale = new Vector3(length, 0.4f, 2.0f);
            slider.transform.position = transform.position + new Vector3(target, 0, 0);
            path.localScale = new Vector3(distance - 0.1f, 0.2f, 0.2f);
            slider.constraints = ~RigidbodyConstraints.FreezePositionX;
        } else {
            transform.eulerAngles = new Vector3();
            slider.transform.localScale = new Vector3(0.4f, length, 2.0f);
            slider.transform.position = transform.position + new Vector3(0, target, 0);
            path.localScale = new Vector3(0.2f, distance - 0.1f, 0.2f);
            slider.constraints = ~RigidbodyConstraints.FreezePositionY;
        }
    }

    [ExecuteInEditMode]
    void OnValidate() {
        target = (distance - length) / 2;
        if(defaultLeft) {
            target = -target;
        }
        if(horizontal) {
            transform.eulerAngles = new Vector3();
            slider.transform.localScale = new Vector3(length, 0.4f, 2.0f);
            slider.transform.position = transform.position + new Vector3(target, 0, 0);
            path.localScale = new Vector3(distance - 0.1f, 0.2f, 0.2f);
            slider.constraints = ~RigidbodyConstraints.FreezePositionX;
        } else {
            transform.eulerAngles = new Vector3();
            slider.transform.localScale = new Vector3(0.4f, length, 2.0f);
            slider.transform.position = transform.position + new Vector3(0, target, 0);
            path.localScale = new Vector3(0.2f, distance - 0.1f, 0.2f);
            slider.constraints = ~RigidbodyConstraints.FreezePositionY;
        }
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            target = -target;
        }
    }

    void FixedUpdate() {
        if(horizontal) {
            float t = target - slider.transform.localPosition.x;
            slider.AddForce(new Vector3(t, 0, 0) * (t < 0 ? strengthLeft : strengthRight) * 8);
        } else {
            float t = target - slider.transform.localPosition.y;
            slider.AddForce(new Vector3(0, t, 0) * (t < 0 ? strengthLeft : strengthRight) * 8);
        }
    }
}
