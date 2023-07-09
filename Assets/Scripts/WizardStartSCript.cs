using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardStartSCript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform headTransform;
    public ParticleSystem muzzle;
    public AudioSource source;

    private bool clicked = false;
    private float time = 0;
    void Start()
    {
        muzzle.Stop();    
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked && Time.time - time > 2) {
            headTransform.localRotation = Quaternion.AngleAxis(-30 * ((Time.time - time - 2) / 6), Vector3.up);
        }
    }

    public void OnClick() {
        muzzle.Play();
        source.Play();
        clicked = true;
        time = Time.time;

    }
}
