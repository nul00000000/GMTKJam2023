using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringControl : MonoBehaviour {

    private float startTime = -100;
    private SpringJoint spring;
    public Rigidbody top;
    public Rigidbody bottom;
    public Transform springRender;
    public Transform leftGuide;
    public Transform rightGuide;

    public float springAmount = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.spring = GetComponentInChildren<SpringJoint>();
    }

    [ExecuteInEditMode]
    void OnValidate() {
        leftGuide.localScale = new Vector3(0.2f, springAmount / 2.0f, 1);
        rightGuide.localScale = new Vector3(0.2f, springAmount / 2.0f, 1);
        leftGuide.localPosition = new Vector3(-1.1f, springAmount / 4.0f, 0);
        rightGuide.localPosition = new Vector3(1.1f, springAmount / 4.0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        top.WakeUp();
        if(Input.GetKeyDown(KeyCode.Space)) {
            startTime = Time.time;
            spring.connectedAnchor = new Vector3(0.0f, springAmount, 0.0f);
        }

        if(Time.time - startTime > 1.0f) {
            spring.connectedAnchor = new Vector3(0.0f, springAmount / 4.5f, 0.0f);
        }
        float h = top.transform.localPosition.y - bottom.transform.localPosition.y;
        springRender.localScale = new Vector3(1, h, 1);
        springRender.localPosition = new Vector3(0, 0.125f + h / 2.0f, 0);
    }
}
