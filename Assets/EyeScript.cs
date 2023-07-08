using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeScript : MonoBehaviour
{
    public Material closedMat;
    public Material kindaMat;
    public Material openMat;
    
    public Renderer eyeRenderer;
    public Transform eyeTransform;
    public Rigidbody eyeRigid;
    public Transform characterHead;
    
    public Renderer quad;
    
    public float time;
    public bool active = true;
    public bool tracking = false;

    void Start()
    {
        quad.material = closedMat;
        time = Time.time;
        eyeRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active) {
            if (Time.time - time > 1 && !tracking) {
                quad.material = openMat;
                eyeTransform.localPosition = new Vector3(0, -.109f, 0);
                eyeRigid.velocity = new Vector3(0, 0, 0);
                eyeRenderer.enabled = true;
                tracking = true;
            } else if (Time.time - time > .5 && !tracking) {
                quad.material = kindaMat;
                Debug.Log(Time.time - time);
            }

            if (tracking) {
                Vector3 dir = characterHead.position - eyeTransform.position;

                eyeRigid.AddForce(dir);
            }
        }
        
    }
}
