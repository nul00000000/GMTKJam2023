using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Settings;

public class BOWSCRIPt : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameObj;
    public Rigidbody cubeBody;
    public AudioSource audioSource;

    private float time;
    void Start()
    {
        audioSource.volume = 0.318f * GameParams.soundVolumeMultiplier;
        time = Time.time;
        cubeBody.AddForce(new Vector3(5000, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - time > 1) {
            Destroy(gameObj);
        }
    }
}
