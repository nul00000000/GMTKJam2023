using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour {

    public Rigidbody slider;
    public Transform path;
    public Transform leftStop;
    public Transform rightStop;
    public bool horizontal = true;
    public bool useMouse = true;
    public float strength;
    public float length = 4.0f;
    public float distance = 10.0f;
    public Vector3 screenMouse = new Vector3(0, 0, 13);
    private bool selected = false;

    private Vector3 worldMouse;

    void Start() {
        if(horizontal) {
            transform.eulerAngles = new Vector3();
            slider.transform.localScale = new Vector3(length, 0.4f, 2.0f);
            path.localScale = new Vector3(distance, 0.2f, 0.2f);
            leftStop.transform.position = new Vector3(transform.position.x - distance / 2 - 0.5f, transform.position.y, transform.position.z);
            rightStop.transform.position = new Vector3(transform.position.x + distance / 2 + 0.5f, transform.position.y, transform.position.z);
            slider.constraints = ~RigidbodyConstraints.FreezePositionX;
        } else {
            transform.eulerAngles = new Vector3();
            slider.transform.localScale = new Vector3(0.4f, length, 2.0f);
            path.localScale = new Vector3(0.2f, distance, 0.2f);
            leftStop.transform.position = new Vector3(transform.position.x, transform.position.y - distance / 2 - 0.5f, transform.position.z);
            rightStop.transform.position = new Vector3(transform.position.x, transform.position.y + distance / 2 + 0.5f, transform.position.z);
            slider.constraints = ~RigidbodyConstraints.FreezePositionY;
        }
    }

    [ExecuteInEditMode]
    void OnValidate() {
        if(horizontal) {
            transform.eulerAngles = new Vector3();
            slider.transform.localScale = new Vector3(length, 0.4f, 2.0f);
            path.localScale = new Vector3(distance, 0.2f, 0.2f);
            leftStop.transform.position = new Vector3(transform.position.x - distance / 2 - 0.5f, transform.position.y, transform.position.z);
            rightStop.transform.position = new Vector3(transform.position.x + distance / 2 + 0.5f, transform.position.y, transform.position.z);
            slider.constraints = ~RigidbodyConstraints.FreezePositionX;
        } else {
            transform.eulerAngles = new Vector3();
            slider.transform.localScale = new Vector3(0.4f, length, 2.0f);
            path.localScale = new Vector3(0.2f, distance, 0.2f);
            leftStop.transform.position = new Vector3(transform.position.x, transform.position.y - distance / 2 - 0.5f, transform.position.z);
            rightStop.transform.position = new Vector3(transform.position.x, transform.position.y + distance / 2 + 0.5f, transform.position.z);
            slider.constraints = ~RigidbodyConstraints.FreezePositionY;
        }
    }

    void Update() {
        if (useMouse) {    
            screenMouse = Input.mousePosition;
        } else {
        }

        screenMouse.z = 13;
        worldMouse = Camera.main.ScreenToWorldPoint(screenMouse, Camera.MonoOrStereoscopicEye.Mono);
        if(Input.GetMouseButtonDown(0)) {
            if((horizontal && Mathf.Abs(worldMouse.x - slider.position.x) < length / 2 && Mathf.Abs(worldMouse.y - slider.position.y) < 0.5f) || 
                    (!horizontal && Mathf.Abs(worldMouse.y - slider.position.y) < length / 2 && Mathf.Abs(worldMouse.x - slider.position.x) < 0.5f)) {
                selected = true;
            }
        }
        if(Input.GetMouseButtonUp(0)) {
            selected = false;
        }
    }

    void FixedUpdate() {
        if(selected) {
            if(worldMouse.x > transform.position.x + distance / 2 - length / 2) {
                worldMouse.x = transform.position.x + distance / 2 - length / 2;
            } else if(worldMouse.x < transform.position.x - distance / 2 + length / 2) {
                worldMouse.x = transform.position.x - distance / 2 + length / 2;
            }
            if(worldMouse.y > transform.position.y + distance / 2 - length / 2) {
                worldMouse.y = transform.position.y + distance / 2 - length / 2;
            } else if(worldMouse.y < transform.position.y - distance / 2 + length / 2) {
                worldMouse.y = transform.position.y - distance / 2 + length / 2;
            }
            if(horizontal) {
                slider.AddForce(new Vector3(worldMouse.x - slider.position.x, 0, 0) * strength * 8);
            } else {
                slider.AddForce(new Vector3(0, worldMouse.y - slider.position.y, 0) * strength * 8);
            }
        }
    }

}
