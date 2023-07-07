using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringControl : MonoBehaviour {

    private float startTime = -100;
    private SpringJoint spring;
    public Rigidbody top;
    public Rigidbody bottom;
    public Transform springRender;

    // Start is called before the first frame update
    void Start()
    {
        this.spring = GetComponentInChildren<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            startTime = Time.time;
            spring.connectedAnchor = new Vector3(0.0f, 5.0f, 0.0f);
        }

        if(Time.time - startTime > 1.0f) {
            spring.connectedAnchor = new Vector3(0.0f, 1.5f, 0.0f);
        }
        float h = top.transform.localPosition.y - bottom.transform.localPosition.y;
        springRender.localScale = new Vector3(1, h, 1);
        springRender.localPosition = new Vector3(0, 0.125f + h / 2.0f, 0);
    }
}
