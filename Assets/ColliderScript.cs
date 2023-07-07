using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody playerBody;
    public Transform cubeTransform;
    
    public bool colliding = false;
    public float angle = 0;

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Player") {
            
            colliding = true;
        }

    }

    void OnTriggerExit(Collider collision) {
        if (collision.gameObject.tag == "Player") {
            colliding = false;
        }

    }
    void Start() {
        transform.localPosition = new Vector3(0, cubeTransform.localScale.y / 2 + transform.localScale.y / 2, 0);
    }

    // Update is called once per frame
    void Update() {
        if (colliding) {
            playerBody.AddForce(transform.up * 100);
        }

        transform.localPosition = new Vector3(0, cubeTransform.localScale.y / 2 + transform.localScale.y / 2, 0);
    }
}
