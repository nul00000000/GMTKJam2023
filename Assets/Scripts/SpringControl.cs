using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Settings;

public class SpringControl : MonoBehaviour {

    private float startTime = -100;
    private SpringJoint spring;
    public Rigidbody top;
    public Rigidbody bottom;
    public Transform springRender;
    public Transform springBlocker;
    public AudioSource first;
    public AudioSource second;
    public AudioSource startLine;
    public float springAmount = 5.0f;
    public float width = 2.0f;
    private bool edd = false;
    private bool startTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        this.spring = GetComponentInChildren<SpringJoint>();
        Vector3 diff = top.transform.localPosition - bottom.transform.localPosition;
        springRender.localScale = new Vector3(width / 2, Vector3.Magnitude(diff), 1);
        springRender.localPosition = (top.transform.localPosition + bottom.transform.localPosition) / 2;
        springRender.localRotation = top.transform.localRotation;

        springBlocker.localScale = new Vector3(width, Vector3.Magnitude(diff), 2);
        springBlocker.localPosition = (top.transform.localPosition + bottom.transform.localPosition) / 2;
        springBlocker.localRotation = top.transform.localRotation;

        bottom.transform.localScale = new Vector3(width, 0.25f, 2);
        top.transform.localScale = new Vector3(width, 0.25f, 2);
    }

    [ExecuteInEditMode]
    void OnValidate() {
        Vector3 diff = top.transform.localPosition - bottom.transform.localPosition;
        springRender.localScale = new Vector3(width / 2, Vector3.Magnitude(diff), 1);
        springRender.localPosition = (top.transform.localPosition + bottom.transform.localPosition) / 2;
        springRender.localRotation = top.transform.localRotation;

        springBlocker.localScale = new Vector3(width, Vector3.Magnitude(diff), 2);
        springBlocker.localPosition = (top.transform.localPosition + bottom.transform.localPosition) / 2;
        springBlocker.localRotation = top.transform.localRotation;

        bottom.transform.localScale = new Vector3(width, 0.25f, 2);
        top.transform.localScale = new Vector3(width, 0.25f, 2);
    }
    
    // Update is called once per frame
    void Update()
    {
        first.volume = 0.165f * GameParams.soundVolumeMultiplier;
        second.volume = 0.103f * GameParams.soundVolumeMultiplier;

        top.WakeUp();
        Vector3 diff = top.transform.localPosition - bottom.transform.localPosition;
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(!startTriggered && startLine != null) {
                startLine.Play();
                startTriggered = true;
            }
            first.Play();
            edd = true;
            startTime = Time.time;
            spring.connectedAnchor = new Vector3(0.0f, springAmount, 0.0f);
        }

        if(Time.time - startTime > 1.0f) {
            if (edd) {
                edd = false;
                second.Play();
            }
            spring.connectedAnchor = new Vector3(0.0f, springAmount / 4.5f, 0.0f);
        }
        float h = top.transform.localPosition.y - bottom.transform.localPosition.y;
        springRender.localScale = new Vector3(width / 2, Vector3.Magnitude(diff), 1);
        springRender.localPosition = (top.transform.localPosition + bottom.transform.localPosition) / 2;
        springRender.localRotation = top.transform.localRotation;

        springBlocker.localScale = new Vector3(width, Vector3.Magnitude(diff), 2);
        springBlocker.localPosition = (top.transform.localPosition + bottom.transform.localPosition) / 2;
        springBlocker.localRotation = top.transform.localRotation;
    }

    void FixedUpdate() {
        Vector3 diff = top.transform.localPosition - bottom.transform.localPosition;
        if (Vector3.Dot(diff, bottom.transform.up) < 0) {
            top.AddForce(bottom.transform.up * 0.1f);
        }
    }
}
