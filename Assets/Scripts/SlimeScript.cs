using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Settings;

public class SlimeScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool colliding = false;
    public AudioSource slime;
    public AudioSource slimeLine;

    private static float time = 0;
    private static bool played = false;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            slime.Play();
            colliding = true;
        }
    }

    void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            slime.Stop();
            colliding = false;
        }
    }

    void Start()
    {
        // slime.Play()
    }

    // Update is called once per frame
    void Update()
    {
        slime.volume = 1 * GameParams.soundVolumeMultiplier;
        if(!played && colliding) {
            time += Time.deltaTime;
        }

        if(!played && time > 7 && slimeLine) {
            slimeLine.Play();
            played = true;
        }
    }
}
