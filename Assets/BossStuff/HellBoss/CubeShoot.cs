using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public float angle = 0;
    public Rigidbody cube;
    public GameObject gameObj;
    private float time;
    public float power = 100;
    public float cooldown = 1;
    public float timeToKill = 4;
    private bool appliedForce = false;
    void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - time > timeToKill) {
            Destroy(gameObj);
        } else if (Time.time - time > cooldown) {
            cube.AddForce(new Vector3(power * Mathf.Cos(angle * Mathf.PI/ 180.0f), power * Mathf.Sin(angle * Mathf.PI / 180.0f), 0));
            appliedForce = true;
        } else if (!appliedForce) {
            cube.velocity = new Vector3(.3f * Mathf.Cos(angle), .3f * Mathf.Sin(angle), 0);
        }
        
    }
}
