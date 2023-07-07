using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    private SpringJoint spring;
    public Rigidbody connectedBody;

    // Start is called before the first frame update
    void Start()
    {
        this.spring = GetComponent<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)) {
            spring.connectedBody = connectedBody;
        } else {
            spring.connectedBody = null;
        }
        // float d = Time.time - startTime;
        // if(d < 1) {
        //     transform.localScale = new Vector3(2, -10 * d * (d - 1) + 0.25f, 2);
        //     transform.position = new Vector3(0, -5 * d * (d - 1) + 0.25f / 2, 0);
        // } else {
        //     transform.localScale = new Vector3(2, 0.25f, 2);
        //     transform.position = new Vector3(0, 0.25f / 2.0f, 0);
        // }
    }
}
