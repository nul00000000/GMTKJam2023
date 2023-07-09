using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Settings;

public class MusicScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume *= GameParams.musicVolumeMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
