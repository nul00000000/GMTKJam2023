using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody cubeRigid;
    public GameObject gameObject;
    public bool left = true;
    public float cubeStrength = 10;
    private float time = 0;
    private bool appliedForce = false;
    void Start()
    {
        time = Time.time;
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Time.time - time > 2) {
            Destroy(gameObject);
        } else if (Time.time - time > .5) {
            cubeRigid.AddForce(new Vector3(cubeStrength * (left ? -1 : 1), 0, 0));
            appliedForce = true;
        } else if (!appliedForce) {
            cubeRigid.velocity = new Vector3(0, 0, 0);
        }
    }
}
