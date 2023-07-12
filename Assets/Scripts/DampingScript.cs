using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DampingScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource damping;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            Debug.Log(collision.impulse);
            damping.Play();
            collision.gameObject.GetComponentInParent<Rigidbody>().velocity *= .05f;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
