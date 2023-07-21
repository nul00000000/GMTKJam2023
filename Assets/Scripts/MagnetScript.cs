using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Settings;

public class MagnetScript : MonoBehaviour {

    private Rigidbody playerBody;
    public Transform fanTransform;
    public AudioSource noise;
    public new ParticleSystem particleSystem;

    public float fanHeight = 0.2f;
    public float aoeHeight = 4;
    public float windStrength = 30;
    
    private bool colliding = false;
    public bool on = false;
    private Rigidbody rigidBody;

    void Start() {
        fanTransform.localPosition = new Vector3(0, fanHeight / 2, 0);
        fanTransform.localScale = new Vector3(2, fanHeight, 2);
        GetComponent<BoxCollider>().center = new Vector3(0, fanHeight + aoeHeight / 2, 0);
        GetComponent<BoxCollider>().size = new Vector3(2, aoeHeight, 2);
        rigidBody = GetComponent<Rigidbody>();
    }

    [ExecuteInEditMode]
    void OnValidate() {
        fanTransform.localPosition = new Vector3(0, fanHeight / 2, 0);
        fanTransform.localScale = new Vector3(2, fanHeight, 2);
        GetComponent<BoxCollider>().center = new Vector3(0, fanHeight + aoeHeight / 2, 0);
        GetComponent<BoxCollider>().size = new Vector3(2, aoeHeight, 2);
        if (!on) {
            particleSystem.Pause();
            particleSystem.Clear();
        } else {
            particleSystem.Play();
        }
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

        if (Input.GetKeyDown(KeyCode.A)) {
            on = !on;
            if (!on) {
                particleSystem.Pause();
                particleSystem.Clear();
            } else {
                particleSystem.Play();
            }
        }
    }
    void FixedUpdate() {
        if (colliding && on) {
            playerBody.AddForce(transform.up * -windStrength);
        }
        // if(rigidBody != null) {
        //     rigidBody.AddForce(-transform.up * windStrength);
        // }
    }
}
