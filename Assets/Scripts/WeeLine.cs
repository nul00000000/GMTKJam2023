using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeeLine : MonoBehaviour
{
    private bool played = false;

    public AudioSource wee;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerExit(Collider collision) {
        if (collision.gameObject.tag == "Player" && !played) {
            wee.Play();
            played = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
