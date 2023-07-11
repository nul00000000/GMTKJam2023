using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Settings;

public class ColliderScript : MonoBehaviour {

    private Rigidbody playerBody;
    public Transform fanTransform;
    public AudioSource noise;

    public float fanHeight = 0.2f;
    public float aoeHeight = 4;
    public float windStrength = 30;
    
    private bool colliding = false;

    void Start() {
        fanTransform.localPosition = new Vector3(0, fanHeight / 2, 0);
        fanTransform.localScale = new Vector3(2, fanHeight, 2);
        GetComponent<BoxCollider>().center = new Vector3(0, fanHeight + aoeHeight / 2, 0);
        GetComponent<BoxCollider>().size = new Vector3(2, aoeHeight, 2);
    }

    [ExecuteInEditMode]
    void OnValidate() {
        fanTransform.localPosition = new Vector3(0, fanHeight / 2, 0);
        fanTransform.localScale = new Vector3(2, fanHeight, 2);
        GetComponent<BoxCollider>().center = new Vector3(0, fanHeight + aoeHeight / 2, 0);
        GetComponent<BoxCollider>().size = new Vector3(2, aoeHeight, 2);
    }

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Player") {
            playerBody = collision.gameObject.GetComponentInParent<Rigidbody>();
            colliding = true;
        }
    }

    void OnTriggerExit(Collider collision) {
        if (collision.gameObject.tag == "Player") {
            playerBody = collision.gameObject.GetComponentInParent<Rigidbody>();
            colliding = false;
        }
    }
    void Update() {
        noise.volume = 0.215f * GameParams.soundVolumeMultiplier;
    }
    void FixedUpdate() {
        if (colliding) {
            playerBody.AddForce(transform.up * windStrength);
        }
    }
}
