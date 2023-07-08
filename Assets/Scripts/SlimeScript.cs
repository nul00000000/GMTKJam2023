using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool colliding = false;
    public AudioSource slime;
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            slime.Play();
        }
    }

    void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            slime.Stop();
        }
    }

    void Start()
    {
        // slime.Play()
    }

    // Update is called once per frame
    void Update()
    {
    }
}
